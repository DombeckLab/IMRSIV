using UnityEngine;
using System.Collections;

public class Keyb : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float moveSpeed;

    [Range(0.0f, 100.0f)]
    public float turnSpeed;

    [Range(0.0f, 5.0f)]
    public float scaleFactor;

    void Update()
    {
        //translate

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
    }
}