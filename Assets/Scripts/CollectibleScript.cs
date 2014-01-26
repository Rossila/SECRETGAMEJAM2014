using UnityEngine;

public class CollectibleScript : MonoBehaviour {
	private bool hasSpawn;
	public float massIncrement;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
		GameManager.GameStart += gameStart;
		GameManager.GameOver += gameOver;
		GameManager.GameWin += gameWin;
		gameStart ();
	}

	// get a scale percentage based on the mass
	float massToScale(float mass) {
		float maxMass = 1.6f;
		float minMass = 0.6f;
		
		return 1f - (maxMass - mass);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "rabbit"){
			AudioSource.PlayClipAtPoint(clip, transform.position);
			other.gameObject.rigidbody2D.mass += massIncrement;
			float scale = massToScale(other.gameObject.rigidbody2D.mass);
			//other.gameObject.transform.localScale = other.gameObject.GetComponent<RabbitScript>().maxRabbit * scale;
			float localScaleX = Mathf.Lerp (other.gameObject.transform.localScale.x, other.gameObject.GetComponent<RabbitScript>().maxRabbit.x * scale, Time.deltaTime);
			float localScaleY = Mathf.Lerp (other.gameObject.transform.localScale.y, other.gameObject.GetComponent<RabbitScript>().maxRabbit.y * scale, Time.deltaTime);
			float localScaleZ = Mathf.Lerp (other.gameObject.transform.localScale.z, other.gameObject.GetComponent<RabbitScript>().maxRabbit.z * scale, Time.deltaTime);
			other.gameObject.transform.localScale = new Vector3(localScaleX, localScaleY, localScaleZ);
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
	void gameStart() {
		gameObject.SetActive(true);
		hasSpawn = false;
		
		// Disable everything
		// -- collider
		collider2D.enabled = false;
	}
	
	void gameOver() {
		
	}

	void gameWin () {
		
	}

	void OnDestroy()
	{
		GameManager.GameStart -= gameStart;
		GameManager.GameOver -= gameOver;
		GameManager.GameWin -= gameWin;
	}
	
}
