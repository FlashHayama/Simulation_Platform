using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float catchForce = 10f;

    private GameObject cont;

    public float JumpForce { get => jumpForce; }
    public float CatchForce { get => catchForce; set => catchForce = value; }

    private void Start()
    {
        CatchForce = GetComponent<PlayerGravity>().GravityForce / 90;
        cont = GetComponent<PlayerController>().cont;
    }
    public void Jump(float force, bool can,Vector3 vector)
    {       
        if (can)
        {
            GetComponent<PlayerSong>().PlayJump();
            cont.GetComponent<Rigidbody>().velocity = Vector3.zero;
            cont.GetComponent<Rigidbody>().AddForce(
                transform.TransformDirection(vector) * force,
                ForceMode.Impulse);
        }
    }
}
