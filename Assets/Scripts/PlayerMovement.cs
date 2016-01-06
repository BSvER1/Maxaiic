using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float thrustMod;
    public float turnMod;
    public float maxAngVelocity;
    //public float maxVelocity;

    public float dragMaxSpeedConst = 0.1f;
    public float dragActivationConst = 0.25f;

    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngVelocity;

    }

    // Update is called once per frame
    void Update ()
    {
        float thrust = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        if (thrust > 0)
        {
            rb.AddForce(transform.up * thrustMod * thrust, ForceMode.Force);
        }
        else
        {
            rb.AddForce(transform.up * thrustMod * thrust * 0.1f, ForceMode.Force);
        }
        
        rb.angularVelocity = new Vector3(0, turn * turnMod, 0); 
        //rb.AddTorque(ship.forward * -1 * turnMod * turn);
        rb.drag = Mathf.Clamp(rb.velocity.sqrMagnitude * dragMaxSpeedConst - dragActivationConst, 0, Mathf.Infinity);
    }
}
