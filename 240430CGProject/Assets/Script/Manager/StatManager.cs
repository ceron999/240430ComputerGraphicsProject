using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    // statManager �ν��Ͻ� ����
    public static StatManager statManager;

    // ���� �ν��Ͻ� ���� �� �ż� ���� 
    PlayerInfo PlayerInfo;

    int currentHpLevel;
    int currentDamageLevel;
    int currentSpeedLevel;

    public TMP_Text hpLevelText;
    public TMP_Text damageLevelText;
    public TMP_Text speedLevelText;

    // ���� +, - ��ư ���� �迭 
    GameObject[] optionButtons;

    // ���� ����� �� �ִ� ���� ����Ʈ 
    // Playerinfo�� �߰��ؾ� ��
    // int statPoint = PlayerInfo.statPoint 
    public int statPoint;
    public TMP_Text statPointText;
  

    // ���� ��ư 
    public GameObject saveButton;

    // �ڷΰ��� ��ư
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
        // ���� ��ȭ ���� ��������
        //currentHpLevel = PlayerInfo.hpReinforcementCount;
        //currentDamageLevel = PlayerInfo.attackDamageReinforcementCount;
        //currentSpeedLevel = PlayerInfo.speedReinforcementCount;

        currentHpLevel = 0;
        currentDamageLevel = 0;
        currentSpeedLevel = 0;

        // ���� ���� ȭ�鿡 ǥ�� 
        hpLevelText.text = currentHpLevel.ToString();
        damageLevelText.text = currentDamageLevel.ToString();
        speedLevelText.text = currentSpeedLevel.ToString();
        statPointText.text = statPoint.ToString();

        // ���ٿ� ��ư �迭(Ȱ��ȭ ��� ����)
        optionButtons = GameObject.FindGameObjectsWithTag("button");

        // ���� ��ư ��Ȱ��ȭ�� �ʱ�ȭ
        saveButton.GetComponent<Button>().interactable = false;

        // ��ȭ ��ư Ȱ��ȭ ���� �˻�
        ToggleBtnActive();
    }

    // ���� ��ư ������ �� 
    public void OnClickSaveBtn()
    {

   
        // ����� ���� �� ���� ����Ʈ PlayerInfo �� ���� 
        //PlayerInfo.hpReinforcementCount = int.Parse(hpLevelText.text);
        //PlayerInfo.attackDamageReinforcementCount = int.Parse(hpLevelText.text);
        //PlayerInfo.speedReinforcementCount = int.Parse(speedLevelText.text);
        //PlayerInfo.statPoint = statPoint;

        // ��ư Ȱ��ȭ �˻�
        ToggleBtnActive();

        // ���� ��ư ��Ȱ��ȭ
        saveButton.GetComponent<Button>().interactable = false;


    }

    // ��ư Ȱ��ȭ ���
    public void ToggleBtnActive()
    {
        Debug.Log("����!");

        // ���� ����Ʈ 0�̸�
        if (statPoint <= 0)
        {
            Debug.Log("��Ȱ��ȭ!");
            // ��ư ��Ȱ��ȭ
           foreach (GameObject button in optionButtons)
            {
                button.GetComponent<Button>().interactable = false;

                //enabled�� interactable ����
            }
        }

        // ���� ����Ʈ 1 �̻��̸�
        else 
        {
            Debug.Log("Ȱ��ȭ!");
            // ��ư Ȱ��ȭ
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
