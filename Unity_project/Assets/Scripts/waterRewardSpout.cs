using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterRewardSpout : MonoBehaviour {

   [SerializeField]  public GameObject Player;
    public GameObject Spout;
	public GameObject DAQcube;
	public digitalDaq encoder;
	public bool inZone=false;
    public float PlayerZ;
    public float SpoutZ;
    public Text telemetry;
    public float timer; // timer to reward
    public float droptimer; // actual time piezo is open
    public bool reduce = false; // indicates whether timer is running
	public bool dropped = false; // indicates whether droptimer is running
    public bool dropping = false; // indicates whether reward is currently being given

    public bool rewardedTrial = false; //indicated whether trial has already been rewarded
    private bool teleported = false; // indicates if mouse has teleported (in which case, reset rewardedTrial)

    private float timerTarget; // stores desired timer time
    private float dropTimerTarget; // stores desired droptimer time



    void Start()
    {
  		encoder = DAQcube.GetComponent<digitalDaq>();
        timerTarget = timer;
        dropTimerTarget = droptimer;

         SpoutZ=Spout.transform.position.z;

     }

    void Update()
    {
        }

    void FixedUpdate()
    {

    PlayerZ=Player.transform.position.z;
    if (Player.transform.position.z>=Spout.transform.position.z)
    {
    inZone=true;
    }



       if ((!rewardedTrial)&(inZone==true))
            {
                reduce = true; // begin reward sequence
                rewardedTrial = true;
            }

        if ((Input.GetKeyDown(KeyCode.R)) & (Time.timeScale != 0) )// user gives reward. Changed from 'g' to match our Matlab experiments
        {

            if ((!dropping))
            {
                Reward();
            }
        };

        if ((Input.GetKeyDown(KeyCode.H)) & (Time.timeScale != 0))
        {
        };

        if (reduce == true)
        {
            timer -= 1 * Time.deltaTime;
            //LeftZone();
        }

        if ((timer <= 0) & (dropped == false)) // give reward based on timer hitting zero
        {
            reduce = false;
            Reward();
            dropped = true;
        }

        if (dropping)
        {
            droptimer -= 1 * Time.deltaTime;
            if (droptimer <= 0.0000001)
            {

                dropping = false;
                droptimer = dropTimerTarget;
            }
        }


        }

		
    void Reward() {
        // reduce = false;
        dropping = true;
   //     device.OpenA();
        Debug.Log("Reward given" + " " + droptimer + " " + Time.fixedDeltaTime + " " + dropping);

        encoder.GiveReward();
        Player.GetComponent<Recorder>().RewardHappens();

    }

    public void Teleported() {
        rewardedTrial = false;
        inZone=false;
        timer=timerTarget;
        reduce=false;
        dropped=false;
    }

    //	void LeftZone() {
	//	Player.GetComponent<PositionTracking>().LeftZone();
	//}


}