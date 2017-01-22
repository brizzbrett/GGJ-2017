using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayOnTouch : MonoBehaviour {

	public void OnTriggerEnter(Collider hit)
    {
        print("trigger");
        if(hit.gameObject.layer == 8)
        {
            print("play");
            //go grab the Connect() function on the other script to start the game.
            GameObject.Find("NetHandler").GetComponent<Networking>().Connect();
        }
    }
}
