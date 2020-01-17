using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSong : Variables
{
    int rand;
    [SerializeField]
    AudioClip[] stepSong = new AudioClip[4];
    [SerializeField]
    AudioClip jumpSong,landSong;
    [SerializeField]
    AudioSource source;
    public void PlayStep()
    {
        if (canJump)
        {
            rand = Random.Range(0, 3);
            source.clip = stepSong[rand];
            source.Play();
        }
    }
    public void PlayJump()
    {
        source.clip = jumpSong;
        source.Play();
    }
    /*public void PlayLand()
    {
        if (!canJump)
        {
            source.clip = landSong;
            source.Play();
        }
    }*/
}
