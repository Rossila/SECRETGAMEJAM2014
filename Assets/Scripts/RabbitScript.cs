using UnityEngine;

public class RabbitScript : MonoBehaviour {
	public static float distanceTraveled;

	public Vector3 startScale;

	public Vector2 jumpSpeed;
	public Vector2 constantSpeed;

	public static bool forceGround = false;
	
	public float gameOverY;
	public float gameOverX;
	public float startMass;
	public float shrinkRate;

	public float tooMuchMass;
	public float tooLittleMass;

	public float minToBreakWall;
	public float maxToPassTree;

	public float speedLimitY;

	public Vector3 maxRabbit;

	private bool onGround;
	private Vector2 startPosition;

	private Transform camera;

	private bool Jump;
	private Animator anim;

	void Start () 
	{
		maxRabbit = new Vector3 (0.7f, 0.7f, 1f);
		anim = GetComponent<Animator>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
		GameManager.GameStart += gameStart;
		GameManager.GameOver += gameOver;
		GameManager.GameWin += gameWin;
		startPosition = transform.localPosition;
		gameStart ();
	}

	// get a scale percentage based on the mass
	float massToScale(float mass) {
		float maxMass = 1.6f;

		// for our percentage calculation
		float min = 0.3f;
		float max = 1.0f;
		return ((1f - (maxMass - mass)) * (max - min)) + min;
	}

	void Update()
	{
		if (rigidbody2D.velocity.y > speedLimitY) {
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * speedLimitY;
		}
		rigidbody2D.mass -= shrinkRate;
		//gameObject.GetComponent<BoxCollider2D> ().size -= new Vector2 (shrinkRate, shrinkRate);

		if(transform.localScale.x > 0){
			//transform.localScale -= new Vector3 (shrinkRate/2, shrinkRate/2, 0);
			float scale = massToScale(gameObject.rigidbody2D.mass);
			//other.gameObject.transform.localScale = other.gameObject.GetComponent<RabbitScript>().maxRabbit * scale;
			float localScaleX = Mathf.Lerp (gameObject.transform.localScale.x, gameObject.GetComponent<RabbitScript>().maxRabbit.x * scale, Time.deltaTime);
			float localScaleY = Mathf.Lerp (gameObject.transform.localScale.y, gameObject.GetComponent<RabbitScript>().maxRabbit.y * scale, Time.deltaTime);
			float localScaleZ = Mathf.Lerp (gameObject.transform.localScale.z, gameObject.GetComponent<RabbitScript>().maxRabbit.z * scale, Time.deltaTime);
			gameObject.transform.localScale = new Vector3(localScaleX, localScaleY, localScaleZ);
		}
		if(Input.GetButtonDown("Jump") && onGround){
			anim.SetBool ("Jump", true);
			gameObject.audio.Play ();
			rigidbody2D.AddForce(jumpSpeed);
			onGround = false;
		} else {
			if(onGround)
				anim.SetBool ("Jump", false);
		}
		//Debug.Log (transform.position.x);
		//(renderer.IsVisibleFrom(Camera.main) == false) ||
		//(transform.localPosition.x < gameOverX) ||

		if(transform.localPosition.y < gameOverY) {
			GameOverTxtScript.deathMsg = "You fell off.";
			GameManager.TriggerGameOver();
		} else if (Mathf.Abs(camera.position.x - transform.position.x) > gameOverX){
			GameOverTxtScript.deathMsg = "You could not pass.";
			GameManager.TriggerGameOver();
		} else if (rigidbody2D.mass > tooMuchMass) {
			GameOverTxtScript.deathMsg = "You were too fat.";
			GameManager.TriggerGameOver();
		} else if (rigidbody2D.mass < tooLittleMass) {
			GameOverTxtScript.deathMsg = "You were too skinny.";
			GameManager.TriggerGameOver();
		}

	}

	bool isGrounded()
	{
		Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);
		//float boxColliderSize = GetComponent <BoxCollider2D>().size.y;
		//RaycastHit2D hit = Physics2D.Raycast(currentPosition + -Vector2.up*boxColliderSize + new Vector2(0f, -0.1f), -Vector2.up, 0.4f);
		//Debug.Log (boxColliderSize);
		//Debug.Log (currentPosition + -Vector2.up * boxColliderSize + new Vector2 (0f, -0.1f));
		//return hit;
		return Physics2D.Raycast(currentPosition + -Vector2.up + new Vector2(0f, -0.1f), -Vector2.up, 0.1f);
	}

	void OnCollisionEnter2D(Collision2D other){
		/*bool grounded = (transform.position.y >= other.gameObject.transform.position.y +
						other.gameObject.GetComponent<BoxCollider2D> ().size.y) && 
						(transform.position.y < other.gameObject.transform.position.y +
						other.gameObject.GetComponent<BoxCollider2D> ().size.y+1.0f);*/

		float boxColliderSize = (GetComponent <BoxCollider2D>().size.y/2.0f)*transform.localScale.y;
		float otherColliderSize = (other.gameObject.GetComponent<BoxCollider2D> ().size.y/2.0f) * other.gameObject.transform.localScale.y;
		if ((other.gameObject.tag == "ground") && rigidbody2D.velocity.y<=15 && transform.position.y + boxColliderSize >= otherColliderSize + other.gameObject.transform.position.y ) {
			onGround = true;
		} 

		if (other.gameObject.tag == "wall" && rigidbody2D.mass >= minToBreakWall) {
			WallScript[] ws = other.gameObject.GetComponents<WallScript>();
			ws[0].BustWall();
		}

		if (other.gameObject.tag == "tree" && rigidbody2D.mass <= maxToPassTree) {
			forceGround = true;
			TreeScript[] ts = other.gameObject.GetComponents<TreeScript>();
			ts[0].MovePastTree();
		}
		if (other.gameObject.tag == "undo forceground") {
			UndoForceGround[] fs= other.gameObject.GetComponents<UndoForceGround>();
			fs[0].releaseForceGround();
		}
		
	}
	

	void OnTriggerEnter2D(Collider2D collider) {
		// check for null pointer references
		if (collider == null) {
			return;
		}
		if (collider.gameObject.tag == "enemy") {
			GameManager.TriggerGameOver();
			GameOverTxtScript.deathMsg = "You were killed.";
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
