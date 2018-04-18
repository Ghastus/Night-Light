using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFreezeMonster : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		MM = GetComponent<Monster_Movement> ();
			
	}
	Monster_Movement MM;
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{ if (col.gameObject.GetComponent<FlashLightMovement>()!=null) {
			MM.enabled = false;
		}

	}

	void OnTriggerExit(Collider col)
	{ if (col.gameObject.GetComponent<FlashLightMovement>()!=null) {
			MM.enabled = true;
		}

	}
}
