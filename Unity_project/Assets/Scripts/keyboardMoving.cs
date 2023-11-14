using UnityEngine;
using System.Collections;

public class keyboardMoving : MonoBehaviour
{

    [Range(0.0f, 10.0f)]
    public float moveSpeed;

    [Range(0.0f, 100.0f)]
    public float turnSpeed;

    [Range(0.0f, 5.0f)]
    public float scaleFactor;

    public Rigidbody m_rb;
           
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //translate

        if (Input.GetKey(KeyCode.UpArrow))
            m_rb.AddForce(new Vector3(0f, 0f, 2.0f), ForceMode.Force);
        /*transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);*/

        if (Input.GetKey(KeyCode.DownArrow))
            m_rb.AddForce(new Vector3(0f, 0f, -2.0f), ForceMode.Force);
        /*transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime, Space.World);*/
    }
}