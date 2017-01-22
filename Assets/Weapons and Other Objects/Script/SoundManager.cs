﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//an Event Manager that calls a delegate on an event
public class SoundManager : MonoBehaviour {
    static public SoundManager instance;
    public EchoObject echo;

    public delegate void SoundReachesTarget(float distance, Sound sound);//fill in relevant parametes
    public static event SoundReachesTarget on_SRT;
    
    public static float sound_speed = 340.29f;//meters per second

    void Awake()
    { //called when an instance awakes in the game
        instance = this; //set our static reference to our newly initialized instance

    }

    void Start()
    {
        instance = this;
        
    }

    void OnTriggerEnter(Collider collider)
    {
        Sound sound = collider.gameObject.GetComponent<Sound>();
        if (sound)
            StartSound(sound);
    }

    //object hit or emitting the sound
    public static void StartSound(Sound sound_source)
    {
        float distance = Vector3.Distance(sound_source.transform.position, instance.transform.position);
        Sound sound = sound_source.GetComponent<Sound>();
        if (sound)
        {
            instance.StartCoroutine(PlaySound(distance, sound));
            GameManager.instance.EchoManager.AddPulse(sound_source.transform.position, sound.frequency, 90, 80);
        }
    }

    public static IEnumerator PlaySound(float distance, Sound sound)
    {
        float time_left = distance / sound_speed;
        //wait until time left is < 0
        for (float timer = 0; timer < time_left; timer += Time.deltaTime)
        {
            yield return null;
        }

        sound.playSound();
        if(on_SRT != null)
            on_SRT(distance, sound);

        yield break;
    }

}
