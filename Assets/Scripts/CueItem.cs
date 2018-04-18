using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public GameObject SpecialEffect;
	public CueItemPlayerActivate CIPA; 
	bool permanent=false;

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{ if (col.gameObject.GetComponent<FlashLightMovement>()!=null) {
			SpecialEffect.SetActive (true);
			CIPA.SetTriggerActive (true);

		}

	}

	void OnTriggerExit(Collider col)
	{ if (permanent) {return;
		}
		if (col.gameObject.GetComponent<FlashLightMovement>()!=null) {
			SpecialEffect.SetActive (false);
			CIPA.SetTriggerActive (false);

		}

	}

	public void PerminantSpecialEffects()
	{SpecialEffect.SetActive (true);
		permanent = true;
	}
}
