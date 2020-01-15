using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : Variables
{
    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(
            gravityDirection * gravityForce * Time.fixedDeltaTime, 
            ForceMode.Force);
    }
}
