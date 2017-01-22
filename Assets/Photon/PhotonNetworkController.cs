using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonNetworkController : MonoBehaviour {

    public PhotonView myView;

    public void Awake()
    {
        myView = PhotonView.Get(this);
    }


	public void createNetObject(string name, Vector3 pos, Quaternion rot)
    {
        PhotonNetwork.Instantiate(name, pos, rot, 0);
    }

    public void callRPC(string name, object[] passedParams)
    {
        myView.RPC(name, PhotonTargets.Others, passedParams);
    }
}
