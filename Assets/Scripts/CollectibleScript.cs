using UnityEngine;

public class CollectibleScript : MonoBehaviour {
	private bool hasSpawn;
	public float massIncrement;
	public float scaleIncrement;
	
	// Use this for initialization
	void Start () {
		GameManager.GameStart += gameStart;
		GameManager.GameOver += gameOver;
		gameStart ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "rabbit"){
			other.gameObject.rigidbody2D.mass += massIncrement;
			other.gameObject.transform.localScale += new Vector3(scaleIncrement, scaleIncrement, 0);
		}
		gameObject.SetActive(false);
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
	void gameStart()
	{
		gameObject.SetActive(true);
		hasSpawn = false;
		
		// Disable everything
		// -- collider
		collider2D.enabled = false;
	}
	
	void gameOver()
	{
		
	}
	
}
