using UnityEngine;
using System.Collections;

public class LaserLightColorPicker : MonoBehaviour {

    public GameObject shot;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Light>().color = shot.GetComponent<MeshRenderer>().material.color;
	}
}
