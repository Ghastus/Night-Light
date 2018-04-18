using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMovementAnimation : MonoBehaviour {

	// Use this for initialization
	public AnimationObject IdleAnimationFront;
	public AnimationObject IdleAnimationBack;
	public AnimationObject IdleAnimationLeft;
	public AnimationObject IdleAnimationRight;
	Vector3 direction = Vector3.down;

	public AnimationObject RightMovement;
	public AnimationObject LeftMovement;
	public AnimationObject FrontMovement;
	public AnimationObject BackMovement;

	void Start () {
		Anim = GetComponent<PlayAnimation> ();

	}
	PlayAnimation Anim;
	public Rigidbody RB;
	// Update is called once per frame
	void Update () {
		float x_speed = RB.velocity.x;
		float y_speed = RB.velocity.y;

		//idle check
		if (RB.velocity.magnitude < 0.25) {
			if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) {
				if (direction.x > 0) {
					Anim.AnimationPlay (IdleAnimationRight);
				}
				if (direction.x < 0) {
					Anim.AnimationPlay (IdleAnimationLeft);
				}
			}
			else {
				if (direction.y > 0) {
					Anim.AnimationPlay (IdleAnimationBack);
				}
				if (direction.y < 0) {
					Anim.AnimationPlay (IdleAnimationFront);
				}
			}

		//right left movement
		} else if (Mathf.Abs (x_speed) > Mathf.Abs (y_speed)) {
			if (x_speed > 0) {
				Anim.AnimationPlay (RightMovement);
			}
			if (x_speed < 0) {
				Anim.AnimationPlay (LeftMovement);
			}
		} else {
			//up or down
			if (y_speed > 0) {
				Anim.AnimationPlay (BackMovement);
			}
			if (y_speed < 0) {
				Anim.AnimationPlay (FrontMovement);
			}
		}

		direction = RB.velocity;
		
	}
}
