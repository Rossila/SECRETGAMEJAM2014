﻿using UnityEngine;
using System.Collections;

public class GameOverTxtScript : MonoBehaviour {

	public GUIStyle skin;

	private int width = 400;
	private int height = 400;
	private Vector2 offset;

	public bool isGameOver = false;


	// Use this for initialization
	void Start () {
		offset = new Vector2(Screen.width/2, Screen.height/2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUIStyle h1 = new GUIStyle();
		h1.fontSize = 32;
		h1.normal.textColor = Color.white;

		GUI.BeginGroup (new Rect (offset.x, offset.y - 10, width, height));

		GUILayout.BeginHorizontal ();
		GUILayout.Label("GAME OVER", h1);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUILayout.Button("Try Again?")) {
			//Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUILayout.Button("Main Menu")) {
			//Application.LoadLevel(2);
		}

		GUILayout.EndHorizontal ();
		GUI.EndGroup ();

	}
}
