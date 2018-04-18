using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour 
{
	[SerializeField] AudioSource alert;

	void OnTriggerEnter(Collider player)
	{
		if (player.CompareTag ("Player"))
			alert.enabled = true;
			alert.loop = true;
	}
	void OnTriggerExit(Collider player)
	{
		if (player.CompareTag ("Player"))
			alert.enabled = false;
			alert.loop = false;
	}
}
