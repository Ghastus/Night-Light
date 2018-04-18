using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundActivation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}


	public AudioClip sound;
	AudioSource source;

	public bool PlayOnlyOnce=true;
	bool already_played =false;
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col)
	{
		if (PlayOnlyOnce && already_played) {
			return;
		}
		if (col.gameObject.tag == "Player")
		{
			if (!source.isPlaying) {
				source.clip = sound;
				source.Play ();
				Debug.Log ("OnTriggerEnter Sound "+col.gameObject.name);
			}
		}
	}
}
