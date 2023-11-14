using UnityEngine;
using System.Collections;
using UnityEngine;



	public class Eagle : MonoBehaviour {



[SerializeField]
public GameObject Sphere;
public GameObject Player;
public bool running;
public bool moving;
public float effectTime;
public float loomTime;
public float holdTime;
public float Zshift;
public float MaxRepeat;
public float repeat=0;
public bool approached=false;
public bool loomed=false;
public float velocity_x;
public float velocity_y;
public float velocity_z;
public float sx;
public float sy;
public float sz;
float startTime;
bool reduce = false;
public float timer;
public Rigidbody m_Rigidbody;
public Rigidbody mb;
public Vector3 originalPosition;


			void Start () {

				//    GetComponent<Renderer>().enabled = false;
        running=false;
		m_Rigidbody = GetComponent<Rigidbody>();
		reduce = false;
		originalPosition = Sphere.transform.position;
	    timer = effectTime;
			}

			void Update (){


				  if (reduce == true)
        {
            timer -= 1 * Time.deltaTime;
        }
	}

		void FixedUpdate () {
if (running==true){


 // GetComponent<Renderer>().enabled = true;
    sx=Sphere.transform.position.x;
    sy=Sphere.transform.position.y;
    sz=Sphere.transform.position.z;
Looming();
if (repeat==MaxRepeat){
 loomed=true;
 FlyAway();
}
} else
{
 ResetAll();
}

void FlyAway(){
	//  GetComponent<Renderer>().enabled = false;
	   //  Sphere.transform.position =new Vector3(Sphere.transform.position.x,Sphere.transform.position.y,Sphere.transform.position.z);
	      Sphere.transform.Translate(new Vector3(0, 0, velocity_z) * Time.fixedDeltaTime);

	         mb=Player.GetComponent<Rigidbody>();

            Quaternion target = Quaternion.Euler(0, 0, 0);
            Vector3 zeroVector = new Vector3((float)0,(float)0,(float)0);
           Player.transform.rotation= target;
       //     mb.angularVelocity= zeroVector;
          //  mb.inertiaTensorRotation= target;
        //  mb.centerOfMass =zeroVector;
        //   mb.velocity=zeroVector;
}

 void Looming() {

if (loomed==false){
       if (Sphere.transform.position.z <= Player.transform.position.z) { //Follow
     	Sphere.transform.Translate(new Vector3(0, 0, velocity_z) * Time.fixedDeltaTime);
      	}
      	else
      	{
      // approached = true;
       Sphere.transform.position =new Vector3(Sphere.transform.position.x,Sphere.transform.position.y,Player.transform.position.z+Zshift);

       reduce= true;

       // loom sequence
       startTime=effectTime;


  if ((timer>=0)&(repeat<=MaxRepeat)){

         //Approach
          if ((timer>(startTime-loomTime))&(timer<(startTime)))
       {
          Sphere.transform.Translate(new Vector3(0, -velocity_y, 0) * Time.fixedDeltaTime);
      	}
      	   if  ((timer>(startTime-2*loomTime))&(timer<(startTime-loomTime)))//Hold
       {
          Sphere.transform.Translate(new Vector3(0, 0, 0) * Time.fixedDeltaTime);
      	}
      	  if ((timer>(startTime-3*loomTime))&(timer<(startTime-2*loomTime)))//Retreive
       {
          Sphere.transform.Translate(new Vector3(0, velocity_y, 0) * Time.fixedDeltaTime);
      	}


     }else {
     timer=effectTime;
     repeat++;
     }
     }
}

}

	}


	public void ResetTimers() {
   running=false;
	repeat=0;
	timer=effectTime;
	loomed=false;
   // GetComponent<Renderer>().enabled = false;
    startTime=effectTime;
	reduce=false;
	}


	public void ResetAll() {
	running=false;
	repeat=0;
	timer=effectTime;
	loomed=false;
   // GetComponent<Renderer>().enabled = false;
    Sphere.transform.Translate(new Vector3(0, 0, 0) * Time.fixedDeltaTime);
	Sphere.transform.position=originalPosition;
	startTime=effectTime;
	reduce=false;
}

	public void Stop() {
      moving=false;
	}

 public void StopRunning() {
      running=false;
	}

	 public void StartRunning() {
      running=true;
	}
		public void ResetRepeat(){
        repeat=0;
        }





			}


