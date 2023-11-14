using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayedOpen : MonoBehaviour {

    public GameObject Player;
	public Text telemetry;
    public float timer;
	public float timerDoorOpenDelay;
    bool reduce = false;
[SerializeField]  public GameObject Door;
    void Start()
    {

	{
		timer = timerDoorOpenDelay;
		}
    }


		
    void OnTriggerEnter(Collider other)
    {
    

        if (other.tag == "Player")
        {
        	timer = timerDoorOpenDelay;
            reduce = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

         reduce = false;
         timer = timerDoorOpenDelay;
    }

    void Update()
    {

        if (reduce == true)
        {
        
            timer -= 1 * Time.deltaTime;

        }

        if ((timer <=0))
        {
        Door.GetComponent<OpenableDoor>().NonRandomOpen();
        reduce = false;
        timer = timerDoorOpenDelay;
        }

    }

}