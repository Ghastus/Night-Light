using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door_teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Transform destination;
	public Transform camera_destination;
	public UnityEvent OnRoomEnter;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			col.gameObject.transform.position = destination.position;
			Camera.main.transform.position = camera_destination.position;
			OnRoomEnter.Invoke ();
            if(camera_destination.name == "BossCamera")
            {
                Camera.main.orthographicSize = 15f;
            }
            else
            {
                Camera.main.orthographicSize = 6f;
            }
		}
	}
}
