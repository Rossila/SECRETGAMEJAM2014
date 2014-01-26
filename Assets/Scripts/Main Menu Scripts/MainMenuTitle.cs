using UnityEngine;
using System.Collections;

public class MainMenuTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Box (new Rect (Screen.width / 3 - 25, Screen.height / 3, 300, 25), "Carrots and Cakes");
	}
}
