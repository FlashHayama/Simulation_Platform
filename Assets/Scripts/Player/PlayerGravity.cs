using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private float gravityForce = 981f;
    [SerializeField] private float changeSpeed = 2f;
    [SerializeField] private Quaternion rotation = Quaternion.identity;
    [SerializeField] private Vector3 gravityDirection = Vector3.down;

    private GameObject cont;

    public float GravityForce { get => gravityForce; set => gravityForce = value; }
    public float ChangeSpeed { get => changeSpeed; set => changeSpeed = value; }
    public Quaternion Rotation { get => rotation; set => rotation = value; }
    public Vector3 GravityDirection { get => gravityDirection; set => gravityDirection = value; }

    private void Start()
    {
        cont = GetComponent<PlayerController>().cont;
    }
    private void FixedUpdate()
    {
        //if (!GetComponent<PlayerRay>().canJump)
        //{
            cont.GetComponent<Rigidbody>().AddForce(
                GravityDirection * GravityForce * Time.fixedDeltaTime,
                ForceMode.Force);
        //}

        Quaternion quaternion = Quaternion.Lerp(
            cont.transform.rotation,
            /*Quaternion.FromToRotation(
                 Vector3.down,
                 gravityDirection),*/
            Rotation,
            ChangeSpeed * Time.fixedDeltaTime);

        
        //Debug.Log("rot" + quaternion.eulerAngles);
        //Debug.Log("view" + transform.rotation.eulerAngles);

        cont.transform.rotation = quaternion;
    }
}
