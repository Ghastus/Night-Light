using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {


    public Transform respawn;
    public Transform camera_destination;
	public AudioSource death;
    public BossPhaseTracker BPT;

    void Start()
    {
        BPT.GetComponent<BossPhaseTracker>();
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Monster" || col.gameObject.tag == "Boss")
        {
            transform.position = respawn.position;
            Camera.main.transform.position = camera_destination.position;
            Camera.main.orthographicSize = 6f;
            GetComponent<PlayerPhaseTracker>().CheckDoors();
			death.Play();
            if(col.gameObject.tag == "Boss")
            {
                GameObject boss = GameObject.FindGameObjectWithTag("Boss");
                boss.GetComponent<BossMovement>().enabled = false;
                BPT.resetMaze();
                //BPT.resetTriggers();
                BPT.resetBossPhase();
            }
        }
    }

    
}
