using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaunchProjectile : MonoBehaviour
{

    public List<GameObject> shotPoint;
    public GameObject projectile;
    public float destroyAfter = 30;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    private PlayerMov pm;

    void Update()
    {

        if (pm == null)
            pm = gameObject.GetComponent<PlayerMov>();

        int playerNum = pm.playerNum;

        if (Input.GetButton("Player"+playerNum+"_Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            CmdShoot();
        }
    }

    void CmdShoot()
    {
        for (int i = 0; i < shotPoint.Count; i++)
        {
            GameObject clone = Instantiate(projectile, shotPoint[i].GetComponent<Transform>().position, shotPoint[i].GetComponent<Transform>().rotation) as GameObject;
            clone.GetComponent<Rigidbody>().velocity = clone.GetComponent<Rigidbody>().velocity + gameObject.GetComponent<Rigidbody>().velocity;
            //Instantiate(projectile, shotPoint.GetComponent<Transform>().position, shotPoint.GetComponent<Transform>().rotation);
            if (destroyAfter > 0.0f)
                Destroy(clone, destroyAfter);
        }
        
    }

}
