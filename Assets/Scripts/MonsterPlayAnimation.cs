using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayAnimation))]
public class MonsterPlayAnimation : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Play ();
			
	}
	public AnimationObject MyAnim;



	public void Play()
	{
		
		PlayAnimation anim = GetComponent<PlayAnimation> ();
		anim.AnimationStop ();
		anim.AnimationPlay (MyAnim);
	}


}
