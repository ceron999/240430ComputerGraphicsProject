using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneBtn : MonoBehaviour
{
    [SerializeField]
    GameObject rankingUIParent;

    //startBtn�� ������ IngameScene���� �̵��մϴ�.
    public void ClickStartBtn()
    {
        SceneManager.LoadScene("IngameScene");
    }

    //RankingBtn�� ������ Ranking UI�� ŵ�ϴ�. 
    public void ClickRankingBtn()
    {
        rankingUIParent.SetActive(true);
    }

    public void ClickExitRankingUIBTN()
    {
        rankingUIParent.SetActive(false);
    }

    //StoreBtn�� Ŭ���ϸ� StoreScene���� �̵��մϴ�.
    public void ClickStoreBtn()
    {
        SceneManager.LoadScene("StoreScene");
    }

    //ExitBtn�� ������ ���α׷��� �����մϴ�.
    public void ClickExitBtn()
    {
        Application.Quit();
    }
}
