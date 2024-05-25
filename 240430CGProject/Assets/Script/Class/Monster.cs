using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    float baseSpeed = 1f;
    float speed;
    float speedLimit = 3f;
    float baseHP = 1f; // = player default attack Dmg
    float hp;
    float baseCrushDmg = 1f; // = 1/10 * player default HP
    float crushDmg;

    [SerializeField]
    Player player;
    [SerializeField]
    Rigidbody playerRigid;
    private Transform target; // 따라다닐 대상
    private CameraShaker cameraShaker;

    public Animator animator;


    [SerializeField]
    GameObject hpBarParent;
    [SerializeField]
    Image hpBarImage;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        target = FindObjectOfType<Player>().transform;
        animator = GetComponent<Animator>();       


        hp = baseHP * Mathf.Pow(1.1f, player.transform.position.z / 300f);
        crushDmg = Random.Range(0f,
            baseCrushDmg * Mathf.Pow(1.1f,
                Mathf.FloorToInt(player.transform.position.z / 300f)));
        speed = 1.3f;


        cameraShaker = Camera.main.GetComponent<CameraShaker>();
        // 몬스터가 옆이나 뒤에서 생성되면 제거
        if(transform.position.z <= player.transform.position.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hp >= 0)
        {
            // 몬스터가 플레이어와 접촉
            if (other.tag == "Player")
            {
                hp = 0;
                gameObject.GetComponent<SphereCollider>().enabled = false;
                Player player = other.GetComponent<Player>();
                animator.SetTrigger("Contact");

                // 공격
                player.GetDamaged(crushDmg);
                //StartCoroutine(cameraShaker.Shake(.15f, 1f));
            }

            // 몬스터가 총에 맞았을 때
            if (other.tag == "Bullet")
            {
                float dmg = other.GetComponent<Bullet>().attackDamage;
                Destroy(other.gameObject);

                hp -= dmg;
                if (hp <= 0)
                {
                    animator.SetTrigger("Die");
                    gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                else
                {
                    animator.SetTrigger("Attacked");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (hp > 0)
        {
            transform.LookAt(new Vector3(target.position.x, 0, target.position.z + 5));
            transform.Translate(Vector3.forward * speed);
        }
    }
}
