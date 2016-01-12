using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {

    public List<GameObject> players;
    public Vector3 cameraOffset;
    

    private float adjacent;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 meanPos = players[0].transform.position;

        for (int i = 1; i < players.Count; i++)
        {
            meanPos = meanPos + players[i].transform.position;
        }
        meanPos.x /= players.Count;
        meanPos.y /= players.Count;
        meanPos.z /= players.Count;

        gameObject.transform.position = meanPos + cameraOffset;

        float opposite = Mathf.Sqrt(((players[0].transform.position.x - players[1].transform.position.x) * (players[0].transform.position.x - players[1].transform.position.x) +
             (players[0].transform.position.y - players[1].transform.position.y) * (players[0].transform.position.y - players[1].transform.position.y)));
        // Distance^2 = (x2 -x1)^2 + (y2-y1)^2  this is formula for distance between 2 points. 
        //this also needs to be halved... but when i half it it has oppisite effect... not sure whats going on


        adjacent = opposite / Mathf.Atan(GetComponent<Camera>().fieldOfView);

        transform.Translate(0, 0, -1 * (adjacent));

    }
}
