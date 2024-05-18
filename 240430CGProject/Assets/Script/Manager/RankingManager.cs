using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{
    // ��� �ҷ����� 
    PlayerInfo playerInfo;
    float[] runningRecordRanking;

    // 1, 2, 3�� �ؽ�Ʈ 
    public TMP_Text firstPlace;
    public TMP_Text secondPlace;
    public TMP_Text thirdPlace;

    private void Start()
    {
        // 1, 2, 3�� ȭ�鿡 ��� 
        runningRecordRanking = playerInfo.runningRecord;
        firstPlace.text = runningRecordRanking[0].ToString() + "m";
        secondPlace.text = runningRecordRanking[1].ToString() + "m";
        thirdPlace.text = runningRecordRanking[2].ToString() + "m";
        
    }

    public void GoBack()
    {
        SceneManager.LoadScene("StartScene");
    }

   
}
