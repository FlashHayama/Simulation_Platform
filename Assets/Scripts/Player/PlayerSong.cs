using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSong : Variables
{
    int rand;
    [SerializeField]
    AudioClip[] stepSong = new AudioClip[4];
    [SerializeField]
    AudioSource source;
    public void PlayStep()
    {
        rand = Random.Range(0, 3);
        source.PlayOneShot(stepSong[rand]);
    }
}
