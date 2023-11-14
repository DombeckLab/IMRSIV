using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Recorder : MonoBehaviour
{

    private BinaryWriter writer1;
    private BinaryWriter writer2;
    private StreamWriter writer3;
     public Text message;
	public int rewardcounter = 0;
	private Due device;
	public GameObject DAQcube;
	public digitalDaq encoder;
    public GameObject Player;
    public float teleportDelta;
    public bool teleporting;
    public bool teleportEvent = false;
	public GameObject Door;
    public GameObject Sphere;
	public OpenableDoor door_script;
	public float euler;
	public float d_ang;
    [SerializeField]
    private GameObject go;
    public DateTime localDate = DateTime.Now;
    public bool rewardHappened = false;
    private bool doorState = false;
    public bool fileStarted = false;
    public float teleporttimer = 0;
    public int rng = 0;
    private Vector3 startPosition;
    [SerializeField]
    private float distance; //táv
    [SerializeField]
    private float speed;
    [SerializeField]

    public float velocityDAQ;
    public int dataL = 0;
    private string dl = ";"; // used as delimiter for saving in csv file

void Start () {

        Sphere.GetComponent<Loom>().ResetTimers();

		device = Due.Instance();
  		encoder = DAQcube.GetComponent<digitalDaq>();
      door_script = Door.GetComponent<OpenableDoor>();
	}

	public void startLogging (string expName)
    {

		if ((!fileStarted) & (this.enabled))
		{

			string clean = expName + "_" + DateTime.Now.ToString("yyyMMdd_HHmmss");
			string saveDirectory = "VRlogs" + Path.DirectorySeparatorChar + expName + Path.DirectorySeparatorChar;
	

			if (!Directory.Exists(saveDirectory))
            {
				Debug.Log("creating directory" + saveDirectory);
				Directory.CreateDirectory(saveDirectory);
            }

			writer1 = new BinaryWriter(File.Open(saveDirectory + clean + "_log1",FileMode.Create)); // raw dat file
			writer2 = new BinaryWriter(File.Open(saveDirectory + clean + "_log2",FileMode.Create)); // raw binary DAQ file
			writer3 = new StreamWriter(saveDirectory + clean + "_log3" + ".txt", append: false); // event text file

			writer3.WriteLine("t" + dl + "px" + dl + "py" + dl + "pz"
			 + dl + "v" + dl + "reward" + dl + "door" + dl + "licks"
			 + dl + "dt" + dl + "d_ang" + dl + "enc" + dl + "enc_old"
			 + dl + "daqL" + dl + "sx"+dl + "sy"+dl + "sz");

            writer3.WriteLine("sampling rate" + dl + encoder.digitalRate);
            writer3.WriteLine("nlines" + dl + encoder.numBytes);
            writer3.WriteLine("vs" + dl + Player.GetComponent<IMERSMovement>().vr_scale);

			fileStarted = true;
		}
	}


	void FixedUpdate() {

		euler = door_script.euler;


	 	  if (Input.GetKey("escape"))
        {
            Application.Quit();
			device.ClosePort();
        }
	    WriteData(go);
	}

	void Update() {
		if (fileStarted)
		{

			dataL = encoder.dataLength;
            if (encoder.dataLength > 0)
            {
	        	string log = GetTimeStamp() + dl + dataL;
            }
            writer2.Write(encoder.dataRunning);
            string telex= rewardcounter+ dl;
            message.text=telex;
            encoder.ClearDigital();
	        }
    	}
	




	public void RewardHappens()
	{
		rewardHappened = true;

		rewardcounter = rewardcounter+1;

		string log = GetTimeStamp() + dl + encoder.dataLengthTotal + dl + "reward";
		writer3.WriteLine(log);
    }

	public void RewardReset(){
		rewardHappened = false;
	}

	public void DoorStateOpen(){
		doorState = true; 
	}

	public void DoorStateClose(){
		doorState = false; 
	}
	



	public string GetTimeStamp() {
		return "" + Time.time;
	}


	public void  WriteData(GameObject go) {

		if (fileStarted)
		{

			int rewardHappenedInt = Convert.ToInt16(rewardHappened);
			int doorInt = Convert.ToInt16(doorState);
			int rewardState = Convert.ToInt16(device.GetStateA());
			int doorStatus = Convert.ToInt16(device.GetStateB());

			d_ang = (euler/-0.7120259f)*90;

			string log = GetTimeStamp() + dl +
				go.transform.position.x + dl +
				go.transform.position.z + dl +
				device.GetVelocity() + dl +
				rewardState + dl +
				doorStatus + dl +
				device.GetInputVal() + dl +
				Time.deltaTime + dl +
				d_ang + dl;
    		velocityDAQ = Player.GetComponent<IMERSMovement>().velocity;
			writer1.Write((float) Convert.ToDouble(GetTimeStamp()));
			writer1.Write((float) go.transform.position.x);
			writer1.Write((float) go.transform.position.y);
			writer1.Write((float) go.transform.position.z);
			writer1.Write( velocityDAQ);
			writer1.Write((float) Convert.ToDouble(rewardState));
			writer1.Write((float) Convert.ToDouble(doorStatus));
			writer1.Write(device.GetInputVal());
			writer1.Write(Time.deltaTime);
			writer1.Write(d_ang);
			writer1.Write((float) encoder.data2new);
			writer1.Write((float) encoder.data2old);
            writer1.Write((float) encoder.dataLengthTotal);
writer1.Write((float) Sphere.GetComponent<Loom>().sx);
writer1.Write((float) Sphere.GetComponent<Loom>().sy);
writer1.Write((float) Sphere.GetComponent<Loom>().sz);



			if (rewardHappened)
				rewardHappened = false;


		}
	}
	void OnDestroy()
    {
    writer1.Close();
    writer2.Close();
   writer3.Close();
}
}
