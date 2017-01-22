using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script deals with networking that goes on during the game, like instantiating the players.
/// </summary>
public class Networking2 : MonoBehaviour {
    public PhotonPlayer[] other;
    public Vector3 startingPos1;
    public Vector3 startingPos2;
    PhotonPlayer self;


    public void Awake()
    {
        self = PhotonNetwork.player;
        other = PhotonNetwork.otherPlayers;
    }

    public void Start()
    {
        if (self.ID > other[0].ID) PhotonNetwork.Instantiate("Player", startingPos1, Quaternion.identity, 1);
        if (self.ID < other[0].ID) PhotonNetwork.Instantiate("Player", startingPos2, Quaternion.identity, 2);
    }
}
