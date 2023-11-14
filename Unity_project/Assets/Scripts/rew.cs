using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rew : MonoBehaviour
{
  // Start is called before the first frame update
  public Rigidbody rp;
  public float increase;
  void Start()
  {
    rp = GetComponent<Rigidbody>(); 
    increase = 0f;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey("up"))
    {
      // rp.position = new Vector3(rp.position.x,rp.position.y,rp.position.z + increase);
       transform.position = transform.position + new Vector3(0 , 0, increase);
      // rp = Vector3;
      // transform.position += Vector3.forward * Time.deltaTime;
      Debug.Log(transform.position);
    }
    if (Input.GetKey("down"))
    {
     transform.position = transform.position + new Vector3(0 , 0, -increase);
      Debug.Log(transform.position);
    }

  }
}
