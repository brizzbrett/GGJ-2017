using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKatana : MonoBehaviour {

    float damage = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);

            //Play ding sound
        }
        else if (hit.gameObject.CompareTag("Wall"))
        {
            hit.collider.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

            //Debug.Log(hit.gameObject.name + " hit. Health: " + hit.gameObject.GetComponent<ApplyHit>().hitPoints);
        }
        else
        {
            Debug.Log("Hit somethin else?");
        }
    }
}
