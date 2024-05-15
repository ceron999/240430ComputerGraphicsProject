using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody obstacleRigidbody;
    public float crushDmg = 2f; // obstacle damage TODO: change by level
    [SerializeField]
    PlayerStatus playerStatus;              //player가 가지고있는 Ingame Data
    [SerializeField]
    Rigidbody playerRigid;


    // Start is called before the first frame update
    void Start()
    {
        obstacleRigidbody = GetComponent<Rigidbody>();
        playerStatus = new PlayerStatus();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                playerStatus.hp -= crushDmg;
                if(playerStatus.hp == 0)
                {
                    player.Die();
                }
                // 무적상태
                // player.GodMode();
            }
        }
    }
}
