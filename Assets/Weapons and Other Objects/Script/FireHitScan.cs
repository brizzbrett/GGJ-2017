using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHitScan : MonoBehaviour {

    float damage;
    public int distance = 20;

	// Use this for initialization
	void Start () 
    {
        damage = 1.0f;
	}
	
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Clicking");
            FireOneShot();
            SoundManager.StartSound(this.GetComponent<Sound>());
            GameManager.instance.EchoManager.AddPulse(this.gameObject.transform.position, 1, 3, 100);
        }
    }
 
    void FireOneShot()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Vector3 localOffset = transform.position + transform.right;

        if (Physics.Raycast(localOffset, direction, out hit, distance))
        {
            Debug.DrawLine(localOffset, hit.point, Color.cyan, 2, true);
            Debug.Log("Hit " + hit.collider.gameObject.name);

            hit.collider.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

            GameManager.instance.EchoManager.AddPulse(hit.collider.gameObject.transform.position, 1, 3, 100);

        }
        else
        {
            Debug.Log("Missed");
        }
    }
}


