using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CueItemPlayerActivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}

	AudioSource source;
	bool playing;
	bool alreadyPlayed=false;
	bool TriggerActive;

	public UnityEvent VoiceOverEnded;
	public UnityEvent VoiceOverBegan;
    public Transform player;
	public bool unpauseGameOnceSoundIsOver=true;

	public void SetTriggerActive (bool val)
	{ TriggerActive = val;
	}
	// Update is called once per frame
	void Update () {
		// check when audio is done playing
		if (playing) {
			if (!source.isPlaying) {
				playing = false;



				VoiceOverEnded.Invoke ();
				if (unpauseGameOnceSoundIsOver) {
					ResumeActivity ();
				}
			}
		}
    }

	public void ResumeActivity()
	{
		GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

		for (int i = 0; i < monsters.Length; i++) {
			monsters [i].GetComponent<Monster_Movement> ().enabled = true;
		}

		GameObject Player = GameObject.FindGameObjectWithTag ("Player");
		if (Player.GetComponent<PlayerMovement> () != null) {
			Player.GetComponent<PlayerMovement> ().enabled = true;
		}

		GameObject FL = GameObject.FindGameObjectWithTag ("Flashlight");
		if (FL.GetComponent<FlashLightMovement> () != null) {
			FL.GetComponent<FlashLightMovement> ().enabled = true;
		}
	}
    
	void OnTriggerStay(Collider col)
	{ 
		if (((!TriggerActive)||(playing))||(alreadyPlayed)) {
			return;
		}
		if (col.CompareTag ("Player")) {
			//progress
			alreadyPlayed=true;
			playing = true;
			source.Play ();


            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Player.GetComponent<PlayerPhaseTracker>().OpenFirstDoor();

			GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

			Debug.Log ("Monsters :"+monsters.Length);
			for (int i = 0; i < monsters.Length; i++) {
				monsters[i].GetComponent<Monster_Movement> ().enabled = false;
			}

			if (Player.GetComponent<PlayerMovement> () != null) {
				Player.GetComponent<PlayerMovement> ().enabled = false;
			}

			GameObject FL = GameObject.FindGameObjectWithTag ("Flashlight");
			if (FL.GetComponent<FlashLightMovement> () != null) {
				FL.GetComponent<FlashLightMovement> ().enabled = false;
			}

			VoiceOverBegan.Invoke ();
		}
	}
    
}
