using UnityEngine;
using System.Collections;

public class VictoryScreenScript : MonoBehaviour {

	public GUIStyle skin;
	
	private int width = 400;
	private int height = 400;
	private Vector2 offset;
	
	public bool isGameWin = false;

	// Use this for initialization
	void Start () {

		this.offset = new Vector2 (Screen.width / 2, Screen.height / 2);
		GameManager.GameWin += gameWin;
		GameManager.GameStart += gameStart;
		GameManager.GameOver += gameOver;
		gameStart ();
	}

	void gameOver () {

	}

	void gameStart () {
		gameObject.SetActive (false);
	}

	void gameWin() {
		gameObject.SetActive (true);
		Time.timeScale = 0;
	}
	
	void OnGUI() {
		GUIStyle h1 = new GUIStyle();
		h1.fontSize = 32;
		h1.normal.textColor = Color.white;
		
		GUI.BeginGroup (new Rect (offset.x, offset.y - 10, width, height));
		
		GUILayout.BeginHorizontal ();
		GUILayout.Label("YOU WON", h1);
		GUILayout.EndHorizontal ();
		
		GUILayout.BeginHorizontal ();
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUILayout.Button("Try Again?")) {
			Application.LoadLevel(Application.loadedLevelName);
		}
		
        if((Application.loadedLevel + 1) != null || (Application.loadedLevel + 1) != 0) {
            if(GUILayout.Button("Next Level")) {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }

		// Main Menu Button
		if(GUILayout.Button("Main Menu")) {
			Application.LoadLevel("MainMenu");
		}
		
		GUILayout.EndHorizontal ();
		GUI.EndGroup ();
	}

	void OnDestroy() {
		GameManager.GameWin -= gameWin;
		GameManager.GameStart -= gameStart;
		GameManager.GameOver -= gameOver;
	}
}
