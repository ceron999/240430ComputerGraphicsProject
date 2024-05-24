using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // TODO: change by level
    public float speed = 0.00000000000000000001f; 
    public float hp = 1f;
    public float crushDmg = 3f;

    [SerializeField]
    Player player;
    [SerializeField]
    Rigidbody playerRigid;
    private Transform target; // 따라다닐 대상
    private CameraShaker cameraShaker;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        crushDmg = Random.Range(0f, player.transform.position.z * 0.01f);
        cameraShaker = Camera.main.GetComponent<CameraShaker>();
    }

    private void LateUpdate()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 몬스터가 플레이어와 접촉
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            hp -= player.playerStatus.attackDamage;
            // 공격
            player.GetDamaged(crushDmg);
            StartCoroutine(cameraShaker.Shake(.15f, 1f));
        }

        // 몬스터가 총에 맞았을 때
        if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);

            hp -= other.GetComponent<Bullet>().attackDamage;
        }
    }

    private void FixedUpdate()
    {
        target = FindObjectOfType<Player>().transform;
        transform.LookAt(new Vector3(target.position.x, 0, target.position.z));
        transform.Translate(Vector3.forward * speed);
        //monsterRigidbody.transform.LookAt(target);
        //monsterRigidbody.velocity = transform.forward * speed;
    }

    void Update()
    {
        //target = FindObjectOfType<Player>().transform;
        //monsterRigidbody.transform.LookAt(target);
        //monsterRigidbody.velocity = transform.forward * speed;
    }
}
