using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	
	public static float distanceTraveled;
	
	public float acceleration;
	public Vector3 jumpVelocity;
	public float gameOverY;

	private bool touchingPlatform;
	private Vector3 startPosition;

	void Start () {
		GameEventManager.GameStart += GameStart;
		startPosition = transform.localPosition;
		gameObject.active = false;
	}
	
	void Update () {
		// jump if we're touching the platform
		if(touchingPlatform && Input.GetButtonDown("Jump")){
			rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
			touchingPlatform = false;
		}
		distanceTraveled = transform.localPosition.x;
		
		if (transform.localPosition.y < gameOverY){
			GameEventManager.TriggerGameOver();
		}
	}
	
	void FixedUpdate () {
		if (touchingPlatform){
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
		}
	}

	void OnCollisionEnter () {
		touchingPlatform = true;
	}

	void OnCollisionExit () {
		touchingPlatform = false;
	}
	
	private void GameStart () {
		distanceTraveled = 0f;
		transform.localPosition = startPosition;
		gameObject.active = true;
	}
}
