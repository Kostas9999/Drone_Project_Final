using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_RotateDrone : MonoBehaviour
{
   public Rigidbody drone_RB;
    // Start is called before the first frame update
    void Start()
    {
     drone_RB   = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
           drone_RB.AddRelativeTorque(transform.forward * 0.005f);
           drone_RB.AddRelativeTorque(transform.up * 0.001f);
    }


    
 void OnMouseDrag() {
     float rotationX = Input.GetAxis("Mouse X") * 2f ;
     float rotationY = Input.GetAxis("Mouse Y") * 2f;

     transform.Rotate( Vector3.up, -rotationX, Space.World );
transform.Rotate( Vector3.right, rotationY, Space.World );

//drone_RB.transform.RotateAround(Vector3.up, -rotx);
//drone_RB.transform.RotateAround(Vector3.right, roty);


    
}
}
