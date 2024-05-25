using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatus
{
    public float hp;                //플레이어의 체력

    public float forwardspeed;      //전방으로 달리는 스피드
    public float sidespeed;         //좌우로 이동하는 스피드
    public float maxForwardSpeed;   //만일 전방 속도가 일정 수치 이상 오르면 더 이상 늘어나지 않도록 방지하는 함수
    public float maxsideSpeed;      //만일 좌우로 이동하는 속도가 일정 수치 이상 오르면 더 이상 늘어나지 않도록 방지하는 함수

    public float attackDamage;      //플레이어 공격력

    public float nowRecord;

    public PlayerStatus()
    {
        hp = 10;

        forwardspeed = 500;
        sidespeed = 50;
        maxForwardSpeed = 500;
        maxsideSpeed = 50;

        attackDamage = 1;
    }
}
