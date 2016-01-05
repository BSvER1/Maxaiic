using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_NetworkSetup : NetworkBehaviour {

    PlayerMovement mov;
    Weapons weapons;
    PlayerCameraCreator cam;

	// Use this for initialization
	void Start ()
    {
        if (isLocalPlayer)
        {
            mov = GetComponent<PlayerMovement>();
            mov.enabled = true;

            weapons = GetComponent<Weapons>();
            weapons.enabled = true;

            cam = GetComponent<PlayerCameraCreator>();
            cam.enabled = true;
        }
	}
	
}
