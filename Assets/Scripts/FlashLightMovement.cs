using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		SetPositionToPlayerPosition ();
		//Cursor.lockState = true;
		Cursor.visible = false;
		Door_teleport[] all_the_doors = GameObject.FindObjectsOfType<Door_teleport> ();
		foreach (Door_teleport DT in all_the_doors) {
			DT.OnRoomEnter.AddListener (SetPositionToPlayerPosition);
		}


	}

	public Transform player;
    Light flashlight;
    float lightDistance;

	public void SetPositionToPlayerPosition()
	{SetPosition (player.position);
	}

	public void SetPosition(Vector3 Pos)
	{
		Pos.z = 0;
		transform.position = Pos;
	}
	// Update is called once per frame
	void Update () {
		////Base on Mouse position
		//Vector3 position = new Vector3 (Input.mousePosition.x,
		//	                   Input.mousePosition.y, 12);
		//
		//position =Camera.main.ScreenToWorldPoint(position);
		//position.z = 0;

		Vector3 position = transform.position;
		position.x += Input.GetAxis ("Mouse X");
		position.y += Input.GetAxis ("Mouse Y");
		transform.position = position;

        //changes radius of light based on player distance
        /*
        lightDistance = Vector3.Distance(transform.position, player.position) * 10;
        if (lightDistance >= 60)
        {
            flashlight.spotAngle = 0;
        }
        else
        {
            flashlight.spotAngle = 60 - lightDistance;
        }
        */
    }
}
