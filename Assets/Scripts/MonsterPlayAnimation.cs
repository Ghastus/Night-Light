using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlayAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayAnimation anim = GetComponent<PlayAnimation> ();
		anim.AnimationPlay (MyAnim);
			
	}
	public AnimationObject MyAnim;




}
