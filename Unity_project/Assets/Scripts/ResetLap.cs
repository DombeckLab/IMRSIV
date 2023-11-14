using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetLap : MonoBehaviour {


[SerializeField]  public GameObject DoorTrigger;
  public GameObject Player;
    void Start()
    {

    }


		
    void OnTriggerEnter(Collider other)
    {
    

        if (other.tag == "Player")
        {
         DoorTrigger.GetComponent<AutomaticDoor>().ResetGoThrough();
         Player.GetComponent<waterRewardSpout>().Teleported();
        }
    }

    void OnTriggerExit(Collider other)
    {


    }

    void Update()
    {


    }

}