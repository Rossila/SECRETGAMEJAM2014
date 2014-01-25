using UnityEngine;
using System.Collections;

public class HungerBarScript : MonoBehaviour {
	
	public float maxLength = 600;
	private float length;

	// energy
	private float maxEnergy = 100f;
	private float currEnergy;
	private float hungerSpeed = -1f;

	// slider offset to fit the energy bar
	public Vector2 offset = new Vector2(40, 40);

	// make slider white for tinting
	public GUIStyle energySlider;
	private int sliderHeight = 30;
	private int sliderWidth = 5;

	// Use this for initialization
	void Start () {
		currEnergy = maxEnergy;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrEnergy (hungerSpeed);
	}

	void OnGUI() {
		GUI.BeginGroup (new Rect (offset.x, offset.y, maxLength, sliderHeight));
		GUI.backgroundColor = Color.blue;

		// energy slider
		GUI.Box(new Rect(length, 0, sliderWidth, sliderHeight), "", energySlider);

		GUI.EndGroup();
	}
	
	public void AdjustCurrEnergy(float i) {
		currEnergy += i * 0.1f;
		
		if (currEnergy < 0) {
			currEnergy = 0;
		} else if (currEnergy > maxEnergy) {
			currEnergy = maxEnergy;
		}

		length = (currEnergy / maxEnergy) * maxLength;
	}

}
