using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int level;                       //현재 레벨
    public float exp;                       //현재 경험치
    public float maxExp;                    //현재 경험치가 maxExp를 넘어가면 다음 레벨로 업한다. 

    public float[] runningRecord;           //달리기 기록

    public int hpReinforcementCount;                //체력 강화 횟수 
    public int attackDamageReinforcementCount;      //공격력 강화 횟수 
    public int speedReinforcementCount;             //속도 강화 횟수 

    public PlayerInfo()
    {
        level = 1;
        exp = 0;
        maxExp = 1000;

        runningRecord = new float[3];

        //상점에서 구매하지 않은 상태로 초기화
        hpReinforcementCount = 0;
        attackDamageReinforcementCount = 0;
        speedReinforcementCount = 0;
    }
}
