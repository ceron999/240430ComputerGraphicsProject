using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int money;                       //���� �ݾ�

    public float[] runningRecord;           //�޸��� ���

    public int weaponReinforcementCount;    //���� ��ȭ Ƚ�� (0~5)
    public int armorReinforcementCount;     //�� ��ȭ Ƚ�� (0~5)
    public int shoesReinforcementCount;     //�Ź� ��ȭ Ƚ�� (0~5)

    public PlayerInfo()
    {
        money = 0;

        runningRecord = new float[3];

        //�������� �������� ���� ���·� �ʱ�ȭ
        weaponReinforcementCount = 0;
        armorReinforcementCount = 0;
        shoesReinforcementCount = 0;
    }
}
