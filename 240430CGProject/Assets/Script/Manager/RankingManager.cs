using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{
    static GameManager gameManager;
    // 기록 불러오기 
    float[] runningRecordRanking;

    // 1, 2, 3등 텍스트 
    public TMP_Text firstPlace;
    public TMP_Text secondPlace;
    public TMP_Text thirdPlace;

    private void Start()
    {
        // 1, 2, 3등 화면에 출력 
        runningRecordRanking = GameManager.gameManager.playerInfo.runningRecord;
        firstPlace.text = runningRecordRanking[0].ToString() + "m";
        secondPlace.text = runningRecordRanking[1].ToString() + "m";
        thirdPlace.text = runningRecordRanking[2].ToString() + "m";
        
    }

    public void GoBack()
    {
        SceneManager.LoadScene("StartScene");
    }


   
}
