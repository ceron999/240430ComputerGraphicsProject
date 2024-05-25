using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    float spawnRateMin;
    float spawnRateMax;
    float spawnRateMaxLimit;
    float difficulty;

    private float groundWidth = 450;

    private float spawnRate;
    private float timeAfterSpawn;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        spawnRateMin = 1f;
        spawnRateMax = 10f;
        spawnRateMaxLimit = 5f;
        player = FindObjectOfType<Player>();
        timeAfterSpawn = 0;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;
            SpawnMonster();
        }
        difficulty = Mathf.Pow(
            0.95f, Mathf.FloorToInt(player.transform.position.z / 300f));
        spawnRateMax = Mathf.Max(spawnRateMaxLimit, difficulty * spawnRateMax);
    }

    void SpawnMonster()
    {
        float randomX = Random.Range(-groundWidth, groundWidth) / 2;
        int randomIdx = Random.Range(0, monsterPrefabs.Length);
        GameObject monster = Instantiate(monsterPrefabs[randomIdx],
                                         new Vector3(randomX, 0, transform.position.z),
                                         transform.rotation);
        monster.transform.SetParent(transform);

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }
}
