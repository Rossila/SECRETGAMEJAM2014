using UnityEngine;
using System.Collections;

public class ControlScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MainMenuScript.MenuScreen += this.MenuScreen;
		MainMenuScript.ControlScreen += this.ControlScreen;
		gameObject.SetActive (false);
	}

	void ControlScreen ()
	{
		gameObject.SetActive (true);
	}

	void MenuScreen ()
	{
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		MainMenuScript.TriggerMainMenu ();
	}

	void OnDestroy() {
		MainMenuScript.MenuScreen -= this.MenuScreen;
		MainMenuScript.ControlScreen -= this.ControlScreen;
	}
}
