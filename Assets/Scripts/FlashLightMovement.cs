using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        flashlight = transform.GetChild(0).GetComponent<Light>();
        lightRadius = 60;
        lightOff = false;
	}

	public Transform player;
    Light flashlight;
    float lightDistance;
    float lightRadius;
    bool lightOff;

	// Update is called once per frame
	void Update () {
		Vector3 position = new Vector3 (Input.mousePosition.x,
			                   Input.mousePosition.y, 12);
		
		position =Camera.main.ScreenToWorldPoint(position);
		position.z = 0;
		transform.position = position;

        // turns light off if on boss for too long
        if (lightOff)
        {
            flashlight.spotAngle = 0;
        }
        else 
        { //changes radius of light based on player distance
            /*
            lightDistance = Vector3.Distance(transform.position, player.position) * 10;
            if (lightDistance >= 60)
            {
                lightRadius = 0;
            }
            else
            {
                lightRadius = 60 - lightDistance;
            }
            */
            flashlight.spotAngle = lightRadius;
        }

    }

    public float getLightRadius()
    {
        return lightRadius;
    }

    public void setLightOff(bool lightOff)
    {
        this.lightOff = lightOff;
    }
}
