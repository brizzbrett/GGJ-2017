using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitCheck : MonoBehaviour {

    float damage;
    public AudioClip blast;

    public float timeToLive = 3.0f;
    public bool isGrenade = false;
    public bool isTomahawk = false;

    public float tomaSpeed = 20;

    float closeAreaEffect = 5f;
    float mediumAreaEffect  = 10;
    float farAreaEffect  = 15;

    GameObject clone;
	void Start () 
    {
        damage = 1.0f;
	}
	
	void Update () 
    {
        Destroy(this.gameObject, timeToLive);

	}

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            hit.collider.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

            Debug.Log(hit.gameObject.name + " hit. Health: " + hit.gameObject.GetComponent<ApplyHit>().hitPoints);
        }
        if (hit.gameObject.CompareTag("mannequin"))
        {
            hit.collider.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

            Debug.Log(hit.gameObject.name + " hit. Health: " + hit.gameObject.GetComponent<ApplyHit>().hitPoints);
        }
        if (hit.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);

            if (isGrenade)
            {
                StartCoroutine(this.TimedExplosion());
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else if(hit.gameObject.CompareTag("Wall"))
        {
            hit.collider.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

            Debug.Log(hit.gameObject.name + " hit. Health: " + hit.gameObject.GetComponent<ApplyHit>().hitPoints);
        }
        else
        {
            Debug.Log("Hit somethin else?");
        }


        SoundManager.StartSound(this.GetComponent<Sound>());
        GameManager.instance.EchoManager.AddPulse(transform.position, 1, 3, 100);
        Destroy(this.gameObject);
    }

    IEnumerator TimedExplosion()
    {
        yield return new WaitForSeconds(5.0f);

        var colls = Physics.OverlapSphere(transform.position, farAreaEffect);

        foreach(Collider col in colls)
        {
            
            if (col.CompareTag("Wall"))
            { 
                
                float distance = Vector3.Distance(col.transform.position, transform.position);
                damage = 0.5f;
                if (distance <= closeAreaEffect)
                {
                    damage = 1; // but if inside close area, change to max damage
                }
                else if (distance <= mediumAreaEffect)
                {
                    damage = 0.75f; // else if inside medium area, change to medium damage
                }
                // apply the selected damage
                
                col.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
                
                Debug.Log(col.gameObject.name + " hit. Health: " + col.gameObject.GetComponent<ApplyHit>().hitPoints);
            }
        }
        
        this.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject,3f);
    }
    void Explosion()
    {
        var colls = Physics.OverlapSphere(transform.position, farAreaEffect);

        foreach (Collider col in colls)
        {
            Debug.Log(col.gameObject.name);
            if (col.CompareTag("Wall"))
            {
                float distance = Vector3.Distance(col.transform.position, transform.position);
                damage = 0.5f;
                if (distance <= closeAreaEffect)
                {
                    damage = 1; // but if inside close area, change to max damage
                }
                else if (distance <= mediumAreaEffect)
                {
                    damage = 0.75f; // else if inside medium area, change to medium damage
                }
                
                col.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }
        
        this.GetComponent<AudioSource>().PlayOneShot(blast);
    }
}
