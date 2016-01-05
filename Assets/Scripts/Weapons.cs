﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Weapons : NetworkBehaviour {

    public GameObject shotPoint;
    public GameObject projectile;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject clone = Instantiate(projectile, shotPoint.GetComponent<Transform>().position, shotPoint.GetComponent<Transform>().rotation) as GameObject;
            }
        }
    }

}