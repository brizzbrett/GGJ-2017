using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    public static float pre_round_length;// 30 seconds to place the flag before the round begins

    public static bool ctf_mode = false; //playing in capture the flag mode

    public float round_timer;
    private bool round_started; //used to tell if we're in pre-round mode
 
    public Player player1;
    public Player player2;

    public GameObject p1Flag;
    public GameObject p2Flag;

    public GameObject p1StartPad;
    public GameObject p2StartPad;

	// Use this for initialization
	void Start () {
        StartPreRound();
	}
	
	// Update is called once per frame
	void Update () {
        if(!round_started)
        {
            round_timer -= Time.deltaTime;
            if(round_timer <= 0)
            {
                round_started = true;
                StartRound();
                round_timer = pre_round_length;
            }    
        }
	}

    void StartRound()
    {
        if(!player1)
            return;
        player1.Respawn();

        if (!player2)
            return;
        player2.Respawn();
    }

    void StartPreRound()
    {
        round_timer = pre_round_length;
        round_started = false;
        if (!ctf_mode)
        {
            Debug.Log("Ctf mode is " + ctf_mode);
            if (p1Flag)
                p1Flag.gameObject.SetActive(false);
            if (p2Flag)
                p2Flag.gameObject.SetActive(false);
        }
        //decide where to spawn players
    }


}
