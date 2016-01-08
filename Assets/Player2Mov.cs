using UnityEngine;
using System.Collections;

public class Player2Mov : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().position = (new Vector3(Input.GetAxis("Player2_Horizontal"), 0, Input.GetAxis("Player2_Vertical"))) + GetComponent<Transform>().position;
    }
}
