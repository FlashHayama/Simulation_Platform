using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : Variables
{
    public void Jump(float force, bool can)
    {
        if (can)
        {
            GetComponent<PlayerSong>().PlayJump();
            cont.GetComponent<Rigidbody>().velocity = new Vector3(0, 0);
            cont.GetComponent<Rigidbody>().AddForce(
                transform.TransformDirection(Vector3.up) * force,
                ForceMode.Impulse);
        }
    }
}
