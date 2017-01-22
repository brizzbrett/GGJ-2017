using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReCenter : MonoBehaviour {

    private float recenterSleep = 0.5f;
    private float lastCenter = 0;

    void Update()
    {
        /*if ((OVRInput.Get(OVRInput.RawAxis1D.LIndexTriggerd > 0.5 || OVRInput.Get(OVRInput.RawAxis1D.LIndexTriggerd > 0.5) && Time.time - lastCenter > recenterSleep))
        {
            UnityEngine.VR.InputTracking.Recenter();
            lastCenter=Time.time;

        //Currently all commented out because I don't have OVRInput stuff on here. Uncomment when integrating into MidnightWar.

        }*/
    }
}
