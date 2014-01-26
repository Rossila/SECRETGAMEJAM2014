﻿using UnityEngine;
using System.Collections;

public class ExitGameScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		MainMenuScript.MenuScreen += HandleMenuScreen;
		MainMenuScript.ControlScreen += HandleControlScreen;
	}

	void HandleControlScreen () {
		gameObject.SetActive (false);
	}

	void HandleMenuScreen () {
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		Application.Quit ();
	}
}
