using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // TODO: change by level
    public float speed = 0.00000001f; 
    public float hp = 10f;
    public float crushDmg = 3f;

    [SerializeField]
    Rigidbody playerRigid;
    private Transform target; // 발사할 대상.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 몬스터가 플레이어와 접촉
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            // 공격
            player.GetDamaged(crushDmg);
        }

        // 몬스터가 총에 맞았을 때
        if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);

            hp -= other.GetComponent<Bullet>().attackDamage;

            if(hp <= 0)
            {
                Destroy(gameObject);
            }
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
