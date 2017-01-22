﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeOnTouch : MonoBehaviour
{

    public void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.layer == 8)
        {
            print("title");
            SceneManager.LoadScene("PracticeScene");
        }
    }
}