using UnityEngine;

public class RabbitScript : MonoBehaviour {
	public static float distanceTraveled;

	public Vector3 startScale;

	public Vector2 jumpSpeed;
	public Vector2 constantSpeed;
	
	public float gameOverY;
	public float startMass;

	private bool onGround;
	private Vector2 startPosition;

	void Start () 
	{
		startPosition = transform.localPosition;
		gameStart ();
	}
	
	void Update()
	{
		// ...
		if(Input.GetButton("Jump") && onGround){
			rigidbody2D.AddForce(jumpSpeed);
			Debug.Log(rigidbody2D.velocity.y);
			onGround = false;
		}
		
		// 6 - Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);
		
		// End of the update method
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = new Vector2 (constantSpeed.x / rigidbody2D.mass, rigidbody2D.velocity.y);
	}

	bool hitWall()
	{
		Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);
		return Physics2D.Raycast(currentPosition + Vector2.right*0.73f, Vector2.right, 0.1f);
	}

	void OnCollisionEnter2D(Collision2D other){
		if ((other.gameObject.tag == "ground") && hitWall ()) {
			Destroy (gameObject);
		} 
		else if (other.gameObject.tag == "ground") {
			onGround = true;
		}

	}

	void gameStart()
	{
		transform.localPosition = startPosition;
		rigidbody2D.mass = startMass;
		transform.localScale = startScale;
	}

	void gameOver()
	{
		rigidbody2D.velocity = Vector2.zero;
	}
}
