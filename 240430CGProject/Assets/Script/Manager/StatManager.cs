using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    // statManager �ν��Ͻ� ����
    public static StatManager statManager;

    PlayerInfo PlayerInfo;

    int currentHpLevel;
    int currentDamageLevel;
    int currentSpeedLevel;

    public TMP_Text hpLevelText;
    public TMP_Text damageLevelText;
    public TMP_Text speedLevelText;

    // ��ư ���� �迭 ���� <Button> ������Ʈ ã�Ƽ� ��ȸ�ϸ� ��Ȱ��ȭ
    GameObject[] optionButtons;

    // ���� ����� �� �ִ� ���� ����Ʈ -> PlayerInfo ������ �߰��ؾ���
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

        //foreach (GameObject button in optionButtons)
        // { Debug.Log(button.name) ; }

        ToggleBtnActive();
    }

    // ���� ��ư ������ �� 
    void OnClickSaveBtn()
    {

   
        // ����� ���� �� ���� ����Ʈ PlayerInfo �� ���� 
        PlayerInfo.hpReinforcementCount = int.Parse(hpLevelText.text);
        PlayerInfo.attackDamageReinforcementCount = int.Parse(hpLevelText.text);
        PlayerInfo.speedReinforcementCount = int.Parse(speedLevelText.text);
        //PlayerInfo.statPoint = int.Parse(statPoint);
        saveBtn.SetActive(false);

        // ��ư Ȱ��ȭ �˻�
        ToggleBtnActive();
        

    }

    // ��ư Ȱ��ȭ ���
    public void ToggleBtnActive()
    {
        // ���� ����Ʈ 0�̸�
        if (statPoint <= 0)
        {
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
            // ��ư Ȱ��ȭ
            
     
  
        }

       
    }


}
