using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Option : MonoBehaviour
{

    
    public TMP_Text currentLevelText;
    int currentLevelData;


    public TMP_Text statPointText;
    int statPoint;

    void Start()
    {

        currentLevelText = transform.GetChild(1).GetComponent<TMP_Text>();
        currentLevelData = int.Parse(currentLevelText.text);
        statPoint = int.Parse(statPointText.text);
        

    }

    // 강화 버튼 누르면
    public void OnClickLevelUpBtn()
    {
        // 레벨 데이터, 텍스트 1 증가
        currentLevelData += 1;
        currentLevelText.text = currentLevelData.ToString();

        // 스탯 포인트 1 감소
        statPoint -= 1;
        statPointText.text = statPoint.ToString();

        // 저장 버튼 활성화 여부 검사
       /* if (!statManager.saveBtn.activeSelf)
        {
            statManager.saveBtn.SetActive(true);
        }

        statManager.ToggleBtnActive();*/
    }

    public void OnClickLevelDownBtn()
    {
        // 레벨 데이터, 텍스트 1 감소
        currentLevelData -= 1;
        currentLevelText.text = currentLevelData.ToString();

        // 스탯 포인트 1 증가
        statPoint += 1;
        statPointText.text = statPoint.ToString();

        // 저장 버튼 활성화 여부 검사
/*        if (!statManager.saveBtn.activeSelf)
        {
            statManager.saveBtn.SetActive(true);
        }

        statManager.ToggleBtnActive();*/
    }




}
