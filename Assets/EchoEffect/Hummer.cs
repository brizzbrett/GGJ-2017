using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hummer : MonoBehaviour {


    public bool Active;
    public Material HummingMaterial;
    public Material EchoMaterial;
	// Use this for initialization
	void Start () {
        HummingMaterial =new Material(GetComponent<Renderer>().material);
        GetComponent<Renderer>().material = HummingMaterial;
		
	}
	
	// Update is called once per frame
	void Update () {
       if(Input.GetKeyUp(KeyCode.S))
          {
            Switch();
          }
		
	}

    void Switch()
    {
        if(Active)
        {
            GetComponent<Renderer>().material = EchoMaterial;
            Active = false;
        }
        else
        {
            GetComponent<Renderer>().material = HummingMaterial;
            Active = true;
        }
    }
}
