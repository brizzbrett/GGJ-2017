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
            Debug.Log("Proj sound");
            if (GetComponent<Sound>())
                SoundManager.StartSound(GetComponent<Sound>());
            else
            {
                Debug.Log("No SOUND~!");
            }
        }
    }
    void FireOneProjectile()
    {
        Transform clone;
        Transform projetile = transform.GetChild(0);
        Vector3 localOffset = projectile.position;

        //clone = Instantiate(projectile, localOffset, transform.rotation);
        clone = PhotonNetworkController.createNetObject(projectile.name, transform.position, transform.rotation).transform;        
        clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * bulletSpeed);
    }
}
