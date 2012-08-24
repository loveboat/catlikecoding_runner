using UnityEngine;
using System.Collections;

public class SkylineManager : MonoBehaviour {

	public Transform prefab;
	public int numberOfCubes;

	private Vector3 nextPosition;

	void Start () {
		nextPosition = transform.localPosition;
	}
}
