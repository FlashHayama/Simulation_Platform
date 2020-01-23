using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : Variables
{
    [SerializeField]
    Vector3 direction;
    [SerializeField]
    float Speed, force;
    [SerializeField]
    Vector3 rot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gravityDirection = direction;
            changeSpeed = Speed;
            gravityForce = force;
            rotation = Quaternion.Euler(rot);
        }
    }
}
