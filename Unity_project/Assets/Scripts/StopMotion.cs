using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopMotion : MonoBehaviour

{   [SerializeField]  public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
       Player.GetComponent<IMERSMovement>().Stop();
        }
    }

    void OnTriggerExit(Collider other) // probably don't need any of this
    {
        if (other.tag == "Player")
        {
  Player.GetComponent<IMERSMovement>().Restart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
