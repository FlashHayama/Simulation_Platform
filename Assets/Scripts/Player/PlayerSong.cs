using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSong : MonoBehaviour
{
    [SerializeField] AudioClip[] stepSong = new AudioClip[4];
    [SerializeField] AudioClip jumpSong,landSong;
    [SerializeField] AudioSource source;

    int rand;

    public void PlayStep()
    {
        if (GetComponent<PlayerRay>().CanJump)
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
