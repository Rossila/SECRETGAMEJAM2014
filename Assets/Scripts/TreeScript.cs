using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MovePastTree() {
		transform.collider2D.isTrigger = true;
	}
}
