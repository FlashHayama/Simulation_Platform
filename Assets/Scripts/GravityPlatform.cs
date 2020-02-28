using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
{
    [SerializeField]
    Vector3 direction;
    [SerializeField]
    float Speed, force;
    [SerializeField]
    Vector3 rot;

    private void OnTriggerEnter(Collider other)
    {
        PlayerGravity player = other.GetComponentInChildren<PlayerGravity>();
        if (other.tag == "Player")
        {
            player.gravityDirection = direction;
            player.changeSpeed = Speed;
            player.gravityForce = force;
            player.GetComponent<PlayerJump>().catchForce = player.gravityForce / 90;
            player.rotation = Quaternion.Euler(rot);
        }
    }
}
