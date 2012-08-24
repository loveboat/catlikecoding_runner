using UnityEngine;
using System.Collections.Generic;

public class SkylineManager : MonoBehaviour {

	public Transform prefab;
	public int numberOfObjects;
	public float recycleOffset;

	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;

	void Start () {
		objectQueue = new Queue<Transform>(numberOfObjects);
		for(int i = 0; i < numberOfObjects; i++){
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		
		nextPosition = transform.localPosition;
		for(int i = 0; i < numberOfObjects; i++){
			Recycle();
		}
	}
	
	void Update () {
		if (objectQueue.Peek().localPosition.x + recycleOffset < Runner.distanceTraveled){
			Recycle();
		}
	}
	
	private void Recycle() {
		Transform o = objectQueue.Dequeue();
		o.localPosition = nextPosition;
		nextPosition.x += o.localScale.x;
		objectQueue.Enqueue(o);
	}
}
