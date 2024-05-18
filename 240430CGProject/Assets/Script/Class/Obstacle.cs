using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody obstacleRigidbody;
    public float crushDmg = 2f; // obstacle damage TODO: change by level
    [SerializeField]
    Rigidbody playerRigid;


    // Start is called before the first frame update
    void Start()
    {
        obstacleRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (other.tag == "Player")
            {
                // 공격
                player.GetDamaged(crushDmg);
            }
        }
    }
}
