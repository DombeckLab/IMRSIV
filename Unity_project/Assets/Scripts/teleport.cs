using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{
	public GameObject Player;
	public GameObject teleportationTarget1;
	public GameObject teleportationTarget2;
	public Text telemetry;

	bool reduce = false;

	void OnTriggerEnter(Collider other)
	{
		
	}

	void OnTriggerExit(Collider other)
	{
	
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
		reduce = true;
			{
			//teleport
			Player.transform.position = teleportationTarget1.transform.position;
			

			}
		}

		if (Input.GetKeyDown(KeyCode.O))
		{
			reduce = true;
			{
				//teleport
				Player.transform.position = teleportationTarget2.transform.position;

			
			}
		}


	}	
}