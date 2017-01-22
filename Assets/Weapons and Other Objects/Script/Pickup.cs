using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int value;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (!coll.gameObject.GetComponent<Player>().hasWeapon)
            {
                coll.gameObject.GetComponent<Player>().weapons[this.value].SetActive(true);

                Destroy(this.gameObject);
            }
        }
    }
}
