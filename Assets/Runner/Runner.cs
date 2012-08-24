using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	
	public static float distanceTraveled;
	
	void Update () {
		transform.Translate(5f * Time.deltaTime, 0f, 0f);
		
		distanceTraveled = transform.localPosition.x;
	}
}
