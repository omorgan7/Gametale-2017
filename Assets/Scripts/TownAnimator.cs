using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownAnimator : MonoBehaviour {

	// Use this for initialization
	public GameObject npcContainer;
	public Transform bunbuku;
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
		while(true){
			yield return new WaitForSecondsRealtime(0.5f);
			Vector3 initialPosition = bunbuku.transform.position;
			var spriteController = bunbuku.transform.GetChild(0).GetComponent<SpriteAnimationController>();
			float elapsedTime = 0f;
			do{
				bunbuku.Rotate(new Vector3(0f,0f, 360f*Time.fixedDeltaTime));
				bunbuku.position = initialPosition;
				elapsedTime += Time.fixedDeltaTime;
				yield return new WaitForEndOfFrame();
			}while(elapsedTime <= 1f);
			bunbuku.Rotate(new Vector3(0f,0f, -7.2f));
			bunbuku.position = initialPosition;
			yield return new WaitForSecondsRealtime(0.5f);
			elapsedTime = 0f;
			while(elapsedTime <= 0.5f){
				bunbuku.position = new Vector3(initialPosition.x, initialPosition.y + Mathf.SmoothStep(0f,height,2f*elapsedTime),initialPosition.z);
				elapsedTime += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			while(elapsedTime > 0f){
				bunbuku.position = new Vector3(initialPosition.x, initialPosition.y + Mathf.SmoothStep(0f,height,2f*elapsedTime ),initialPosition.z);
				elapsedTime -= Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			spriteController.nextAnimation = Enums.AnimStates.Idle;
			yield return new WaitForSecondsRealtime(0.25f);
			spriteController.nextAnimation = Enums.AnimStates.MoveRight;
			yield return new WaitForSecondsRealtime(0.25f);
			spriteController.nextAnimation = Enums.AnimStates.Idle;
			yield return new WaitForSecondsRealtime(0.25f);
			spriteController.nextAnimation = Enums.AnimStates.MoveLeft;
			yield return new WaitForSecondsRealtime(0.25f);
		}
	}

}
