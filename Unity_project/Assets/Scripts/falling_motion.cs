using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_motion : MonoBehaviour
{
    public float zpos;
    float cliff;
    keyboardMoving km;
    IMERSMovement MM;
    Rigidbody mrb;
    // Start is called before the first frame update
    void Start()
    {
        km = GetComponent<keyboardMoving>();
        MM = GetComponent<IMERSMovement>();
        mrb = GetComponent<Rigidbody>();
        
        cliff = -4.49f;
    }

    // Update is called once per frame
    void Update()
    {
        zpos = transform.position.z;
        if (zpos > cliff)
        {
            mrb.AddForce(new Vector3(0f, 0f, -20f), ForceMode.Force);
/*                        km.moveSpeed = 0f;
                        MM.velocity = 0f;*/
        }
    }
}
