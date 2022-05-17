using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Rigidbody bullet;
    [SerializeField] Transform barrelLocation;
    

    [Header("Gun Config")]
    [SerializeField] public float damage = 10f;
    [SerializeField] float bulletForce = 100f;

   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }

    void Shoot()
    {
        Rigidbody clone;
        clone = Instantiate(bullet, barrelLocation.position, barrelLocation.rotation);
        clone.velocity = transform.TransformDirection(Vector3.forward * bulletForce);

        Destroy(clone, 2f);


    }

   
}
