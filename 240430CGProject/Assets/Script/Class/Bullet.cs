using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float attackDamage;
    Rigidbody bulletRigid;

    private void Start()
    {
        StartCoroutine(DestoryThisBullet());
    }

    public void ShootBullet(Vector3 getMoveDir)
    {
        bulletRigid = this.GetComponent<Rigidbody>();
        bulletRigid.velocity = getMoveDir.normalized * 600;
    }

    IEnumerator DestoryThisBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
