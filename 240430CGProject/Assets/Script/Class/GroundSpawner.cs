using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // 맵 프리팹
    public GameObject[] obstaclePrefabs; // 장애물 프리팹
    public GameObject monsterSpawnerPrefab; // 몬스터 스포너


    private Transform playerTransform;
    private float threshold = 0f;
    private float groundLength;
    private float roadWidth;
    private int groundShawn = 5;
    private int interval;
    private int nProduceObstacle = 5;

    private Queue<GameObject> groundQueue;

    void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        groundQueue = new Queue<GameObject>();
        groundLength = 300; // 300m
        interval = (int) (groundLength / nProduceObstacle);
        roadWidth = 100;
        Debug.Log(groundLength);
        for (int i = 0; i < groundShawn; ++i)
        {
            SpawnGround();
        }
    }

    void Update()
    {
        if (playerTransform.position.z - groundLength * 1.5 > threshold - groundShawn * groundLength)
        {
            SpawnGround();
            RemoveGround();
        }
    }

    // 종으로 일정한 간격 중 랜덤하게 선택해서 횡으로 랜덤하게 배치
    void SpawnObstacles(GameObject ground)
    {
        for (int i = 0; i < nProduceObstacle; ++i)
        {
            if (Random.value > 0.5f)
            {
                int idx = Random.Range(0, obstaclePrefabs.Length);
                GameObject obstacle = Instantiate(obstaclePrefabs[idx]);
                obstacle.transform.SetParent(ground.transform);

                float randomScale = Random.Range(5f, 8f);
                obstacle.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

                float randomRotation = Random.Range(-45f, 45f);
                obstacle.transform.rotation = Quaternion.Euler(0, randomRotation, 0);

                float obstacleX = Random.Range((-roadWidth + obstacle.transform.localScale.x),
                                                (roadWidth - obstacle.transform.localScale.x)) / 2;
                float obstacleY = obstacle.transform.position.y;
                float obstacleZ = threshold + interval * i;

                obstacle.transform.position = new Vector3(obstacleX, obstacleY, obstacleZ);
            }
        }
    }

    void SpawnGround()
    {
        GameObject ground = Instantiate(groundPrefab);
        groundQueue.Enqueue(ground);
        ground.transform.SetParent(transform);
        ground.transform.position = Vector3.forward * threshold;
        
        SpawnObstacles(ground);

        GameObject monsterSpawner = Instantiate(monsterSpawnerPrefab);
        monsterSpawner.transform.SetParent(ground.transform);
        monsterSpawner.transform.position = new Vector3(0, ground.transform.position.y,
                                                        ground.transform.position.z + groundLength / 2);

        threshold += groundLength;
    }

    private void RemoveGround()
    {
        Destroy(groundQueue.Dequeue());
    }
}
