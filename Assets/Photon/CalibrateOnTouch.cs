using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalibrateOnTouch : MonoBehaviour
{

    public void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.layer == 8)
        {
            print("cal");
            SceneManager.LoadScene("CalibrateScreen");
        }
    }
}