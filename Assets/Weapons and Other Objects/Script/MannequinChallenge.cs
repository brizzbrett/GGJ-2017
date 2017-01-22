using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinChallenge : MonoBehaviour {

    GameObject[] mannequins;

	// Use this for initialization
	void Start () {
        mannequins = GameObject.FindGameObjectsWithTag("mannequin");
	}
	
	// Update is called once per frame
	void Update () {
        if (checkForMannequins())
        { 
            //game over you win
            Application.Quit();
        }
	}

    bool checkForMannequins()
    { 
        bool found = false;
        for (int i = 0; i < mannequins.Length; i++)
        {
            if (mannequins[i].activeSelf == true)
            {
                found = true;
            }
        }
        return found;
    }
}
