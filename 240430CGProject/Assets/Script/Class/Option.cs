using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public StatManager statManager;
    // �ش� �ɼ��� ���� ��ȭ ���� 
    public TMP_Text currentLevelText;
    int currentLevelData;

    // ���� ����Ʈ 
    public TMP_Text statPointText;

    public GameObject saveButton;

    void Start()
    {
        // ���� �ɼ��� ���� ���� ��������
        currentLevelText = transform.GetChild(1).GetComponent<TMP_Text>();
        currentLevelData = int.Parse(currentLevelText.text);
 
        

    }

    // (+) ��ư ������
    public void OnClickLevelUpBtn()
    {
        // ���� ����Ʈ�� ������ ����
        if (statManager.statPoint != 0)
        {
            // ���� ������, �ؽ�Ʈ 1 ����
            currentLevelData += 1;
            currentLevelText.text = currentLevelData.ToString();

            // ���� ����Ʈ 1 ����
            statManager.statPoint -= 1;
            statPointText.text = statManager.statPoint.ToString();

            // ���� ��ư Ȱ��ȭ ���� �˻�
            if (saveButton.GetComponent<Button>().interactable == false)
            {
                saveButton.GetComponent<Button>().interactable = true;
            }
        }
            
        
    }

    // (-) ��ư ������
    public void OnClickLevelDownBtn()
    {
        // ���� ������ ����� ���� ����
        if (currentLevelData != 0) {
            // ���� ������, �ؽ�Ʈ 1 ����
            currentLevelData -= 1;
            currentLevelText.text = currentLevelData.ToString();

            // ���� ����Ʈ 1 ����
            statManager.statPoint += 1;
            statPointText.text = statManager.statPoint.ToString();

            // ���� ��ư Ȱ��ȭ ���� �˻�
            if (saveButton.GetComponent<Button>().interactable == false)
            {
                saveButton.GetComponent<Button>().interactable = true;
            }

     
        }
           

    }




}
