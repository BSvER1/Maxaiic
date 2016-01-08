using UnityEngine;
using System.Collections;

public class Player1Mov : MonoBehaviour {

    private float rotLerpRate = 15;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Player1_Acceleration") > 0)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * Input.GetAxis("Player1_Acceleration"), ForceMode.Force);
        }


        
        if (Input.GetAxis("Player1_Vertical") >= 0)
        {
            GetComponent<Transform>().rotation = Quaternion.Lerp(GetComponent<Transform>().rotation, Quaternion.Euler(90, 0, Mathf.Rad2Deg * Mathf.Asin(Input.GetAxis("Player1_Horizontal") * -1)), Time.deltaTime * rotLerpRate);
        }
        else
        {
            GetComponent<Transform>().rotation = Quaternion.Lerp(GetComponent<Transform>().rotation, Quaternion.Euler(270, 0, Mathf.Rad2Deg * Mathf.Asin(Input.GetAxis("Player1_Horizontal") * -1)), Time.deltaTime* rotLerpRate);
        }




    }

    
}
