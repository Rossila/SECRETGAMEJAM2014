using UnityEngine;
using System.Collections;

public class HungerBarScript : MonoBehaviour {
	
	private float maxLength;
	private float length;

	// energy
	private float maxEnergy = 100f;
	private float currEnergy;

	// slider offset to fit the energy bar
	public Vector2 offset = new Vector2(40, 40);

	// make slider white for tinting
	public GUIStyle energySlider;
	private int sliderHeight;
	private int sliderWidth = 5;

	private bool winLossScreen;

	// Use this for initialization
	void Start () {
		GameManager.GameStart += gameStart;
		GameManager.GameOver += gameOver;
		GameManager.GameWin += gameWin;
		Time.timeScale = 1;
		gameStart ();
	}

	// Update is called once per frame
	void Update () {
		GameObject rabbit = GameObject.FindGameObjectWithTag ("rabbit");
		if (rabbit != null && !winLossScreen) {
			AdjustCurrEnergy (GameObject.FindGameObjectWithTag("rabbit").rigidbody2D.mass);
		}
	}

	void OnGUI() {
		// get position of the hunger bar
		GameObject bar = GameObject.FindGameObjectWithTag ("hungerbar");
		Rect hungerRect = BoundsToScreenRect (bar.renderer.bounds);
		sliderHeight = (int) hungerRect.height;

		maxLength = hungerRect.width * 2 - 10;

		GUI.BeginGroup (new Rect (hungerRect.x + 2, hungerRect.y, maxLength, sliderHeight));
		GUI.backgroundColor = Color.blue;

		// energy slider
		GUI.Box(new Rect(length/2, 0, sliderWidth, sliderHeight), "", energySlider);

		GUI.EndGroup();
	}
	
	public void AdjustCurrEnergy(float i) {
		currEnergy = i*50;
		
		if (currEnergy < 0) {
			currEnergy = 0;
		} else if (currEnergy > maxEnergy) {
			currEnergy = maxEnergy;
		}

		length = (currEnergy / maxEnergy) * maxLength;

	}
	public void gameStart() {
		currEnergy = maxEnergy/2;
		this.winLossScreen = false;
	}

	public void gameOver() {
		this.winLossScreen = true;
	}

	void gameWin () {
		this.winLossScreen = true;
	}

	public Rect BoundsToScreenRect(Bounds bounds)
	{
		// Get mesh origin and farthest extent (this works best with simple convex meshes)
		Vector3 origin = Camera.main.WorldToScreenPoint(new Vector3(bounds.min.x, bounds.max.y, 0f));
		Vector3 extent = Camera.main.WorldToScreenPoint(new Vector3(bounds.max.x, bounds.min.y, 0f));
		
		// Create rect in screen space and return - does not account for camera perspective
		return new Rect(origin.x, Screen.height - origin.y, extent.x - origin.x, origin.y - extent.y);
	}
}
