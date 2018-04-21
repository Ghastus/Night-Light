using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class title_screen_controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		fadeOutColor = new Color(0,0,0,1);
		fadeOutQuad.transform.localScale = new Vector3 (Camera.main.orthographicSize*2*Camera.main.aspect,Camera.main.orthographicSize*2,1);
	}

	public GameObject fadeOutQuad;
	Color fadeOutColor;
	bool already_pressed=false;
	// Update is called once per frame
	void Update () {
		if ((Input.GetButtonUp("Submit"))&&(!already_pressed))
		{  already_pressed = true;
			iTween.ColorTo (fadeOutQuad, iTween.Hash ("color", fadeOutColor, "time", 2, "oncomplete", "LoadNextScene","oncompletetarget",this.gameObject));
		}
	}

	void LoadNextScene()
	{
		Debug.Log ("Next!");
		SceneManager.LoadScene ("Test1");
	}
}
