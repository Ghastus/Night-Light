using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {





	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
	
	}

	Rigidbody RB;

	// Update is called once per frame
	void Update () {
		Vector3 delta=Vector3.zero;
		//delta.x = Input.GetAxis ("Horizontal") *  Time.deltaTime;
		delta.x= Input.GetAxis ("Horizontal")*0.2f;
		delta.y= Input.GetAxis ("Vertical")*0.2f;
		//RB.MovePosition (RB.position+delta);
		RB.AddForce(delta ,ForceMode.VelocityChange);



	}

	void OnCollisionEnter(Collision col)
	{//Debug.Log ("collide");
	}





}
