using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPad : MonoBehaviour {

    //let gm know we here
    void Start()
    {
        Debug.Log("SP Start");

        GameManager.AddStartPad(transform.gameObject);
    }
	
	
}
