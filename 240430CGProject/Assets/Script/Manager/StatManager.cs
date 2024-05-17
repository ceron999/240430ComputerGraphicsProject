using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    // statManager 인스턴스 생성
    public static StatManager statManager;

    PlayerInfo PlayerInfo;

    int currentHpLevel;
    int currentDamageLevel;
    int currentSpeedLevel;

    public TMP_Text hpLevelText;
    public TMP_Text damageLevelText;
    public TMP_Text speedLevelText;

    // 버튼 담은 배열 만들어서 <Button> 컴포넌트 찾아서 순회하며 비활성화
    GameObject[] optionButtons;

    // 현재 사용할 수 있는 스탯 포인트 -> PlayerInfo 정보에 추가해야함
    public TMP_Text statPointText;
    public int statPoint; 

    public GameObject saveBtn;

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

        //foreach (GameObject button in optionButtons)
        // { Debug.Log(button.name) ; }

        ToggleBtnActive();
    }

    // 저장 버튼 눌렀을 시 
    void OnClickSaveBtn()
    {

   
        // 변경된 레벨 및 스탯 포인트 PlayerInfo 에 저장 
        PlayerInfo.hpReinforcementCount = int.Parse(hpLevelText.text);
        PlayerInfo.attackDamageReinforcementCount = int.Parse(hpLevelText.text);
        PlayerInfo.speedReinforcementCount = int.Parse(speedLevelText.text);
        //PlayerInfo.statPoint = int.Parse(statPoint);
        saveBtn.SetActive(false);

        // 버튼 활성화 검사
        ToggleBtnActive();
        

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

                //enabled랑 interactable 차이
            }
        }

        // 스탯 포인트 1 이상이면
        else 
        {
            // 버튼 활성화
            
     
  
        }

       
    }


}
