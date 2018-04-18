using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour 
{
	[SerializeField] AudioSource alert;
    public Transform player;
    public float soundDistance = 2f;

    private void Update()
    {
        {
            if (Vector3.Distance(player.position, transform.position) < soundDistance)
            {
                alert.enabled = true;
                alert.loop = true;
            }
            else
            {
                alert.enabled = false;
                alert.loop = false;
            }
        }
    }

    //void OnTriggerEnter(Collider player)
	//{
	//	if (player.CompareTag ("Player"))
	//		alert.enabled = true;
	//		alert.loop = true;
	//}
	//void OnTriggerExit(Collider player)
	//{
	//	if (player.CompareTag ("Player"))
	//		alert.enabled = false;
	//		alert.loop = false;
	//}
}
