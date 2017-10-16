using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownAnimator : MonoBehaviour {

	// Use this for initialization
	public GameObject npcContainer;
	Transform[] npcs;
	float height = 1f;
	void Start () {
		int numNPCS = npcContainer.transform.childCount;
		npcs = new Transform[numNPCS];
		for(int i = 0; i<numNPCS; ++i){
			npcs[i] = npcContainer.transform.GetChild(i);
		}
		StartCoroutine(npcJumpingRoutine());
		StartCoroutine(bunbukuJumpingRoutine());
	}

	IEnumerator npcJumpingRoutine(){
		yield return new WaitForSecondsRealtime(10f);
		float elapsedTime = 0f;
		while(true){
		foreach(var npc in npcs){
			var initialPosition = npc.position;
			while(elapsedTime <= 0.3f){
				npc.transform.position = new Vector3(initialPosition.x, initialPosition.y + Mathf.SmoothStep(0f,height,2f*elapsedTime),initialPosition.z);
				elapsedTime += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			while(elapsedTime > 0f){
				npc.transform.position = new Vector3(initialPosition.x, initialPosition.y + Mathf.SmoothStep(0f,height,2f*elapsedTime ),initialPosition.z);
				elapsedTime -= Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
		}
		}
	}
	IEnumerator bunbukuJumpingRoutine(){
		yield return null;
	}

}
