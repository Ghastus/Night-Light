using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour {
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;
    Vector3 targetVector;
    // Use this for initialization
    void Start () {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
		if(_navMeshAgent == null)
        {
            Debug.LogError("nav mesh agent is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
	}
	
	// Update is called once per frame
	void Update () {
        SetDestination();
        
	}

    private void SetDestination()
    {
        targetVector = _destination.transform.position;
        _navMeshAgent.SetDestination(targetVector);
    } 

    public void DecreaseSpeed()
    {
        _navMeshAgent.speed -= 1;
    }

    public void IncreaseSpeed()
    {
        _navMeshAgent.speed += 1;
    }
}
