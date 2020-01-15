using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    //Force to jump
    protected float jumpForce = 5f;
    //grabbing force against a surface
    protected float catchForce;

    protected float walkSpeed = 5f;
    protected float runSpeed = 10f;

    protected float gravityForce = 981f;
    protected Vector3 gravityDirection = Vector3.down;

    protected bool canJump = false;
}
