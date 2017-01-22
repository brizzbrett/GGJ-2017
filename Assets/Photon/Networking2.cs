using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script deals with networking that goes on during the game, like instantiating the players.
/// </summary>
public class Networking2 : Photon.MonoBehaviour {
    public PhotonPlayer[] other;
    public Vector3 startingPos1;
    public Vector3 startingPos2;
    public PhotonPlayer self;
    public PhotonView myView;
    public int playerNum;
    public int worldSeed;
    public bool seedCheck = false;
    public int onlyOnce = 0;
    public GameObject playerPrefab;

    public void Awake()
    {
        StartCoroutine("InitDelay");
    }

    public void StartGame()
    {
        print("starting game");
        myView = PhotonView.Get(this);
        self = PhotonNetwork.player;
        other = PhotonNetwork.otherPlayers;
        if (self.ID > other[0].ID) playerNum = 1;
        if (self.ID < other[0].ID) playerNum = 2;
        //Player 1 Generates the world seed here
        if (playerNum == 1)
        {
            worldSeed = 5;
            myView.RPC("ReceiveWorldSeed", PhotonTargets.Others, worldSeed);
        }
    }

    public void Update()
    {
        if(seedCheck && onlyOnce == 0)
        {
            print("stuff");
            InitPlayers();
            onlyOnce = 1;
        }
    }

    public void InitPlayers()
    {
        Debug.Log("got into InitPlayers");
        if (playerNum == 1)
        {
            print("Instantiating P1");
            PhotonNetwork.Instantiate("Player", startingPos1, Quaternion.identity, 0);
        }
        if (playerNum == 2)
        {
            print("Instantiating P2");
            PhotonNetwork.Instantiate("Player", startingPos2, Quaternion.identity, 0);
        }
    }

    IEnumerator InitDelay()
    {
        print("InitDelay starting");
        yield return new WaitForSeconds(3);
        print("InitDelay continuing");
        StartGame();

    }

    [PunRPC]
    public void ReceiveWorldSeed(int seed)
    {
        print("received new world seed. It's: " + seed);
        if(worldSeed == seed)
        {
            seedCheck = true;
        }
        else
        {
            worldSeed = seed;
            myView.RPC("ReceiveWorldSeed", PhotonTargets.Others, worldSeed);
            seedCheck = true;
        }
        if (seedCheck)
        {
            //Generate the world here GILMORE PROCEDURALY GENERATE DUNGEON HERE
            Debug.Log("It works. Seed is: " + worldSeed);
        }
    }

    
}
