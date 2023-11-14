using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportTime : MonoBehaviour
{

    public GameObject Player;
    public GameObject teleportationTarget;
    public GameObject rewardTarget;
    public Rigidbody mb;

    public float timer = 0.1f; // running timer for debugging purposes
    bool reduce = false; // used to indicate that timer is counting down
    private float timerTarget; // teleportation time. used to store teleportation time
    public bool instaTeleport = true;
    public Quaternion originalRotation;

    void Start()
    {
        timerTarget = timer; // initialize
        originalRotation = Player.transform.rotation;

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter_state:");

        if (other.tag == "Player")
        {

        if (instaTeleport == true) {
          Teleport();
        }
            reduce = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("exit_state:");

        if (other.tag == "Player")
        {
            Debug.Log("TELEPORT_exited teleportation zone");
            reduce = false;
            //timer = 0.1f;
            timer = timerTarget;

            //teleport
        //    Player.transform.position = teleportationTarget.transform.position;

           // rewardTarget.GetComponent<waterReward>().Teleported();
            Player.GetComponent<waterRewardSpout>().Teleported();
        }
    }
 public void Teleport (){
           mb=Player.GetComponent<Rigidbody>();
            Player.transform.position = new Vector3(teleportationTarget.transform.position.x,teleportationTarget.transform.position.y,teleportationTarget.transform.position.z);
            //Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation,originalRotation,Time.deltaTime*1000);
            Quaternion target = Quaternion.Euler(0, 0, 0);
            Vector3 zeroVector = new Vector3((float)0,(float)0,(float)0);
           // Player.transform.rotation= target;
             Player.transform.rotation= originalRotation;
            mb.angularVelocity= zeroVector;
            mb.inertiaTensorRotation= target;
            mb.centerOfMass =zeroVector;
            mb.velocity=zeroVector;
 }

    void Update()
    {
    // instant teleport or timed
        if (instaTeleport == false) {
        if (reduce == true)
        {
           // Debug.Log(timer);
            timer -= 1 * Time.deltaTime;
        }

        if ((timer <= 0) |  (Input.GetKeyDown(KeyCode.T)) )
        {
            Debug.Log("TELEPORT");
            reduce = false;

          Teleport();

        }

        }
    }
}