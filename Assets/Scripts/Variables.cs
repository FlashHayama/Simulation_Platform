using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    //Force to jump
    protected static float jumpForce = 10f;
    //grabbing force against a surface
    protected static float catchForce = 10f;

    protected static float walkSpeed = 5f;
    protected static float runSpeed = 10f;

    protected static float rotSpeedX = 100f;
    protected static float rotSpeedY = 100f;

    protected static float gravityForce = 981f;
    protected static float changeSpeed = 2f;
    protected static Quaternion rotation = Quaternion.identity;
    protected static Vector3 gravityDirection = Vector3.down;

    protected static bool canJump = false;
    protected static bool canCatch = false;
    protected static bool canMove = true;
    protected static bool canForward = false;

    public GameObject cont;

    private void Start()
    {
        catchForce = gravityForce / 100;
    }
}
