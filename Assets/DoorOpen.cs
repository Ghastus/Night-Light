using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour 

{

	[SerializeField] AudioSource door;

	void OnTriggerEnter (Collider Player)
	{
		if (Player.CompareTag("Player"))
		door.Play();
	}
}
