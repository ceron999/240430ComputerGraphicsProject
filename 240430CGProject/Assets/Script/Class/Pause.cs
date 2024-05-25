using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool IsPause;
    // �Ͻ����� �� ������ �޴�â
    public GameObject PauseMenu;

    public GameObject PauseButton;
    
    // IsPause �÷��׿� �Ͻ����� �޴� false�� �ʱ�ȭ
    private void Start()
    {
        IsPause = false;
        PauseMenu.SetActive(false);
    }

    // ��� Ȱ���� ���߰� �Ͻ����� UI ǥ��
    public void OnClickPause()
    {
        // �ð� ����
        Time.timeScale = 0;
        IsPause = true;
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);

}

    // �̾ �÷���
    public void OnClickResume()
    {
        Time.timeScale = 1;
        IsPause = false;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }

    // ó������ �ٽ� ����
    public void OnClickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("IngameScene");
    }

    // ����ȭ������ �̵�
    public void OnClickMainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }


}
