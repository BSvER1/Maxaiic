using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Particles : NetworkBehaviour {


    public float ParticleMod;
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer)
        {
            gameObject.GetComponent<ParticleSystem>().startSize = Input.GetAxis("Vertical") * ParticleMod;
        }
        
	}
}
