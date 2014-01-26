﻿using UnityEngine;

public class RabbitScript : MonoBehaviour {
	public static float distanceTraveled;

	public Vector3 startScale;

	public Vector2 jumpSpeed;
	public Vector2 constantSpeed;
	
	public float gameOverY;
	public float gameOverX;
	public float startMass;
	public float shrinkRate;

	public float tooMuchMass;
	public float tooLittleMass;

	private bool onGround;
	private Vector2 startPosition;

	void Start () 
	{
		GameManager.GameStart += gameStart;
		GameManager.GameOver += gameOver;
		startPosition = transform.localPosition;
		gameStart ();
	}

	void Update()
	{
		rigidbody2D.mass -= shrinkRate;
		//gameObject.GetComponent<BoxCollider2D> ().size -= new Vector2 (shrinkRate, shrinkRate);
		if(transform.localScale.x > 0)
			transform.localScale -= new Vector3 (shrinkRate/2, shrinkRate/2, 0);
		print ("mass:"+rigidbody2D.mass);
		print ("size:" + transform.localScale.x);
		if(Input.GetButton("Jump") && onGround){
			rigidbody2D.AddForce(jumpSpeed);
			Debug.Log(rigidbody2D.velocity.y);
			onGround = false;
		}
		if((transform.localPosition.y < gameOverY) ||
		   //(renderer.IsVisibleFrom(Camera.main) == false) ||
		   (transform.localPosition.x < gameOverX) ||
		   (rigidbody2D.mass > tooMuchMass) ||
		   (rigidbody2D.mass < tooLittleMass)){
			GameManager.TriggerGameOver();
		}
	
	}

	bool hitWall()
	{
		Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);
		RaycastHit2D hit = Physics2D.Raycast(currentPosition + Vector2.right*0.73f, Vector2.right, 0.1f);
		Debug.Log (hit.collider.tag);
		return hit;
	}

	void OnCollisionEnter2D(Collision2D other){
		if ((other.gameObject.tag == "ground")) {
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
		gameObject.SetActive(false);
	}
	
}
