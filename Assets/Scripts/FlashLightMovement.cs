using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        flashlight = transform.GetChild(0).GetComponent<Light>();
	}

	public Transform player;
    Light flashlight;
    float lightDistance;
	// Update is called once per frame
	void Update () {
		Vector3 position = new Vector3 (Input.mousePosition.x,
			                   Input.mousePosition.y, 12);
		
		position =Camera.main.ScreenToWorldPoint(position);
		position.z = 0;
		transform.position = position;

        //changes radius of light based on player distance
        
        lightDistance = Vector3.Distance(transform.position, player.position) * 10;
        if (lightDistance >= 60)
        {
            flashlight.spotAngle = 0;
        }
        else
        {
            flashlight.spotAngle = 60 - lightDistance;
        }
        
    }
}
