using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueItemDisplay : MonoBehaviour {



	public Texture illustration;
	public string[] LinesOfText;
	int current_line=0;

	GameObject FadeInOverlay;
	GameObject FadeInBackground;
	GameObject IllustrationDisplay;
	GameObject TextDisplay;
	CueItemPlayerActivate CIPA;

	TextMesh CurrentText;
	Color FadedInColor;
	Color FadedOutColor;
	bool allow_dismissal;
	// Use this for initialization
	void Start () {
		FadeInOverlay = transform.Find ("FadeInOverlay").gameObject;
		FadeInBackground = transform.Find ("FadeInBackground").gameObject;
		IllustrationDisplay = transform.Find ("IllustrationDisplay").gameObject;
		TextDisplay = transform.Find ("TextDisplay").gameObject;

		CurrentText = TextDisplay.GetComponent<TextMesh> ();

		FadeInOverlay.SetActive (false);
		FadeInBackground.SetActive (false);
		IllustrationDisplay.SetActive (false);
		TextDisplay.SetActive (false);
		FadedInColor = new Color (0, 0, 0, 1);
		FadedOutColor = new Color (0, 0, 0, 0);

		current_line = 0;


		CIPA = GetComponent<CueItemPlayerActivate> ();
		if (CIPA==null)
		foreach (Transform child in transform.parent) {
				Debug.Log ("I found it!2");
			CIPA = child.GetComponent<CueItemPlayerActivate> (); 
			if (CIPA != null)
				break;
		}

		if (CIPA!=null) {
			Debug.Log ("I found it!3");
			CIPA.VoiceOverBegan.AddListener(BeginDisplay);
			CIPA.VoiceOverEnded.AddListener(AllowDismissal);
			CIPA.unpauseGameOnceSoundIsOver = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetButtonUp ("Submit"))||(Input.GetMouseButtonUp(0))) {

			if (current_line<LinesOfText.Length-1) {
				current_line++;
				CurrentText.text = LinesOfText [current_line];
			}
			else if (allow_dismissal)
			{
				iTween.ColorTo (FadeInOverlay, iTween.Hash ("color", FadedInColor, "time", 0.1f, "oncomplete", "EndDisplay","oncompletetarget",this.gameObject));
			}
		}
	}

	public void BeginDisplay ()
	{	allow_dismissal = false;
		transform.position = new Vector3 (Camera.main.transform.position.x,Camera.main.transform.position.y,0);
		FadeInOverlay.SetActive (true);
		FadeInOverlay.GetComponent<Renderer> ().material.color = FadedOutColor;
		FadeInOverlay.transform.localScale = new Vector3 ((Camera.main.orthographicSize*2*Camera.main.aspect),Camera.main.orthographicSize*2,1);
		iTween.ColorTo (FadeInOverlay, iTween.Hash ("color", FadedInColor, "time", 0.25f, "oncomplete", "Display","oncompletetarget",this.gameObject));
	}

	public void AllowDismissal ()
	{
		allow_dismissal = true;
	}
	void Display ()
	{
		Debug.Log ("Display!");
		FadeInBackground.SetActive (true);
		IllustrationDisplay.SetActive (true);
		IllustrationDisplay.GetComponent<Renderer> ().material.mainTexture = illustration;
		TextDisplay.SetActive (true);
		if (LinesOfText.Length>0)
		{CurrentText.text = LinesOfText [0];
		}
		current_line = 0;
		FadeInBackground.GetComponent<Renderer> ().material.color = FadedInColor;
		FadeInBackground.transform.localScale = new Vector3 ((Camera.main.orthographicSize*2*Camera.main.aspect),Camera.main.orthographicSize*2,1);
		iTween.ColorTo (FadeInOverlay, iTween.Hash ("color", FadedOutColor, "time", 0.1f ));

	}

	void EndDisplay ()
	{
		FadeInBackground.SetActive (false);
		IllustrationDisplay.SetActive (false);
		TextDisplay.SetActive (false);
		iTween.ColorTo (FadeInOverlay, iTween.Hash ("color", FadedOutColor, "time", 0.25f ));
		allow_dismissal = false;
		if (CIPA != null) {
			CIPA.ResumeActivity ();
		}
	}
}
