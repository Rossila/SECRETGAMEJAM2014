using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {
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
				gameObject.SetActive (false);
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
