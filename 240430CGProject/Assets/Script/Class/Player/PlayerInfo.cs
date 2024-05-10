using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int money;                       //보유 금액

    public float[] runningRecord;           //달리기 기록

    public int weaponReinforcementCount;    //무기 강화 횟수 (0~5)
    public int armorReinforcementCount;     //방어구 강화 횟수 (0~5)
    public int shoesReinforcementCount;     //신발 강화 횟수 (0~5)

    public PlayerInfo()
    {
        money = 0;

        runningRecord = new float[3];

        //상점에서 구매하지 않은 상태로 초기화
        weaponReinforcementCount = 0;
        armorReinforcementCount = 0;
        shoesReinforcementCount = 0;
    }
}
