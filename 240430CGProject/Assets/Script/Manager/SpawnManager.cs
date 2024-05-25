using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    GameObject groundSpawner;
    [SerializeField]
    GameObject obstacleSpawner;
    [SerializeField]
    GameObject monsterSpawner;

    GameObject monsterSpawnerInstance;
    void Start()
    {
        GameObject groundSpawnerInstance = Instantiate(groundSpawner);
        groundSpawnerInstance.transform.position = new Vector3(0, 0, 0);
        monsterSpawnerInstance = Instantiate(monsterSpawner);
        monsterSpawnerInstance.transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        monsterSpawnerInstance.transform.position = new Vector3(
            0, 0, playerTransform.position.z + (300));
    }
}
