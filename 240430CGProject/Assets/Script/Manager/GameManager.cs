using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public PlayerInfo playerInfo;           //player�� ���, �������� ������ �󸶳� ��ȭ�Ͽ����� Ȯ�� ����
    public float newRacord;                 //stage�� ����ǰ� ��ϵ� �����ͷ� 3������ ���� ���ڸ� ��ü�� ����

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
