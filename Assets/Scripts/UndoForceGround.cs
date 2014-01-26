using UnityEngine;

public class UndoForceGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		// Use this for initialization
	public void releaseForceGround(){
		Debug.Log ("Test");
		transform.collider2D.isTrigger = true;
		RabbitScript.forceGround = false;
	}

}
