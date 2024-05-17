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

    // ��ȭ ��ư ������
    public void OnClickLevelUpBtn()
    {
        // ���� ������, �ؽ�Ʈ 1 ����
        currentLevelData += 1;
        currentLevelText.text = currentLevelData.ToString();

        // ���� ����Ʈ 1 ����
        statPoint -= 1;
        statPointText.text = statPoint.ToString();

        // ���� ��ư Ȱ��ȭ ���� �˻�
       /* if (!statManager.saveBtn.activeSelf)
        {
            statManager.saveBtn.SetActive(true);
        }

        statManager.ToggleBtnActive();*/
    }

    public void OnClickLevelDownBtn()
    {
        // ���� ������, �ؽ�Ʈ 1 ����
        currentLevelData -= 1;
        currentLevelText.text = currentLevelData.ToString();

        // ���� ����Ʈ 1 ����
        statPoint += 1;
        statPointText.text = statPoint.ToString();

        // ���� ��ư Ȱ��ȭ ���� �˻�
/*        if (!statManager.saveBtn.activeSelf)
        {
            statManager.saveBtn.SetActive(true);
        }

        statManager.ToggleBtnActive();*/
    }




}
