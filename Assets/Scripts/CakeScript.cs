using UnityEngine;
using System.Collections;

public class CakeScript : MonoBehaviour {
	private bool hasSpawn;

	// Use this for initialization
	void Start () {
		//startPosition = transform.localPosition;
		//gameStart ();
		hasSpawn = false;
		
		// Disable everything
		// -- collider
		collider2D.enabled = false;
	}

	bool hitWall()
	{
		Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);
		return Physics2D.Raycast(currentPosition + Vector2.right*0.73f, Vector2.right, 0.1f);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "rabbit") {
			Destroy (gameObject);
		} 
	}

	// Update is called once per frame
	void Update () {
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false)
		{
			if (renderer.IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		}
		else
		{
			// 4 - Out of the camera ? Destroy the game object.
			if (renderer.IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}
	}

	private void Spawn()
	{
		hasSpawn = true;
		
		// Enable everything
		// -- Collider
		collider2D.enabled = true;
	}
}
