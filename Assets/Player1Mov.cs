using UnityEngine;
using System.Collections;

public class Player1Mov : MonoBehaviour {

    private float joystickMovementThreshold = 0.85f;

    private float maxAngularVelY = 2;

    private float joyAngle;

    float shipAngle;

    public float RotateSpeed;


    // Use this for initialization
void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetAxis("Player1_Acceleration") > 0)
        {
            rb.AddForce(transform.up * Input.GetAxis("Player1_Acceleration"), ForceMode.Force);
        }

        Vector2 joyPos = new Vector2(Mathf.Rad2Deg * Mathf.Asin(Input.GetAxis("Player1_Horizontal")), Mathf.Rad2Deg * Mathf.Asin(Input.GetAxis("Player1_Vertical")));

        shipAngle = transform.rotation.eulerAngles.y;



        if (joyPos.magnitude > joystickMovementThreshold)
        {
            joyAngle = -1 * Mathf.Rad2Deg * Mathf.Atan2(joyPos.x, joyPos.y) + 180;

            Debug.Log(joyAngle + " " + shipAngle);

            if (shipAngle != joyAngle)
            {


                if ((joyAngle - shipAngle + 360) % 360 > 180)
                {
                    rb.angularVelocity = new Vector3(0, -RotateSpeed, 0);
                }
                else
                    rb.angularVelocity = new Vector3(0, RotateSpeed, 0);
                //Rigidbody rb = GetComponent<Rigidbody>();
                // rb.angularVelocity = new Vector3(rb.angularVelocity.x, Mathf.Clamp(transform.rotation.eulerAngles.y - joyAngle, -maxAngularVelY, maxAngularVelY), rb.angularVelocity.z);
            }
        }
        else
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }


}
