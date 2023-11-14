using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED_C2 : MonoBehaviour
{
    public NIdaq_RF2 C;
    // GameObject Cube;
    // Start is called before the first frame update
    void Start()
    {
        C.LED(1);
        //  Script C = GetComponent<Nidaq_RF2>();
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) == true)
        {
            Debug.Log ("Key press received");
            // GetComponent<NIdaq_RF2>().LED(1);
            C.LED(1);
        }

        if (Input.GetKey(KeyCode.Keypad2) == true)
        {
            Debug.Log("Key press received");
            //  GetComponent<NIdaq_RF2>().LED(2);
            C.LED(2);
        }

        /*        else
                    if (Input.GetKey(KeyCode.Keypad1) == false)
                {
                    GetComponent<NIdaq_RF2>().LED(2);
                }*/
    }
}
