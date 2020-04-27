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
            player.GravityDirection = direction;
            player.ChangeSpeed = Speed;
            player.GravityForce = force;
            player.GetComponent<PlayerJump>().CatchForce = player.GravityForce / 90;
            player.Rotation = Quaternion.Euler(rot);
        }
    }
}
