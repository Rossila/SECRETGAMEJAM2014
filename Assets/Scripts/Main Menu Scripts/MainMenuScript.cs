using UnityEngine;

public class MainMenuScript : MonoBehaviour {
	
	public delegate void drawMenu();

	public static event drawMenu ControlScreen, MenuScreen;

	void Start() {

	}

	void Update() {

	}

	public static void TriggerMainMenu() {
		if (MenuScreen != null) {
			MenuScreen();
		}
	}

	public static void TriggerControlMenu() {
		if (ControlScreen != null) {
			ControlScreen();
		}
	}

}

