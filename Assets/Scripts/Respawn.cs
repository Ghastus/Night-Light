using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {


    public Transform respawn;
    public Transform camera_destination;
	public AudioSource death;


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Monster")
        {
            transform.position = respawn.position;
            Camera.main.transform.position = camera_destination.position;
            Camera.main.orthographicSize = 6f;
            GetComponent<PlayerPhaseTracker>().CheckDoors();
			death.Play();
        }
    }

    
}
