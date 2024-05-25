using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{

    // ���� �� �ؽ�Ʈ
    public TMP_Text hpLevelText;
    public TMP_Text damageLevelText;
    public TMP_Text speedLevelText;

    public int currentHpLevel;
    public int currentDamageLevel;
    public int currentSpeedLevel;

    // ���� +, - ��ư ���� �迭 
    GameObject[] optionButtons;

    // ���� ����� �� �ִ� ���� ����Ʈ 
    public int statPoint;
    public TMP_Text statPointText;
  

    // ���� ��ư 
    public GameObject saveButton;

    // �ڷΰ��� ��ư
    public GameObject goBackButton;


    void Start()
    {
        // ���� ��ȭ ���� ��������
        currentHpLevel = GameManager.gameManager.playerInfo.hpReinforcementCount;
        currentDamageLevel = GameManager.gameManager.playerInfo.attackDamageReinforcementCount;
        currentSpeedLevel = GameManager.gameManager.playerInfo.speedReinforcementCount;
        statPoint = GameManager.gameManager.playerInfo.level - (currentHpLevel + currentDamageLevel + currentSpeedLevel);


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
        GameManager.gameManager.playerInfo.hpReinforcementCount = currentHpLevel;
        GameManager.gameManager.playerInfo.attackDamageReinforcementCount = currentDamageLevel;
        GameManager.gameManager.playerInfo.speedReinforcementCount = currentSpeedLevel;
        GameManager.gameManager.playerInfo.statPoint = statPoint;
        JsonManager.SaveJson<PlayerInfo>(GameManager.gameManager.playerInfo, "SaveData");


        // ��ư Ȱ��ȭ �˻�
        ToggleBtnActive();

        // ���� ��ư ��Ȱ��ȭ
        saveButton.GetComponent<Button>().interactable = false;
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
            }
        }
        // ���� ����Ʈ 1 �̻��̸�
        else 
        {
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

    void saveBtnToggle()
    {
        // ���� ��ư Ȱ��ȭ
        if (saveButton.GetComponent<Button>().interactable == false)
        {
            saveButton.GetComponent<Button>().interactable = true;
        }
    }

    // �� �ɼ� �� ���� ��/�ٿ� ��ư Ŭ�� ��

    public void HpLevelUp()
    {
        // ��������Ʈ�� 0�� �ƴϸ� ����
        if (statPoint != 0)
        {
            // ���� +1
            currentHpLevel+= 1;
            hpLevelText.text = currentHpLevel.ToString();

            // ���� ����Ʈ -1
            statPoint -= 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }

    public void HpLevelDown()
    {
        // ���� ������ 0�� �ƴ� ��� ����
        if (currentHpLevel != 0)
        {
            // ���� ���� -1
            currentHpLevel -= 1;
            hpLevelText.text = currentHpLevel.ToString();

            // ��������Ʈ +1
            statPoint += 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle() ;

        }

    }

    // ���ݷ� ��ư
    public void DamageLevelUp()
    {
        // ��������Ʈ�� 0�� �ƴϸ� ����
        if (statPoint != 0)
        {
            // ���� +1
            currentDamageLevel += 1;
            damageLevelText.text = currentDamageLevel.ToString();

            // ���� ����Ʈ -1
            statPoint -= 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }

    public void DamageLevelDown()
    {
        // ���� ������ 0�� �ƴ� ��� ����
        if (currentDamageLevel != 0)
        {
            // ���� ���� -1
            currentDamageLevel -= 1;
            damageLevelText.text = currentDamageLevel.ToString();

            // ��������Ʈ +1
            statPoint += 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }


    // �̵��ӵ� ��ư
    public void SpeedLevelUp()
    {
        // ��������Ʈ�� 0�� �ƴϸ� ����
        if (statPoint != 0)
        {
            // ���� +1
            currentSpeedLevel += 1;
            speedLevelText.text = currentSpeedLevel.ToString();

            // ���� ����Ʈ -1
            statPoint -= 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }

    public void SpeedDownBtn()
    {
        // ���� ������ 0�� �ƴ� ��� ����
        if (currentSpeedLevel != 0)
        {
            // ���� ���� -1
            currentSpeedLevel -= 1;
            speedLevelText.text = currentSpeedLevel.ToString();

            // ��������Ʈ +1
            statPoint += 1;
            statPointText.text = statPoint.ToString();

            saveBtnToggle();
        }
    }
}
