using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Particles : NetworkBehaviour {


    public float ParticleMod;

    public GameObject ship;

    [SyncVar]
    private float particleSize;
	
    
    // Update is called once per frame
	void Update () {
        transmitSize();

        if (ship.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            GetComponent<ParticleSystem>().startSize = Input.GetAxis("Vertical") * ParticleMod;
        }
        else
        {
            GetComponent<ParticleSystem>().startSize = particleSize;
        }
        
	}

    [Command]
    void CmdProvideSize(float size)
    {
        particleSize = size;
    }

    [ClientCallback]
    void transmitSize()
    {
        if (ship.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            CmdProvideSize(Input.GetAxis("Vertical") * ParticleMod);
        }
        
    }
}
