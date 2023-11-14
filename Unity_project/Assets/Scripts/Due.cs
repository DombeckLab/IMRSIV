using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class Due : MonoBehaviour {

    public string Port = "";
  //  public string Port2 = "";
	public InputField velocityInput;

    public float VelocityScale = 1.0f;

    SerialPort stream;
  //  SerialPort stream2;

    float velocity;
	float inputVal;
	float systemTime;
	float inputVal2;
    float enc;
    float stateA;
    float stateB;
    public float d_ang; // angle on the door for the Arduino
    private static Due instance;

    void Awake(){
        instance = this;
    }
    public static Due Instance(){
        return instance;
    }
		
	public void inputVelicityValue (string stringVelocity)
	{
		VelocityScale = float.Parse(velocityInput.text);
	}
   
    public float GetVelocity()
    {
        return velocity * VelocityScale;
    }

    public void ResetTimer()
    {
        if(stream.IsOpen)
        {
            stream.WriteLine("R");
        }

    }

    //controlls a servo if you send numbers between 0 and 5
    public void ControlServo(int value)
    {
        if(value < 0 || value > 5) return;
        if(stream.IsOpen)
        {
            stream.WriteLine(value.ToString());
        }

    }
public void ClosePort() 
	{
		stream.Close();
	}

    public void OpenA()
    {
        if(stream.IsOpen)
        {
            Debug.Log("giving reward");
            stream.WriteLine("A");
        }
    }

    public void CloseA()
    {
        if(stream.IsOpen)
        {
            stream.WriteLine("a");
        }
    }

    public void OpenB()
    {
        if(stream.IsOpen)
        {
            stream.WriteLine("B");
            stream.WriteLine("2");
        }
    }

    public void CloseB()
    {
         if(stream.IsOpen)
        {
            stream.WriteLine("b");
            stream.WriteLine("3");
        }       
    }
    public void OpenC()
    {
        if(stream.IsOpen)
        {
            stream.WriteLine("C");
        }
    }

    public void CloseC()
    {
        if(stream.IsOpen)
        {
            stream.WriteLine("c");
        }        
    }
    public void sendPos(uint py)
    {
        if(stream.IsOpen)
        {
         //   Debug.Log(py.ToString());
            stream.WriteLine("z" + py.ToString());
        }
    }

    public float GetEnc()
    {
        return enc;
    }

	public float GetInputVal()
	{
		return inputVal;
	}
	
	public float GetInputVal2()
	{
		return inputVal2;
	}
	
	public float GetSystime()
	{
		return systemTime;
	}

    public float GetStateA()
    {
        return stateA;
    }
    public float GetStateB()
    {
        return stateB;
    }
    public float GetDAng()
    {
        return d_ang;
    }

	void Start () {
        velocity = 0;
        stream = new SerialPort(Port,250000);
        stream.Open();
        
     //   stream2 = new SerialPort(Port2,250000);
     //   stream2.Open();

		velocityInput.onEndEdit.AddListener(inputVelicityValue);
		
	}

    static string[] stringSeparators = new string[] { "\r\n" };

	void FixedUpdate () {

        if (stream.IsOpen)
        {
            string value = stream.ReadExisting();
            if(value == "") return;
            string[] lines;
            lines = value.Split(stringSeparators, System.StringSplitOptions.None);
            
            if (lines.Length > 2) {
                var line = lines[lines.Length-2]; //-2

                string[] words;
                words = line.Split(' ');
                if (words.Length == 7
                ) { 
                    systemTime = float.Parse (words [0]); // Arduino update rate
                    enc = float.Parse(words[1]); // encoder ticks
                    velocity = float.Parse(words[2]); // velocity read off Arduino onto DAC0
                    inputVal = float.Parse (words [3]); // lick sensor
                    stateA = float.Parse (words [4]); // state of A port
                    stateB = float.Parse (words [5]); // state of B port
                    d_ang = float.Parse(words[6]); // angle of the door
                } 
            }
            else {
            //    Debug.Log("length too short");
            }
        }
		
	}
} 
