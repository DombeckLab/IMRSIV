using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoomTrigger : MonoBehaviour {

  public GameObject Player;
[SerializeField]  public GameObject Sphere;
public float TriggerTimer;
public float SecondaryTimer;
public float timer;
public float randomTime;
public bool triggered=false;
float loomcounter;
public float Maxloomcounter;
bool reduce=true;

float random;
    void Start()
    {
timer=TriggerTimer;
    }


    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
             Sphere.GetComponent<Loom>().Activate();

         if ((timer <= 0)){


         if (loomcounter<=Maxloomcounter){

          Sphere.GetComponent<Loom>().StartRunning();
         loomcounter++;
         triggered=true;
         }
}
        }

    }

    void OnTriggerExit(Collider other)
    {
     if (other.tag == "Player")
        {
    Sphere.GetComponent<Loom>().ResetAll();

 }
    }

	public void Reset(){
	      timer = TriggerTimer;
	}


    void Update()
    {
if (reduce == true)
        {
            timer -= 1 * Time.deltaTime;
        }

       if ((timer<=0)&(triggered==true))
       {
       random = Random.Range(1, randomTime);
       timer=SecondaryTimer+random;
       triggered=false;
       }


    }

}
