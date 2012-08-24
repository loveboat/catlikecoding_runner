using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	
	void Update () {
		transform.Translate(5f * Time.deltaTime, 0f, 0f);
	}
}
