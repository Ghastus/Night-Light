using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFreezeMonster : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		MM = GetComponent<Monster_Movement> ();
			
	}
	Monster_Movement MM;
    public float mouseDistanceToFreeze = 0.5f;
	// Update is called once per frame
	void Update () {
        
        Vector3 mouse = new Vector3(Input.mousePosition.x,Input.mousePosition.y, 12);
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = -0.5f;

        if (Vector3.Distance(mouse, transform.position) < mouseDistanceToFreeze)
        {
            MM.enabled = false;
        }

    }

    /*
	void OnTriggerEnter(Collider col)
	{ if (col.gameObject.GetComponent<FlashLightMovement>()!=null) {
			MM.enabled = false;
		}
	}
    */
	void OnTriggerExit(Collider col)
	{ if (col.gameObject.GetComponent<FlashLightMovement>()!=null) {
			MM.enabled = true;
		}
	}
}
