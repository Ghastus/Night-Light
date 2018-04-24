using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFreezeBoss : MonoBehaviour {

    BossMovement BM;
    FlashLightMovement FLM;
    public Transform flashLightObject;
    public float mouseDistanceToFreeze = 1f;
    bool alreadySlowed;
    public float LightOffDuration;
    public float LightOnDuration;
    public float SlowDuration;
    float timerLightOff;
    float timerLightOn;
    float timerSlow;
    Light flashlight;

    // Use this for initialization
    void Start () {
        BM = GetComponent<BossMovement>();
        FLM = flashLightObject.GetComponent<FlashLightMovement>();
        flashlight = transform.GetChild(0).GetComponent<Light>();
        alreadySlowed = false;
        timerLightOff = LightOffDuration;
        timerLightOn = LightOnDuration;
        timerSlow = SlowDuration;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12);
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = -0.5f;

        //while mouse is on the boss
        if (Vector3.Distance(mouse, transform.position) < mouseDistanceToFreeze)
        {
            //reset lightOn and slow duration
            timerLightOn = LightOnDuration;
            timerSlow = SlowDuration;

            //slows boss if not already slowed
            if (!alreadySlowed)
            {
                BM.DecreaseSpeed();
                alreadySlowed = true;
            }
            

            //turns light off after a duration
            timerLightOff -= Time.deltaTime;
            if(timerLightOff < 0)
            {
                FLM.setLightOff(true);
            }
        }
        else
        {
            //reset lightOff duration
            timerLightOff = LightOffDuration;
            if (alreadySlowed)
            {
                //turns light on after a duration
                timerLightOn -= Time.deltaTime;
                if (timerLightOn < 0)
                {
                    FLM.setLightOff(false);
                }

                //changes boss speed back to normal after a duration
                timerSlow -= Time.deltaTime;
                if (timerLightOn < 0)
                {
                    alreadySlowed = false;
                    BM.IncreaseSpeed();
                }
            }
        }

    }

    /*
	void OnTriggerEnter(Collider col)
	{ if (col.gameObject.GetComponent<FlashLightMovement>()!=null) {
			BM.DecreaseSpeed();
		}
	}
    
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<FlashLightMovement>() != null)
        {
            alreadySlowed = false;
            BM.IncreaseSpeed();
        }
    }
    */
}
