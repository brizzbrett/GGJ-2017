using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTomahawk : MonoBehaviour {

    public Transform projectile;
    public float bulletSpeed = 20;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireOneTomahawk();
        }
    }
    void FireOneTomahawk()
    {
        Transform clone;
        Vector3 localOffset = transform.position;

        clone = Instantiate(projectile, localOffset, transform.rotation);

        StartCoroutine(this.WaitToReturn());

        this.gameObject.SetActive(false);

        clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * bulletSpeed);
    }

    IEnumerator WaitToReturn()
    {
        yield return new WaitForSeconds(4.0f);
        this.gameObject.SetActive(true);
    }
}
