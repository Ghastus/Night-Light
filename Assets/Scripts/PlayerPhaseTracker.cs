using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhaseTracker : MonoBehaviour {



	int ActivatedCuesCount=-1;
    GameObject[] Doors;

    public int Phase {
		get {
			return ((ActivatedCuesCount / 2) + 1);
		}
	}


	public void AddActivatedCue ()
	{ActivatedCuesCount++;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OpenFirstDoor()
    {
        
        Doors = GameObject.FindGameObjectsWithTag("Phase1Door");
        for (int i = 0; i < Doors.Length; i++)
        {
            Doors[i].SetActive(false);
        }
        
    }
	public void CheckDoors()
	{
        if (Phase == 2) {
			Doors = GameObject.FindGameObjectsWithTag ("Phase2Door");
			for (int i = 0; i < Doors.Length; i++) {
				Doors [i].SetActive (false);
			}
		}
		if (Phase == 3) {
			Doors = GameObject.FindGameObjectsWithTag ("Phase3Door");
			for (int i = 0; i < Doors.Length; i++) {
				Doors [i].SetActive (false);
			}
		}
		if (Phase == 4) {
			Doors = GameObject.FindGameObjectsWithTag ("Phase4Door");
			for (int i = 0; i < Doors.Length; i++) {
				Doors [i].SetActive (false);
			}
		}
		if (Phase == 5) {
			Doors = GameObject.FindGameObjectsWithTag ("Phase5Door");
			for (int i = 0; i < Doors.Length; i++) {
				Doors [i].SetActive (false);
			}
		}
	}
}
