using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//container class that stores audio clip to be played
public class Sound  : MonoBehaviour
{

    AudioSource sound;
    public float intensity;
    public float cooldown;
    public float play_rate = .5f;

    //read only
    public float length;
    public float frequency;
    public float channels;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.playOnAwake = false;

        Debug.Log(sound + " is sound");

        AudioClip clip = sound.clip;

        Debug.Log(clip + " is sound");

        length = clip.length;
        frequency = clip.frequency;
        channels = clip.channels;

    }

    public void playSound()
    {
        // last parameter volume can be adjusted through rolloff in 3d sound settings
        AudioSource.PlayClipAtPoint(sound.clip, transform.position, 1);
    }
}
