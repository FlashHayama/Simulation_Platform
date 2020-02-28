using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public float gravityForce = 981f;
    public float changeSpeed = 2f;
    public Quaternion rotation = Quaternion.identity;
    public Vector3 gravityDirection = Vector3.down;

    private GameObject cont;

    private void Start()
    {
        cont = GetComponent<PlayerController>().cont;
    }
    private void FixedUpdate()
    {
        cont.GetComponent<Rigidbody>().AddForce(
            gravityDirection * gravityForce * Time.fixedDeltaTime, 
            ForceMode.Force);

        Quaternion quaternion = Quaternion.Lerp(
            cont.transform.rotation,
            /*Quaternion.FromToRotation(
                 Vector3.down,
                 gravityDirection),*/
            rotation,
            changeSpeed * Time.fixedDeltaTime);

        
        //Debug.Log("rot" + quaternion.eulerAngles);
        //Debug.Log("view" + transform.rotation.eulerAngles);

        cont.transform.rotation = quaternion;
    }
}
