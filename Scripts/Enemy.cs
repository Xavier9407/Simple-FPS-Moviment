using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float life = 30f;

    private void Update()
    {
        if (life <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Bullet")
        {
            //float damage = coll.GetComponent<GunController>().damage;
            TakeDamage(10);
        }
    }

    private void TakeDamage(float damage)
    {
        life -= damage;
        Debug.Log(life);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
