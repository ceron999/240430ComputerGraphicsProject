using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneBtn : MonoBehaviour
{
    [SerializeField]
    GameObject rankingUIParent;

    //startBtn을 누르면 IngameScene으로 이동합니다.
    public void ClickStartBtn()
    {
        SceneManager.LoadScene("IngameScene");
    }

    //RankingBtn을 누르면 Ranking UI를 킵니다. 
    public void ClickRankingBtn()
    {
        SceneManager.LoadScene("RankingScene");
    }

    //StatBtn을 클릭하면 StoreScene으로 이동합니다.
    public void ClickStatBtn()
    {
        SceneManager.LoadScene("StatScene");
    }

    //ExitBtn을 누르면 프로그램을 종료합니다.
    public void ClickExitBtn()
    {
        Application.Quit();
    }
}
