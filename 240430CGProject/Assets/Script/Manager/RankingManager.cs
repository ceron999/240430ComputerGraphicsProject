using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.gameManager.playerInfo.weaponReinforcementCount
    }

    void PlusCount()
    {
        GameManager.gameManager.playerInfo.weaponReinforcementCount++;
    }
}
