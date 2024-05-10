using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatus
{
    public float hp;        //�÷��̾��� ü��

    public float forwardspeed;     //�÷��̾� �������� �޸��� ���ǵ�
    public float sidespeed;     //�÷��̾� �¿�� �̵��ϴ� ���ǵ�
    public float maxForwardSpeed;  //���� ���� �ӵ��� ���� ��ġ �̻� ������ �� �̻� �þ�� �ʵ��� �����ϴ� �Լ�
    public float maxsideSpeed;  //���� �¿�� �̵��ϴ� �ӵ��� ���� ��ġ �̻� ������ �� �̻� �þ�� �ʵ��� �����ϴ� �Լ�

    public float attackDamage;  //�÷��̾� ���ݷ�

    public PlayerStatus()
    {
        hp = 10;

        forwardspeed = 3;
        sidespeed = 3;
        maxForwardSpeed = 5;
        maxsideSpeed = 3;

        attackDamage = 1;
    }
}
