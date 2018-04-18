using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Transform destination;
	public Transform camera_destination;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			col.gameObject.transform.position = destination.position;
			Camera.main.transform.position = camera_destination.position;

		}
	}
}
