using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Variables
{
    /// <summary>
    /// Default movement forward, backward, left, right
    /// </summary>
    /// <param name="Direction">X,Y,Z</param>
    protected void Move(Vector3 Direction)
    {
        gameObject.transform.Translate(Direction);
    }
}
