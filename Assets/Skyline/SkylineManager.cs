using UnityEngine;
using System.Collections;

public class SkylineManager : MonoBehaviour {

	public Transform prefab;
	public int numberOfCubes;

	private Vector3 nextPosition;

	void Start () {
		nextPosition = transform.localPosition;
		for(int i = 0; i < numberOfCubes; i++){
			Transform o = (Transform)Instantiate(prefab);
			o.localPosition = nextPosition;
			nextPosition.x += o.localScale.x;
		}
	}
}
