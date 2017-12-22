using System.Collections.Generic;
using UnityEngine;

public class RayCastTrigger : MonoBehaviour {

	public float minTriggerDistance = 0.5f;
	public float maxTriggerDistance = 2.0f;

	public GameObject triggeredObject = null;

	// Update is called once per frame
	private GameObject[] interactables;
	private RaycastHit2D[] hits;
	void Start(){
		// get a reference to all objects that sit on the interactive layer.
		GameObject[] allObjects = FindObjectsOfType<GameObject>();
		List<GameObject> interactive = new List<GameObject>();
		for(int i = 0; i < allObjects.Length; ++i){
			if(allObjects[i].layer == 8){
				interactive.Add(allObjects[i]);
			}
		}
		interactables = interactive.ToArray();
	}

	void Update () {
		// checking for collision once per frame should be sufficient.
		Vector2 position = new Vector2(transform.position.x, transform.position.y);
		Vector2 direction;
		int lastFoundIndex = interactables.Length;

		hits = new RaycastHit2D[interactables.Length];

		for(int i = 0; i < interactables.Length; ++i){
			direction = new Vector2(interactables[i].transform.position.x - position.x, interactables[i].transform.position.y - position.y);
			Vector2 normalDirection = direction.normalized;
			hits[i] = Physics2D.Raycast(position, normalDirection, maxTriggerDistance, 1 << 8);
		}

		float distance = Mathf.Infinity;
		RaycastHit2D bestHit = new RaycastHit2D();
		
		for(int i = 0; i < hits.Length; ++i){
			if(hits[i].collider != null && hits[i].distance < distance){
				bestHit = hits[i];
				distance = hits[i].distance;
			}
		}

		if(distance < Mathf.Infinity){
			triggeredObject = bestHit.collider.gameObject;
		}
		else{
			triggeredObject = null;
		}
	}
}
