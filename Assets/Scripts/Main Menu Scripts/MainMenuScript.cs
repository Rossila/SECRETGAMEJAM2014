using UnityEngine;

public static class MainMenuScript {
	
	public delegate void drawMenu();

	public static event drawMenu ControlScreen, MenuScreen;

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
