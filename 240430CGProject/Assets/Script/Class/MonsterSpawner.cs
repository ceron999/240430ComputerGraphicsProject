using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    public float spawnRateMin = 0.1f;
    public float spawnRateMax = 5f;

    private float groundWidth = 450;

    private float spawnRate;
    private float timeAfterSpawn;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        timeAfterSpawn = 0;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    private void Update()
    {
        spawnRateMax = Mathf.Min(5f, 0.001f * player.transform.position.z);
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
    }

    void SpawnMonster()
    {
        float randomX = Random.Range(-groundWidth, groundWidth) / 2;
        int randomIdx = Random.Range(0, monsterPrefabs.Length);
        GameObject monster = Instantiate(monsterPrefabs[randomIdx],
                                         new Vector3(randomX, 0, transform.position.z),
                                         transform.rotation);
        monster.transform.SetParent(transform);

        // spawnRag 가 작을수록 몬스터가 더 빨리 생성됨.
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }
}
