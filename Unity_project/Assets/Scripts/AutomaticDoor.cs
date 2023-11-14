using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticDoor : MonoBehaviour {

[SerializeField]  public GameObject Player;
[SerializeField]  public GameObject Door;
[SerializeField]   public GameObject doorAnchorPoint;
  public int openedDoorLapsFromStart = 10;
 public int goThroughCounter = 0;
   public Transform dTransform;
   public Text telemetry;

    public float doorOpenAngle = 90.0f; //Set either positive or negative number to open the door inwards or outwards
    public float openSpeed = 20.0f; //Increasing this value will make the door open faster
public GameObject DAQcube;
public digitalDaq encoder;
public bool goThrough = false;

    void Start()
    {
        Door.GetComponent<OpenableDoor>().setRandomToZero();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
        if (goThrough==false) {
Door.GetComponent<OpenableDoor>().TriggerClose();
      goThrough=true;
}

        }
    }

    void OnTriggerExit(Collider other) // probably don't need any of this
    {
        if (other.tag == "Player")
        {
            goThroughCounter++;
            goThrough=true;
   
        }
    }

    public void ResetGoThrough() {
    goThrough=false;

    }

    void Update()
    {


        if (goThroughCounter >= openedDoorLapsFromStart) 
        {
            Door.GetComponent<OpenableDoor>().setRandomToDefault();

        }

             string telex= goThroughCounter + " ";
             telemetry.text=telex;

        }

    void FixedUpdate()
    {

    }



}