using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float crushDmg;
    [SerializeField]
    Player player;

    private CameraShaker cameraShaker;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        crushDmg = Random.Range(0f, player.transform.position.z * 0.01f);
        cameraShaker = Camera.main.GetComponent<CameraShaker>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetDamaged(crushDmg);
            StartCoroutine(cameraShaker.Shake(.15f, 1f));
        }
    }
}
