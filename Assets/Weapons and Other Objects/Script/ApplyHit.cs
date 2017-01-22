using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float hitPoints = 1.0f;
 
    void ApplyDamage(float damage)
    {
        if (hitPoints <= 0.0)
            return;
 
        hitPoints -= damage;
      
        if(hitPoints <= 0.0)
        {
            Invoke("DelayedDetonate",0);
        }
     } 
 
     void DelayedDetonate(){
        this.GetComponent<Player>().Death();
     }
}
