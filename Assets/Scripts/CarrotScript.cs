using UnityEngine;

public class CarrotScript : MonoBehaviour {

	public Vector3 spawnLocation;

	public float massIncrement;
	public float scaleIncrement;

	// Use this for initialization
	void Start () {
		gameStart ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void gameStart(){
		gameObject.SetActive (true);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "rabbit"){
			other.gameObject.rigidbody2D.mass += massIncrement;
			other.gameObject.transform.localScale += new Vector3(scaleIncrement, scaleIncrement, 0);
		}
		gameObject.SetActive(false);
	}
}
