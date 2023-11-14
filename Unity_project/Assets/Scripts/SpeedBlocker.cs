using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBlocker: MonoBehaviour {
    public GameObject Player;
   public  bool limiter = false;
    void Start()
    {

    }


		
    void OnTriggerEnter(Collider other)
    {
    

        if (other.tag == "Player")
        {
   
            limiter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        limiter = false;

    }

    void Update()
    {
    	if (limiter==true)
		{
        Player.GetComponent<IMERSMovement>().Speedlimiter();
        } else
        {Player.GetComponent<IMERSMovement>().SpeedlimiterOff();}

    }

}