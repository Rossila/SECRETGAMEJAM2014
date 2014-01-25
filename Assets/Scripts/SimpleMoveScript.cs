using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class SimpleMoveScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed;
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction;
	
	private Vector2 movement;
	
	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}
}
