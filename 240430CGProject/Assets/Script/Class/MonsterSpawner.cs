using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    public float spawnRateMin = 1f;
    public float spawnRateMax = 5f;

    private float groundWidth = 450;

    private float spawnRate;
    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;
            SpawnMonster();
        }
    }

    void SpawnMonster()
    {
        float randomX = Random.Range(-groundWidth, groundWidth) / 2;
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        int randomIdx = Random.Range(0, monsterPrefabs.Length);
        GameObject monster = Instantiate(monsterPrefabs[randomIdx], spawnPosition, transform.rotation);
        monster.transform.SetParent(transform);
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }
}
