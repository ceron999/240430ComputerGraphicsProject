using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public StatManager statManager;
    // 해당 옵션의 현재 강화 레벨 
    public TMP_Text currentLevelText;
    int currentLevelData;

    // 스탯 포인트 
    public TMP_Text statPointText;

    public GameObject saveButton;

    void Start()
    {
        // 현재 옵션의 레벨 정보 가져오기
        currentLevelText = transform.GetChild(1).GetComponent<TMP_Text>();
        currentLevelData = int.Parse(currentLevelText.text);
 
        

    }

    // (+) 버튼 누르면
    public void OnClickLevelUpBtn()
    {
        // 스탯 포인트가 있으면 실행
        if (statManager.statPoint != 0)
        {
            // 레벨 데이터, 텍스트 1 증가
            currentLevelData += 1;
            currentLevelText.text = currentLevelData.ToString();

            // 스탯 포인트 1 감소
            statManager.statPoint -= 1;
            statPointText.text = statManager.statPoint.ToString();

            // 저장 버튼 활성화 여부 검사
            if (saveButton.GetComponent<Button>().interactable == false)
            {
                saveButton.GetComponent<Button>().interactable = true;
            }
        }
            
        
    }

    // (-) 버튼 누르면
    public void OnClickLevelDownBtn()
    {
        // 현재 레벨이 양수일 때만 실행
        if (currentLevelData != 0) {
            // 레벨 데이터, 텍스트 1 감소
            currentLevelData -= 1;
            currentLevelText.text = currentLevelData.ToString();

            // 스탯 포인트 1 증가
            statManager.statPoint += 1;
            statPointText.text = statManager.statPoint.ToString();

            // 저장 버튼 활성화 여부 검사
            if (saveButton.GetComponent<Button>().interactable == false)
            {
                saveButton.GetComponent<Button>().interactable = true;
            }

     
        }
           

    }




}
