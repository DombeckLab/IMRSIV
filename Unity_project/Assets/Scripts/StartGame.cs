using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public bool gameStarted = false;
    public string expName = "PlayerOne";

    //public InputField expInput;

    // Start is called before the first frame update
    void Start()
    {
       // instructionsText.text = "Enter experiment name";
        Time.timeScale = 0;
        Time.fixedDeltaTime =  0.001f; //0.1f;
        gameObject.GetComponent<InputField>().text = expName;

        Debug.Log(Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return)) | (Input.GetKeyDown(KeyCode.KeypadEnter)))
        {

            //  InputField field = GameObject.Find("IPInput").GetComponent<InputField>();

            // expName = expInput.text;

            expName = gameObject.GetComponent<InputField>().text;

            Time.timeScale = 1;
            gameStarted = true;
            // Destroy(gameObject);

           GameObject tempObject = GameObject.Find("IMERS");
         GameObject teleportObject= GameObject.Find("teleportObject");
         // teleportObject.GetComponent<teleportTime>().Teleport();
          if (tempObject != null)
            {
                Debug.Log("IMERS loaded");

                tempObject.GetComponent<Recorder>().startLogging(expName);
            }

            gameObject.SetActive(false); // hide this text box

        }
    }


    
}
