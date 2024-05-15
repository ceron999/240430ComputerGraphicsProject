using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // 맵 프리팹
    // TODO: 장애물이 여러 종류가 있으면 배열로 처리.
    public GameObject obstaclePrefab; // 장애물 프리팹


    private Transform playerTransform;
    private float spawnZ = 0f;   // TODO: 변수명 변경
    private float groundLength;
    private float groundWidth;
    private int groundShawn = 5;

    private Queue<GameObject> groundQueue;

    void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        groundQueue = new Queue<GameObject>();
        groundLength = groundPrefab.transform.lossyScale.z;
        groundWidth = groundPrefab.transform.lossyScale.x;
        // Debug.Log(groundLength);
        for(int i = 0; i < groundShawn; ++i)
        {
            SpawnGround();
        }
    }

    void Update()
    {
        if(playerTransform.position.z - groundLength * 1.5 > spawnZ - groundShawn * groundLength)
        {
            SpawnGround();
            RemoveGround();
        }
    }

    void SpawnObstacle(GameObject ground)
    {
        GameObject obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.SetParent(ground.transform);

        // FIXME : 좌표 잘 모르겠음.
        float obstacleX = Random.Range(-groundWidth / 2, groundWidth / 2);
        float obstacleY = obstacle.transform.position.y;
        float obstacleZ = spawnZ + Random.Range(0, groundLength);

        obstacle.transform.position = new Vector3(obstacleX, obstacleY, obstacleZ);

    }

    // TODO : 생성된 ground 객체의 자식으로 Obstacle 생성.
    // 종으로 일정한 위치에 횡으로 랜덤한 위치에 Obstacle 생성.
    void SpawnGround()
    {
        GameObject ground = Instantiate(groundPrefab);
        groundQueue.Enqueue(ground);
        ground.transform.SetParent(transform);
        ground.transform.position = Vector3.forward * spawnZ;
        // TODO: 종으로 일정한 간격에 생성하기.
        SpawnObstacle(ground);
        spawnZ += groundLength;
    }

    private void RemoveGround()
    {
        Destroy(groundQueue.Dequeue());
    }
}
