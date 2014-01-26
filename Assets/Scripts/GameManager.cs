using UnityEngine;

public static class GameManager{
	public delegate void GameEvent();
	
	public static event GameEvent GameStart, GameOver, GameWin;
	
	public static void TriggerGameStart(){
		if(GameStart != null){
			GameStart();
		}
	}
	
	public static void TriggerGameOver(){
		if(GameOver != null){
			GameOver();
		}
	}

	public static void TriggerGameWin() {
		if (GameWin != null) {
			GameWin();
		}
	}
}
