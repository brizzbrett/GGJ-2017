using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {
    public Transform projectile;
    public float bulletSpeed = 20;

	void Start () 
    {
    
	}

    void Update () 
    {   
        if (Input.GetButtonDown("Fire1")) 
        {
            FireOneProjectile();
        }
    }
    void FireOneProjectile()
    {
        Transform clone;
        Vector3 localOffset = transform.position;

        clone = Instantiate(projectile, localOffset, transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * bulletSpeed);
    }
}
