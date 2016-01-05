using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {


    public float ParticleMod;
	
	// Update is called once per frame
	void Update () {

//if (isLocalPlayer)
        //{
            GetComponent<ParticleSystem>().startSize = Input.GetAxis("Vertical") * ParticleMod;
       // }
       // else if (! isLocalPlayer)
      //  {
     //       GetComponent<ParticleSystem>().startSize = 0;
       // }
        
	}
}
