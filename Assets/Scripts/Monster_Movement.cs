using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Movement : MonoBehaviour {



	public Transform player;
	public Transform wayPoint = null;
	public float idle_speed= 0.02f;
	public float chasing_speed = 0.03f;
	private Transform movingTowards;
	public float chaseDistance = 2f;
	private int childIndex = 0;

	// Use this for initialization
	void Start () {
		if (wayPoint != null) {
			movingTowards = wayPoint.GetChild (childIndex);
		}
	}

	// Update is called once per frame
	void Update () {

        if (wayPoint == null) {
			return;
		}
		//chases player within distance
		if (Vector3.Distance (player.position, transform.position) < chaseDistance) {
			transform.position = Vector3.MoveTowards (transform.position, player.position, chasing_speed);
		}
		else
        {//enemy pathing
            transform.position = Vector3.MoveTowards (transform.position, movingTowards.position, idle_speed);

			//switching between wayPoints
			if (Vector3.Distance (movingTowards.position, transform.position) < .01f) {
				if (childIndex == wayPoint.childCount - 1) {
					childIndex = 0;
				} else {
					childIndex++;
				}
				movingTowards = wayPoint.GetChild (childIndex);
			}


		}


	}

}
