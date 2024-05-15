using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // TODO: change by level
    public float speed = 1f; 
    public float hp = 10f;
    public float crushDmg = 3f;

    private Rigidbody monsterRigidbody;

    [SerializeField]
    PlayerStatus playerStatus;              //player가 가지고있는 Ingame Data
    [SerializeField]
    Rigidbody playerRigid;
    private Transform target; // 발사할 대상.

    // Start is called before the first frame update
    void Start()
    {
        monsterRigidbody = GetComponent<Rigidbody>();
        playerStatus = new PlayerStatus();

        //TODO: Update에서 계속 플레이어 방향으로 수정.
        // monsterRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 몬스터가 플레이어와 접촉
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            // 공격
            playerStatus.hp -= crushDmg;
           
            if (playerStatus.hp == 0)
            {
                player.Die();
            }
            // 무적상태
            // player.GodMode();
        }

        // 몬스터가 총에 맞았을 때
        if(other.tag == "Bullet")
        {
            hp -= playerStatus.attackDamage;
            if(hp == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        target = FindObjectOfType<Player>().transform;
        monsterRigidbody.transform.LookAt(target);
        monsterRigidbody.velocity = transform.forward * speed;
    }
}
