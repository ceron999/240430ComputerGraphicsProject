using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{

    // 레벨 값 텍스트
    public TMP_Text hpLevelText;
    public TMP_Text damageLevelText;
    public TMP_Text speedLevelText;

    public int currentHpLevel;
    public int currentDamageLevel;
    public int currentSpeedLevel;

    // 레벨 +, - 버튼 담을 배열 
    GameObject[] optionButtons;

    // 현재 사용할 수 있는 스탯 포인트 
    public int statPoint;
    public TMP_Text statPointText;
  

    // 저장 버튼 
    public GameObject saveButton;

    // 뒤로가기 버튼
    public GameObject goBackButton;


    void Start()
    {
        // 현재 강화 레벨 가져오기
        currentHpLevel = GameManager.gameManager.playerInfo.hpReinforcementCount;
        currentDamageLevel = GameManager.gameManager.playerInfo.attackDamageReinforcementCount;
        currentSpeedLevel = GameManager.gameManager.playerInfo.speedReinforcementCount;
        statPoint = GameManager.gameManager.playerInfo.level - (currentHpLevel + currentDamageLevel + currentSpeedLevel);


        // 현재 레벨 화면에 표시 
        hpLevelText.text = currentHpLevel.ToString();
        damageLevelText.text = currentDamageLevel.ToString();
        speedLevelText.text = currentSpeedLevel.ToString();
        statPointText.text = statPoint.ToString();

        // 업다운 버튼 배열(활성화 토글 목적)
        optionButtons = GameObject.FindGameObjectsWithTag("button");

        // 저장 버튼 비활성화로 초기화
        saveButton.GetComponent<Button>().interactable = false;

        // 강화 버튼 활성화 여부 검사
        ToggleBtnActive();

        
    }

    // 저장 버튼 눌렀을 시 
    public void OnClickSaveBtn()
    {

        // 변경된 레벨 및 스탯 포인트 PlayerInfo 에 저장 
        GameManager.gameManager.playerInfo.hpReinforcementCount = currentHpLevel;
        GameManager.gameManager.playerInfo.attackDamageReinforcementCount = currentDamageLevel;
        GameManager.gameManager.playerInfo.speedReinforcementCount = currentSpeedLevel;
        GameManager.gameManager.playerInfo.statPoint = statPoint;
        JsonManager.SaveJson<PlayerInfo>(GameManager.gameManager.playerInfo, "SaveData");


        // 버튼 활성화 검사
        ToggleBtnActive();

        // 저장 버튼 비활성화
        saveButton.GetComponent<Button>().interactable = false;
    }

    // 버튼 활성화 토글
    public void ToggleBtnActive()
    {
        // 스탯 포인트 0이면
        if (statPoint <= 0)
        {         
            // 버튼 비활성화
           foreach (GameObject button in optionButtons)
            {
                button.GetComponent<Button>().interactable = false;             
            }
        }
        // 스탯 포인트 1 이상이면
        else 
        {
            // 버튼 활성화
            foreach (GameObject button in optionButtons)
            {
                button.GetComponent<Button>().interactable = true;             
            }
        }  
    }

    public void GoBack()
    {
        SceneManager.LoadScene("StartScene");
    }

    void saveBtnToggle()
    {
        // 저장 버튼 활성화
        if (saveButton.GetComponent<Button>().interactable == false)
        {
            saveButton.GetComponent<Button>().interactable = true;
        }
    }

    // 각 옵션 별 레벨 업/다운 버튼 클릭 시

    public void HpLevelUp()
    {
        // 스탯포인트가 0이 아니면 가능
        if (statPoint != 0)
        {
            // 레벨 +1
            currentHpLevel+= 1;
            hpLevelText.text = currentHpLevel.ToString();

            // 스탯 포인트 -1
            statPoint -= 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }

    public void HpLevelDown()
    {
        // 현재 레벨이 0이 아닌 경우 가능
        if (currentHpLevel != 0)
        {
            // 현재 레벨 -1
            currentHpLevel -= 1;
            hpLevelText.text = currentHpLevel.ToString();

            // 스탯포인트 +1
            statPoint += 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle() ;

        }

    }

    // 공격력 버튼
    public void DamageLevelUp()
    {
        // 스탯포인트가 0이 아니면 가능
        if (statPoint != 0)
        {
            // 레벨 +1
            currentDamageLevel += 1;
            damageLevelText.text = currentDamageLevel.ToString();

            // 스탯 포인트 -1
            statPoint -= 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }

    public void DamageLevelDown()
    {
        // 현재 레벨이 0이 아닌 경우 가능
        if (currentDamageLevel != 0)
        {
            // 현재 레벨 -1
            currentDamageLevel -= 1;
            damageLevelText.text = currentDamageLevel.ToString();

            // 스탯포인트 +1
            statPoint += 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }


    // 이동속도 버튼
    public void SpeedLevelUp()
    {
        // 스탯포인트가 0이 아니면 가능
        if (statPoint != 0)
        {
            // 레벨 +1
            currentSpeedLevel += 1;
            speedLevelText.text = currentSpeedLevel.ToString();

            // 스탯 포인트 -1
            statPoint -= 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }

    public void SpeedDownBtn()
    {
        // 현재 레벨이 0이 아닌 경우 가능
        if (currentSpeedLevel != 0)
        {
            // 현재 레벨 -1
            currentSpeedLevel -= 1;
            speedLevelText.text = currentSpeedLevel.ToString();

            // 스탯포인트 +1
            statPoint += 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }
}
