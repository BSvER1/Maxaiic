using UnityEngine;
using System.Collections;

public class shotMovment : MonoBehaviour {

    Rigidbody rb;
    public float shotSpeed = 10;
    void Start () {

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * shotSpeed, ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
