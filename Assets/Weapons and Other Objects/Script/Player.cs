using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int nextId = 0;
    public int myId;
    public bool haveEnemyFlag;

    public Flag my_flag;
    public GameObject my_startpad;

    public GameObject[] weapons;

    public bool hasWeapon = true;

    void OnEnable()
    {
        SoundManager.on_SRT += OnHearSound;
    }

    void OnDisable()
    {
        SoundManager.on_SRT -= OnHearSound;
    }

    void Start()
    {
        myId = nextId++;
        haveEnemyFlag = false;

        my_flag.myId = myId;

        foreach(GameObject go in weapons)
        {
            if(go.activeSelf)
            {
                hasWeapon = true;
                break;
            }

            hasWeapon = false;
            
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            DropWeapon();
        }

        foreach(GameObject go in weapons)
        {
            if (go.activeSelf)
            {
                hasWeapon = true;
                break;
            }

            hasWeapon = false;

        }
    }

    void DropWeapon()
    {
        foreach(GameObject go in weapons)
        {
            if(go.activeSelf)
            {
                go.SetActive(false);
            }
        }
    }
    void OnHearSound(float distance, Sound sound)
    {
        //appy sound information
    }

    public void Death()
    {
        /*
        Respawn();
        */
        //Game over. Please fix ths later. thx
        Application.Quit();
    }
    public void Respawn()
    {
        Vector3 start_pad_pos = my_startpad.transform.position;
        Debug.Log("SP pos " + start_pad_pos);
        start_pad_pos.y += .3f;//go up a litte bit

        transform.position = start_pad_pos;
        transform.rotation = Quaternion.identity;//set up 0
    }

}