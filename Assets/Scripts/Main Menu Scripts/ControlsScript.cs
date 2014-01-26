using UnityEngine;
using System.Collections;

public class ControlsScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		MainMenuScript.MenuScreen += this.MenuScreen;
		MainMenuScript.ControlScreen += this.ControlScreen;
	}

	void ControlScreen () {
		gameObject.SetActive (false);
	}

	void MenuScreen () {
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		MainMenuScript.TriggerControlMenu ();
	}

	void OnDestroy() {
		MainMenuScript.MenuScreen -= this.MenuScreen;
		MainMenuScript.ControlScreen -= this.ControlScreen;
	}
}
