using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour 

{

	[SerializeField] AudioSource walk;

	void Update()
	{
		if (Input.GetButton ("Vertical"))
		{
			walk.enabled = true;
			walk.loop = true;
		}

		else if (Input.GetButton ("Horizontal"))
		{
			walk.enabled = true;
			walk.loop = true;
		}

		else
		{
			walk.enabled = false;
			walk.loop = false;
		}

	}
}
		