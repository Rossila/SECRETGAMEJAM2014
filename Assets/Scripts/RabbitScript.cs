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
		GameManager.GameWin += gameWin;
		startPosition = transform.localPosition;
		gameStart ();
	}

	void Update()
	{
		rigidbody2D.mass -= shrinkRate;
		//gameObject.GetComponent<BoxCollider2D> ().size -= new Vector2 (shrinkRate, shrinkRate);
		if(transform.localScale.x > 0)
			transform.localScale -= new Vector3 (shrinkRate/2, shrinkRate/2, 0);
		if(Input.GetButtonDown("Jump") && onGround){
			onGround = false;
			gameObject.audio.Play ();
			rigidbody2D.AddForce(jumpSpeed);

		}
		if((transform.localPosition.y < gameOverY) ||
		   //(renderer.IsVisibleFrom(Camera.main) == false) ||
		   (transform.localPosition.x < gameOverX) ||
		   (rigidbody2D.mass > tooMuchMass) ||
		   (rigidbody2D.mass < tooLittleMass)){
			GameManager.TriggerGameOver();
		}
	
	}

	bool isGrounded()
	{
		Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);
		float boxColliderSize = GetComponent <BoxCollider2D>().size.y;
		//RaycastHit2D hit = Physics2D.Raycast(currentPosition + -Vector2.up*boxColliderSize + new Vector2(0f, -0.1f), -Vector2.up, 0.4f);
		//Debug.Log (boxColliderSize);
		//Debug.Log (currentPosition + -Vector2.up * boxColliderSize + new Vector2 (0f, -0.1f));
		//return hit;
		return Physics2D.Raycast(currentPosition + -Vector2.up + new Vector2(0f, -0.1f), -Vector2.up, 0.1f);
	}

	void OnCollisionEnter2D(Collision2D other){
		bool grounded = (transform.position.y >= other.gameObject.transform.position.y +
						other.gameObject.GetComponent<BoxCollider2D> ().size.y) && 
						(transform.position.y < other.gameObject.transform.position.y +
						other.gameObject.GetComponent<BoxCollider2D> ().size.y+1.0f);

		if ((other.gameObject.tag == "ground") && grounded ) {
			onGround = true;
		} 

	}

	void OnTriggerEnter2D(Collider2D collider) {
		// check for null pointer references
		if (collider == null) {
			return;
		}

		if (collider.gameObject.tag == "enemy") {
			GameManager.TriggerGameOver();
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

	void gameWin() {

	}

	void OnDestroy(){
		GameManager.GameStart -= gameStart;
		GameManager.GameOver -= gameOver;
		GameManager.GameWin -= gameWin;
	}
}
