using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseTracker : MonoBehaviour {

    int bossPhase;
    public Transform mazes;

    // Use this for initialization
    void Start () {
        bossPhase = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void switchMaze()
    {
        //ends if mazes runs out
        if (bossPhase > mazes.childCount)
        {
            return;
        }

        //turns off current maze
        if (bossPhase != 1)
        {
            mazes.GetChild(bossPhase - 2).gameObject.SetActive(false);
        }

        //turns on next maze
        if (bossPhase != mazes.childCount+1)
        {
            mazes.GetChild(bossPhase - 1).gameObject.SetActive(true);
        }
    }

    public void resetMaze()
    {
        for (int i = 0; i < mazes.childCount; i++)
        {
            mazes.GetChild(i).gameObject.SetActive(false);
        }

    }

    public void resetBossPhase()
    {
        bossPhase = 0;
    }

    public void addBossPhase()
    {
        bossPhase++;
    }

    public int getBossPhase()
    {
        return bossPhase;
    }

}
