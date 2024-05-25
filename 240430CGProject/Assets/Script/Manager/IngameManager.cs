using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IngameManager : MonoBehaviour
{
    //stage가 1초 뒤에 시작하므로 stage가 시작한 뒤 좌우로 이동 가능하도록 설정하는 bool
    public bool isStageStart;
    public bool isStageEnd;

    [SerializeField]
    TextMeshProUGUI recordText;                 //현재 기록이 얼만큼인지 나타내는 변수
    public float nowRecord = 0;
    [SerializeField]
    Transform playerTransform;

    //난이도 조절을 위해 받는 변수
    [SerializeField]
    Player player;
    int nowDifficulty = 0;

    //게임 종료 후
    [SerializeField]
    GameObject gameEndUIParent;
    [SerializeField]
    TextMeshProUGUI endRecordText;

    private void Start()
    {
        Debug.Log("1");
        recordText.text = "Record : " + nowRecord.ToString();
    }

    private void Update()
    {
        if(!isStageEnd)
            UpdateRecordText();
    }

    //현재 기록을 매 초 증가시키고 UI에 표시합니다. 
    void UpdateRecordText()
    {
        if (isStageStart)
        {
            nowRecord = playerTransform.position.z;
            SetDifficultyUp();
            recordText.text = "Record : \n" + (Mathf.FloorToInt(nowRecord)).ToString() + "m";
        }
    }
    
    //게임이 종료되고 종료 UI를 킵니다. 
    public void GameEnd()
    {
        isStageEnd = true;
        gameEndUIParent.SetActive(true);

        endRecordText.text = "Record : " + (Mathf.FloorToInt(nowRecord)).ToString() + "m";

        SetPlayerInfo();
    }

    void SetPlayerInfo()
    {
        GameManager.gameManager.playerInfo.exp += Mathf.FloorToInt(nowRecord);

        if(GameManager.gameManager.playerInfo.exp >= GameManager.gameManager.playerInfo.maxExp)
        {
            while (GameManager.gameManager.playerInfo.exp >= GameManager.gameManager.playerInfo.maxExp)
            {
                GameManager.gameManager.playerInfo.exp -= GameManager.gameManager.playerInfo.maxExp;
                GameManager.gameManager.playerInfo.level++;
            }
        }

        SetRunningRecord();

        JsonManager.SaveJson<PlayerInfo>(GameManager.gameManager.playerInfo, "SaveData");
    }

    //새로 갱신한 
    void SetRunningRecord()
    {
        float[] runningRecordArr = new float[4];

        for (int i = 0; i < GameManager.gameManager.playerInfo.runningRecord.Length; i++)
            runningRecordArr[i] = GameManager.gameManager.playerInfo.runningRecord[i];
        runningRecordArr[3] = Mathf.FloorToInt(nowRecord);

        for (int i = 0; i < runningRecordArr.Length - 1; i++)
        {
            Debug.Log(i);
            int tempIndex = i;
            for(int j = i + 1; j < runningRecordArr.Length; j++)
            {
                if (runningRecordArr[tempIndex] <= runningRecordArr[j])
                    tempIndex = j;
            }

            float tempRecord = runningRecordArr[tempIndex];
            runningRecordArr[tempIndex] = runningRecordArr[i];
            runningRecordArr[i] = tempRecord;


            Debug.Log(i + "회차 1 : " + runningRecordArr[0]);
            Debug.Log(i + "회차 2 : " + runningRecordArr[1]);
            Debug.Log(i + "회차 3 : " + runningRecordArr[2]);
            Debug.Log(i + "회차 4 : " + runningRecordArr[3]);
        }

        //정렬한 Record 다시 삽입
        for (int i = 0; i < GameManager.gameManager.playerInfo.runningRecord.Length; i++)
        {
            GameManager.gameManager.playerInfo.runningRecord[i] = runningRecordArr[i];
        }
    }

    //nowRecord가 1000의 배수가 될때마다 이동속도 50 증가(난이도 상승)
    void SetDifficultyUp()
    {
        if ((int)(nowRecord / 1000) <= nowDifficulty)
            return;

        player.SetPlayerSpeed();
    }

    public void ClickExitBtn()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("StartScene");
    }


}
