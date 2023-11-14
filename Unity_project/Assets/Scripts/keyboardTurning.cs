using UnityEngine;
using System.Collections;

public class keyboardTurning : MonoBehaviour
{
    [Range(1-10.0f, 10.0f)]
    public float moveSpeed;

    [Range(-10.0f, 10.0f)]
    public float turnSpeed;

    [Range(0.0f, 5.0f)]
    public float scaleFactor;

    void Update()
    {
        //translate

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }
}