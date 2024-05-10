using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int level;                       //���� ����
    public float exp;                       //���� ����ġ
    public float maxExp;                    //���� ����ġ�� maxExp�� �Ѿ�� ���� ������ ���Ѵ�. 

    public float[] runningRecord;           //�޸��� ���

    public int hpReinforcementCount;                //ü�� ��ȭ Ƚ�� 
    public int attackDamageReinforcementCount;      //���ݷ� ��ȭ Ƚ�� 
    public int speedReinforcementCount;             //�ӵ� ��ȭ Ƚ�� 

    public PlayerInfo()
    {
        level = 1;
        exp = 0;
        maxExp = 1000;

        runningRecord = new float[3];

        //�������� �������� ���� ���·� �ʱ�ȭ
        hpReinforcementCount = 0;
        attackDamageReinforcementCount = 0;
        speedReinforcementCount = 0;
    }
}
