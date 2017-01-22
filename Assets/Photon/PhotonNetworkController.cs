using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonNetworkController : MonoBehaviour {

    static public PhotonNetworkController instance;
    public PhotonView myView;

    public void Start()
    {
        instance = this;
        if(!this)
        {
            Debug.Log("THIS IS NULL");
        }
        instance.myView = PhotonView.Get(this);
    }


	public static GameObject createNetObject(string name, Vector3 pos, Quaternion rot)
    {
        return PhotonNetwork.Instantiate(name, pos, rot, 0);
    }

    public static void callRPC(string name, object[] passedParams)
    {
        instance.myView.RPC(name, PhotonTargets.Others, passedParams);
    }
}
