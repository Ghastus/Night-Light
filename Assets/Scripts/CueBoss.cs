using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBoss : MonoBehaviour {

    bool alreadyTriggered = false;
    GameObject boss;
    public BossPhaseTracker BPT;
    public Transform bossObject;
    public Transform bossTeleportPos;

	// Use this for initialization
	void Start () {
        boss = GameObject.FindGameObjectWithTag("Boss");
        BPT.GetComponent<BossPhaseTracker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            BPT.addBossPhase();
            BPT.switchMaze();
            if(BPT.getBossPhase() == 1)
            {
                boss.GetComponent<BossMovement>().enabled = true;
            }
            bossObject.position = bossTeleportPos.position;

            alreadyTriggered = true;
        }
    }

}
