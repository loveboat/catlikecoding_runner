using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	
	public static float distanceTraveled;
	
	public float acceleration;
	public Vector3 jumpVelocity;

	private bool touchingPlatform;
	
	void Update () {
		// jump if we're touching the platform
		if(touchingPlatform && Input.GetButtonDown("Jump")){
			rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
			touchingPlatform = false;
		}
		transform.Translate(5f * Time.deltaTime, 0f, 0f);
		
		distanceTraveled = transform.localPosition.x;
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
}
