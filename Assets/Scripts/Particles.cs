﻿using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {


    public float ParticleMod;
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<ParticleSystem>().startSize = Input.GetAxis("Vertical") * ParticleMod;
	}
}