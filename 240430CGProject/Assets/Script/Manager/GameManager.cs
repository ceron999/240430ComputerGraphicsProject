using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public PlayerInfo playerInfo;           //player의 기록, 상점에서 도구를 얼마나 강화하였는지 확인 가능
    public float newRacord;                 //stage가 종료되고 기록된 데이터로 3위보다 높은 숫자면 교체할 예정

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
        
    }

    void Update()
    {
        
    }
}
