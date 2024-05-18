using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public PlayerInfo playerInfo;           //player의 기록, 상점에서 도구를 얼마나 강화하였는지 확인 가능

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadSavaData();
    }

    //게임을 시작할 때 SaveData가 존재하는지 확인한다.
    //if(saveData가 없음)      -> PlayerInfo 생성자를 통해 새로운 SavaData를 만들어서 UserData/ 에 저장한다.
    //else                     -> UserData/SaveData.json 파일을 불러와 playerInfo에 저장한다. 
    void LoadSavaData()
    {
        //초회차 플레이 일 경우 UserData가 존재하지 않으므로 생성자를 만들어 저장한 후 UserData를 만든다. 
        if(JsonManager.LoadSaveData() == null)
        {
            playerInfo = new PlayerInfo();
            JsonManager.SaveJson<PlayerInfo>(playerInfo, "SaveData");
        }
        else
        {
            Debug.Log("세이브 데이터 존재");
            playerInfo = JsonManager.LoadSaveData();
        }
    }
}
