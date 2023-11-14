using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpenableDoor : MonoBehaviour
{

    // Smoothly open a door
  [SerializeField] public GameObject Player;


    private Due device;
    public float openMax = -0.706f;
    public float doorOpenAngle = 90.0f; //Set either positive or negative number to open the door inwards or outwards
    public float openSpeed = 20.0f; //Increasing this value will make the door open faster
    public Text telemetry2;
    public int randomProbabilityDefault = 10;
    public int randomProbability = 10;
    public int rngMatch=5;

    public bool open = false;
    bool enter = false;
    public bool run = false;
    public bool randomZeroed = false;
    public float euler;
    public int random;

    Quaternion openstop = Quaternion.Euler(new Vector3(0, 0, 0));

    // public Renderer rend;

    float defaultRotationAngle;
    float currentRotationAngle;
    //float openTime = 0;

	[SerializeField] private GameObject doorAnchorPoint;
    public Transform dTransform;

    [SerializeField] private float doorSpeed;
    /*InitializeComponent();*/


    void Start()
    {
        defaultRotationAngle = doorAnchorPoint.transform.localEulerAngles.x;
        currentRotationAngle = doorAnchorPoint.transform.localEulerAngles.x;
        device = Due.Instance();
     //   rend = transform.Find("Body").gameObject.GetComponent<Renderer>();
        /*        Task digitalouttask = new Task();
                digitalouttask.DOChannels.CreateChannel("dev2/Port0/line3", "myDAChannel", ChannelLineGrouping.OneChannelForEachLine);*/
        dTransform = doorAnchorPoint.GetComponent<Transform>();
        
    }

	public void OpenDoor(){

        doorAnchorPoint.transform.Rotate(Vector3.right * Time.deltaTime * openSpeed);
        if (doorAnchorPoint.transform.localRotation.x <= -90)
		{
            doorAnchorPoint.transform.Rotate(Vector3.right * Time.deltaTime * openSpeed);
            /*while (doorAnchorPoint.transform.localRotation.x <= 0)
            {
                //doorAnchorPoint.transform.Rotate(0.0f, 0.0f, 0.0f);
                   doorAnchorPoint.transform.Rotate(Vector3.right * Time.deltaTime * openSpeed);
            }*/
			
		}
        else{
  //          rend.enabled = false;
        }
//		if (Input.GetKeyDown(KeyCode.F)) {
//            open = false;
 //           device.OpenB();
//            Debug.Log("door opened");
 //       }
	}

    public float getOpenMax()
    {
        return openMax;
    }

    public void setRandomToDefault()
    {
        randomProbability = randomProbabilityDefault;
        randomZeroed = false;
    }

    public void setRandomToZero()
    {
        randomZeroed = true;
    }

	public void NonRandomOpen()
	{
 
            open = false;
                run = true;

    }

      public int returnRND(){
     return random;

    }

	public void NonRandomClose()

	{

            open = true;
            run = true;
  
    }

	public void TriggerClose(){
	 random = Random.Range(1, randomProbability);
              string telex= random + " ";
             telemetry2.text=telex;
        if (randomZeroed == true)
        {
            random = 0;
        } 


        if (random == rngMatch){
            if(open == false){
                open = true;
                run = true;
            }
        }
        else{

         if(open == true){
         //      open = false;
           //    run = true;
            }
        }}


	public void CloseDoor(){
        doorAnchorPoint.transform.Rotate(Vector3.left * Time.deltaTime * doorSpeed);
        if (doorAnchorPoint.transform.localRotation.x >= 0.0f)
		{
			doorAnchorPoint.transform.Rotate(Vector3.left * Time.deltaTime * doorSpeed);
		}
//		if (Input.GetKeyDown(KeyCode.F)){
 //           open = true;
  //          device.CloseB();
 //           Debug.Log("door closed");
 //       }
	}

    // Main function
    void Update()
    {
        // euler = dTransform.eulerAngles.x;
        euler = dTransform.rotation.x;
        //  doorAnchorPoint.transform.Rotate(Vector3.right * Time.deltaTime * openSpeed);
        // toggle door state
        if ((Input.GetKeyDown(KeyCode.F)) & (Time.timeScale != 0)) {
            /*            writer.WriteSingleSampleSingleLine(true, true);*/
            run = true;
            if (open)
            {
                open = false;
            }
            else
            {
                open = true;
            }
            }

        if ((euler >= openstop.x) & open)
        {
            Debug.Log("It should stop");
            run = false;
        }
        if ((euler <= openMax) & !open)
        {
            Debug.Log("It should stop");
            run = false;
        }
        

        if (run)
        {
            if (open)
            {
                doorAnchorPoint.transform.Rotate(Vector3.right * Time.deltaTime * openSpeed);
                // CloseDoor();
                Player.GetComponent<Recorder>().DoorStateClose();
                //              rend.enabled = true;
              //  device.OpenB(); // output to high

            }
            else
            {
                doorAnchorPoint.transform.Rotate(Vector3.left * Time.deltaTime * openSpeed);
                //OpenDoor();
                Player.GetComponent<Recorder>().DoorStateOpen();
              // device.CloseB(); // output to low
            }
        }



            //doorAnchorPoint.transform.localEulerAngles.x
            if (doorAnchorPoint.transform.localRotation.x <= -90)
        {
            run = false;
            open = false;
        }

        if ((device.GetStateB() == 1) & (open))
        {
            //device.CloseB();
        }
        if ((device.GetStateB() == 0) & (!open))
        {
          //  device.OpenB();
        }


		/*if(open)
        {
            OpenDoor();

           

        }*/
		/*else 
        {
            CloseDoor();

            // device.CloseB();
        }*/



  //      if(openTime < 1)
  //      {
  //          openTime += Time.deltaTime * openSpeed;
  //      }
        //doorAnchorPoint.transform.localEulerAngles = new Vector3(doorAnchorPoint.transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), doorAnchorPoint.transform.localEulerAngles.z);

        

    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
			Debug.Log("onTriggerEnter");
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
}