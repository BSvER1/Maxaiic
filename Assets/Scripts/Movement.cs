using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{


    public Transform ship;
    public Camera followCam;

    public float thrustMod;
    public float turnMod;
    public float maxAngVelocity;
    public float maxVelocity;

    public float dragMaxSpeedConst = 0.1f;
    public float dragActivationConst = 0.25f;


    private Vector3 camPosOffset;
    private Quaternion camRotOffset;

    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        camPosOffset = followCam.GetComponent<Transform>().position - ship.position;    
        camRotOffset = followCam.GetComponent<Transform>().rotation;
        rb = ship.GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngVelocity;

    }

    // Update is called once per frame
    void Update ()
    {
        
       
        float thrust = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");
        rb.AddForce(ship.up * thrustMod * thrust, ForceMode.Force);
        rb.angularVelocity = new Vector3(0, turn * turnMod, 0); 
        //rb.AddTorque(ship.forward * -1 * turnMod * turn);
        rb.drag = Mathf.Clamp(rb.velocity.sqrMagnitude * dragMaxSpeedConst - dragActivationConst, 0, Mathf.Infinity);


    }

    void LateUpdate()
    {
        followCam.transform.position = ship.position + camPosOffset;

        followCam.transform.rotation = camRotOffset;

        //followCam.transform.rotation = Quaternion.Euler(
        //    camRotOffset.eulerAngles.x + ship.rotation.eulerAngles.x, 
        //    camRotOffset.eulerAngles.y - ship.rotation.eulerAngles.y, 
        //    camRotOffset.eulerAngles.z - ship.rotation.eulerAngles.z
        //    );
        
        //followCam.transform.rotation = ship.rotation * Quaternion.Inverse(camRotOffset);
    }

}
