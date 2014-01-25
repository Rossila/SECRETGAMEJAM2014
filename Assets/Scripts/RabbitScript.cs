﻿using UnityEngine;

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
		if(Input.GetButton("Jump") && onGround){
			rigidbody2D.AddForce(jumpSpeed);
			Debug.Log(rigidbody2D.velocity.y);
			onGround = false;
		}
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
