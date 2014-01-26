using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	public Sprite bustedWall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BustWall() {
		SpriteRenderer[] sr = gameObject.GetComponents<SpriteRenderer> ();
		sr[0].sprite = bustedWall;

		transform.collider2D.isTrigger = true;
	}
}
