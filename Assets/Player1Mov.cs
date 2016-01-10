using UnityEngine;
using System.Collections;

public class Player1Mov : MonoBehaviour {

    private float joystickMovementThreshold = 0.85f;

    private float maxAngularVelY = 2;

    private float joyAngle;

    float shipAngle;

    public float accelerationMod = 1;

    public float RotateSpeed = 3;

    public float rotOffSet;

    public float degreeJitterReduce = 6; //this should be 3 times smaller then the rotate speed, acording to Max's crack theeory



    // Use this for initialization
void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 1000;
    }

    // Update is called once per frame
    void Update() {

        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetAxis("Player1_Acceleration") > 0)
        {
            rb.AddForce(transform.right * Input.GetAxis("Player1_Acceleration") * accelerationMod, ForceMode.Force);
        }

        Vector2 joyPos = new Vector2(Mathf.Rad2Deg * Mathf.Asin(Input.GetAxis("Player1_Horizontal")), Mathf.Rad2Deg * Mathf.Asin(Input.GetAxis("Player1_Vertical")));

        shipAngle = transform.rotation.eulerAngles.y % 360 + 360;



        if (joyPos.magnitude > joystickMovementThreshold)
        {
            joyAngle = (-1 * Mathf.Rad2Deg * Mathf.Atan2(joyPos.x, joyPos.y) + 180 + rotOffSet) % 360 + 360;

            float differenceAngle = Mathf.Abs(shipAngle - joyAngle);

            Debug.Log(joyAngle + " " + shipAngle);

            if (differenceAngle > degreeJitterReduce && differenceAngle < 360 - degreeJitterReduce)
            {


                if ((joyAngle - shipAngle + 360) % 360 > 180)
                    rb.angularVelocity = new Vector3(0, Mathf.Clamp(-RotateSpeed * differenceAngle * 0.1f, -RotateSpeed, 0), 0);
                else if (((joyAngle - shipAngle + 360) % 360 < 180))
                    rb.angularVelocity = new Vector3(0, Mathf.Clamp(RotateSpeed * differenceAngle * 0.1f, 0, RotateSpeed), 0);
                else
                    rb.angularVelocity = new Vector3(0, 0, 0);
                //Rigidbody rb = GetComponent<Rigidbody>();
                // rb.angularVelocity = new Vector3(rb.angularVelocity.x, Mathf.Clamp(transform.rotation.eulerAngles.y - joyAngle, -maxAngularVelY, maxAngularVelY), rb.angularVelocity.z);
            }
            else
                rb.angularVelocity = new Vector3(0, 0, 0);
        }
        else
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }


}
