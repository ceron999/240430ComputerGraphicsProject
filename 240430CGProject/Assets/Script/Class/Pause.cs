using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool IsPause;
    // 일시정지 시 보여줄 메뉴창
    public GameObject PauseMenu;

    public GameObject PauseButton;
    
    // IsPause 플래그와 일시정지 메뉴 false로 초기화
    private void Start()
    {
        IsPause = false;
        PauseMenu.SetActive(false);
    }

    // 모든 활동이 멈추고 일시정지 UI 표시
    public void OnClickPause()
    {
        // 시간 정지
        Time.timeScale = 0;
        IsPause = true;
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);

}

    // 이어서 플레이
    public void OnClickResume()
    {
        Time.timeScale = 1;
        IsPause = false;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }

    // 처음부터 다시 시작
    public void OnClickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("IngameScene");
    }

    // 시작화면으로 이동
    public void OnClickMainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }


}
