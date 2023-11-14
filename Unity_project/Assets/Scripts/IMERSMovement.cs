using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMERSMovement : MonoBehaviour {

	[SerializeField]
	public bool moving;
	public bool islimiter;
	public float speedLimit = 0.1f;
	public float maxVelocity = 0.1f;
	private Due device;

	public float oldPosition;
	public float newPosition;
public float pos_y;
public uint py;
public float velocity;
private uint py_old = 0;
	Rigidbody m_Rigidbody;
	public GameObject DAQcube;
	public digitalDaq encoder;
public	int distance;
public float vr_scale = 8;
	float fdistance;


	void Start () {
		encoder = DAQcube.GetComponent<digitalDaq>();

		m_Rigidbody = GetComponent<Rigidbody>();

	}
	
	void Update()
	{
		if (Time.timeScale != 0){
		pos_y = transform.position.z;
		pos_y = (pos_y+20)/60 * 4000;
		py =  (uint)pos_y;
		if (py != py_old) {

			py_old = py;
		}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		// distance = ((encoder.data2new - encoder.data2old) / 5000) * 17 * 3.14;
		distance = (encoder.data2new - encoder.data2old);
		fdistance = (float)distance;
		velocity = fdistance /5000 * vr_scale / Time.fixedDeltaTime;
		if (Mathf.Abs(fdistance) > 1000.0f)
		{
		velocity = 0.0f;
		}
		//transform.Translate((0f, 0f, velocity) * Time.deltaTime);
		if (moving==true){

		if (islimiter==true)
		{
		if (velocity > speedLimit)
		{
		velocity = maxVelocity;
		}

		}

		transform.Translate(new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, velocity) * Time.fixedDeltaTime);
		}


	}
	
	public void Stop() {
      moving=false;
	}

	public void Speedlimiter() {
	islimiter=true;
	}

   public void SpeedlimiterOff() {
	islimiter=false;
	}

	public void Restart() {
      moving=true;
	}
	
	
}
