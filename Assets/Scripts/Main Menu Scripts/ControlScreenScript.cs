using UnityEngine;
using System.Collections;

public class ControlScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MainMenuScript.MenuScreen += HandleMenuScreen;
		MainMenuScript.ControlScreen += HandleControlScreen;
		gameObject.SetActive (false);
	}

	void HandleControlScreen ()
	{
		gameObject.SetActive (true);
	}

	void HandleMenuScreen ()
	{
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		print ("Back to main menu");
		MainMenuScript.TriggerMainMenu ();
	}
}
