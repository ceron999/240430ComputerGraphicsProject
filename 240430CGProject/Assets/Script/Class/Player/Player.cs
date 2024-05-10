using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerStatus playerStatus;              //player�� �������ִ� Ingame Data
    [SerializeField]
    Rigidbody playerRigid;

    //Stage Variables
    bool isStageStart = false;              //stage�� 1�� �ڿ� �����ϹǷ� stage�� ������ �� �¿�� �̵� �����ϵ��� �����ϴ� bool

    private void Start()
    {
        playerStatus = new PlayerStatus();
        StartPlayerMove();
    }

    void Update()
    {
        MoveSide();
    }

    //�������� �̵��ϱ� �����ϴ� �Լ�
    void StartPlayerMove()
    {
        StartCoroutine(StartPlayerMoveCoroutine());
    }

    IEnumerator StartPlayerMoveCoroutine()
    {
        yield return new WaitForSeconds(1f);
        isStageStart = true;                    //stage�� ���۵Ǿ����Ƿ� �¿�� �̵� ����

        while (playerRigid.velocity.z <= playerStatus.maxForwardSpeed)
        {
            playerRigid.AddForce(new Vector3(0, 0, playerStatus.forwardspeed));
            yield return null;
        }

        playerRigid.velocity = new Vector3(playerRigid.velocity.x, playerRigid.velocity.y, playerStatus.maxForwardSpeed);
    }

    //�¿�� �̵��ϴ� �Լ�
    private void MoveSide()
    {
        //Player�� �̵��ϱ� �����ϸ� �¿�� �̵� �����ϵ��� ������ ����
        if (isStageStart)
        {
            //a�� ������ �������� �̵�
            if (Input.GetKey(KeyCode.A))
            {
                if (playerRigid.velocity.x > playerStatus.maxsideSpeed * (-1))
                {
                    Debug.Log("Move Left");
                    playerRigid.AddForce(new Vector3(playerStatus.sidespeed * (-1), 0, 0));
                }
            }

            //d�� ������ ���������� �̵�
            else if (Input.GetKey(KeyCode.D))
            {
                if (playerRigid.velocity.x < playerStatus.maxsideSpeed)
                {
                    Debug.Log("Move Right");
                    playerRigid.AddForce(new Vector3(playerStatus.sidespeed, 0, 0));
                }
            }

            //�ƹ��͵� ������ ���� ������ �״�� ����
            else
            {
                playerRigid.velocity = new Vector3(0, 0, playerStatus.maxForwardSpeed);
            }
            Debug.Log(playerRigid.velocity);
        }
    }
}
