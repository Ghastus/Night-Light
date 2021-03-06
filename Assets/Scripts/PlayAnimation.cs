﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		mat = GetComponent<Renderer> ().material;
		currentAnimation = null;
	}


	AnimationObject currentAnimation;
	int currentFrame;
	float delay_time;
	Material mat;

	public void AnimationPlay (AnimationObject Anim)
	{
		if (Anim == currentAnimation) {
			return;
		}
		currentAnimation = Anim;
		delay_time = 1 / Anim.framerate;
		currentFrame = 0;
		StopAllCoroutines ();
		StartCoroutine ("AnimationIterate");
	}

	public void AnimationStop ()
	{
		currentAnimation = null;
		StopAllCoroutines ();
	}

	IEnumerator AnimationIterate ()
	{	
		while ((mat!=null)&&(currentAnimation!=null)) {
			mat.mainTexture = currentAnimation.frames [currentFrame];
			yield return new WaitForSeconds (delay_time);
			currentFrame++;
			if (currentFrame >= currentAnimation.frames.Length) {
				currentFrame = 0;
			}
		}
	}
}
