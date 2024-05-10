using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerStatus playerStatus;              //player가 가지고있는 Ingame Data
    [SerializeField]
    Rigidbody playerRigid;

    //Stage Variables
    bool isStageStart = false;              //stage가 1초 뒤에 시작하므로 stage가 시작한 뒤 좌우로 이동 가능하도록 설정하는 bool

    private void Start()
    {
        playerStatus = new PlayerStatus();
        StartPlayerMove();
    }

    void Update()
    {
        MoveSide();
    }

    //전방으로 이동하기 시작하는 함수
    void StartPlayerMove()
    {
        StartCoroutine(StartPlayerMoveCoroutine());
    }

    IEnumerator StartPlayerMoveCoroutine()
    {
        yield return new WaitForSeconds(1f);
        isStageStart = true;                    //stage가 시작되었으므로 좌우로 이동 가능

        while (playerRigid.velocity.z <= playerStatus.maxForwardSpeed)
        {
            playerRigid.AddForce(new Vector3(0, 0, playerStatus.forwardspeed));
            yield return null;
        }

        playerRigid.velocity = new Vector3(playerRigid.velocity.x, playerRigid.velocity.y, playerStatus.maxForwardSpeed);
    }

    //좌우로 이동하는 함수
    private void MoveSide()
    {
        //Player가 이동하기 시작하면 좌우로 이동 가능하도록 조건을 걸음
        if (isStageStart)
        {
            //a를 누르면 왼쪽으로 이동
            if (Input.GetKey(KeyCode.A))
            {
                if (playerRigid.velocity.x > playerStatus.maxsideSpeed * (-1))
                {
                    Debug.Log("Move Left");
                    playerRigid.AddForce(new Vector3(playerStatus.sidespeed * (-1), 0, 0));
                }
            }

            //d를 누르면 오른쪽으로 이동
            else if (Input.GetKey(KeyCode.D))
            {
                if (playerRigid.velocity.x < playerStatus.maxsideSpeed)
                {
                    Debug.Log("Move Right");
                    playerRigid.AddForce(new Vector3(playerStatus.sidespeed, 0, 0));
                }
            }

            //아무것도 누르고 있지 않으면 그대로 직진
            else
            {
                playerRigid.velocity = new Vector3(0, 0, playerStatus.maxForwardSpeed);
            }
            Debug.Log(playerRigid.velocity);
        }
    }
}
