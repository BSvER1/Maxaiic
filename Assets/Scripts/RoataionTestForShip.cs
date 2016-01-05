using UnityEngine;
using System.Collections;

public class RoataionTestForShip : MonoBehaviour {

    public Rigidbody rb;
    public float turnMod;
    public Transform t;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        float turn = Input.GetAxis("Horizontal");
        Debug.Log(turn);

        t.Rotate(0.0f, (turn * turnMod), 0.0f);

    }
}
