using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTriggerSound : MonoBehaviour {

	// Use this for initialization

	public AudioClip Sound;
	public float distance;
	public Transform listener;
	AudioSource source;

	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, listener.position)<distance) {
			if (!source.isPlaying) {
				source.clip = Sound;
				source.Play ();


			}
		}
	}
}
