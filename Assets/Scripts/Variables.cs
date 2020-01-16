using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    //Force to jump
    protected static float jumpForce = 5f;
    //grabbing force against a surface
    protected static float catchForce;

    protected static float walkSpeed = 5f;
    protected static float runSpeed = 10f;

    protected static float rotSpeedX = 50f;
    protected static float rotSpeedY = 50f;

    protected static float gravityForce = 981f;
    protected static Vector3 gravityDirection = Vector3.down;

    protected static bool canJump = false;
}
