using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public Transform player;
	// Update is called once per frame
	void Update () {
		Vector3 position = new Vector3 (Input.mousePosition.x,
			                   Input.mousePosition.y, 12);
		
		position =Camera.main.ScreenToWorldPoint(position);
		position.z = 0;
		transform.position = position;

	}

	void OnTriggerEnter(Collider other) {
		
	}
}
