using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : Variables
{
    private void FixedUpdate()
    {
        gameObject.transform.Translate(gravityDirection * gravityForce * Time.deltaTime,Space.World);
    }
}
