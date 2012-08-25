using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	
	public static float distanceTraveled;
	
	public float acceleration;
	public Vector3 boostVelocity, jumpVelocity;
	public float gameOverY;

	private bool touchingPlatform;
	private Vector3 startPosition;
	
	private static int boosts;

	void Start () {
		boosts = 0;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		startPosition = transform.localPosition;
		gameObject.active = false;
		enabled = true;
	}
	
	void Update () {
		// jump if we're touching the platform
		if (Input.GetButtonDown("Jump")) {
			if (touchingPlatform) {
				rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
				touchingPlatform = false;
			}
			else if (boosts > 0) {
				rigidbody.AddForce(boostVelocity, ForceMode.VelocityChange);
				boosts -= 1;
			}	
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
		rigidbody.isKinematic = false;
		gameObject.active = true;
		enabled = true;
	}

	private void GameOver () {
		rigidbody.isKinematic = true;
		enabled = false;
	}
	
	public static void AddBoost(){
		boosts += 1;
	}
}
