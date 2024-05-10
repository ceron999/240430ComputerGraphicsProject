using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatus
{
    public float hp;        //플레이어의 체력

    public float forwardspeed;     //플레이어 전방으로 달리는 스피드
    public float sidespeed;     //플레이어 좌우로 이동하는 스피드
    public float maxForwardSpeed;  //만일 전방 속도가 일정 수치 이상 오르면 더 이상 늘어나지 않도록 방지하는 함수
    public float maxsideSpeed;  //만일 좌우로 이동하는 속도가 일정 수치 이상 오르면 더 이상 늘어나지 않도록 방지하는 함수

    public float attackDamage;  //플레이어 공격력

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
