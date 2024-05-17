using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    // statManager 인스턴스 생성
    public static StatManager statManager;

    // 여기 인스턴스 지정 안 돼서 오류 
    PlayerInfo PlayerInfo;

    int currentHpLevel;
    int currentDamageLevel;
    int currentSpeedLevel;

    public TMP_Text hpLevelText;
    public TMP_Text damageLevelText;
    public TMP_Text speedLevelText;

    // 레벨 +, - 버튼 담을 배열 
    GameObject[] optionButtons;

    // 현재 사용할 수 있는 스탯 포인트 
    // Playerinfo에 추가해야 함
    // int statPoint = PlayerInfo.statPoint 
    public int statPoint;
    public TMP_Text statPointText;
  

    // 저장 버튼 
    public GameObject saveButton;

    // 뒤로가기 버튼
    public GameObject goBackButton;

    void Awake()
    {
        if (statManager == null)
        {
            statManager = this;
        }
       
    }

    void Start()
    {
        // 현재 강화 레벨 가져오기
        //currentHpLevel = PlayerInfo.hpReinforcementCount;
        //currentDamageLevel = PlayerInfo.attackDamageReinforcementCount;
        //currentSpeedLevel = PlayerInfo.speedReinforcementCount;

        currentHpLevel = 0;
        currentDamageLevel = 0;
        currentSpeedLevel = 0;

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
        //PlayerInfo.hpReinforcementCount = int.Parse(hpLevelText.text);
        //PlayerInfo.attackDamageReinforcementCount = int.Parse(hpLevelText.text);
        //PlayerInfo.speedReinforcementCount = int.Parse(speedLevelText.text);
        //PlayerInfo.statPoint = statPoint;

        // 버튼 활성화 검사
        ToggleBtnActive();

        // 저장 버튼 비활성화
        saveButton.GetComponent<Button>().interactable = false;


    }

    // 버튼 활성화 토글
    public void ToggleBtnActive()
    {
        Debug.Log("실행!");

        // 스탯 포인트 0이면
        if (statPoint <= 0)
        {
            Debug.Log("비활성화!");
            // 버튼 비활성화
           foreach (GameObject button in optionButtons)
            {
                button.GetComponent<Button>().interactable = false;

                //enabled랑 interactable 차이
            }
        }

        // 스탯 포인트 1 이상이면
        else 
        {
            Debug.Log("활성화!");
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


}
