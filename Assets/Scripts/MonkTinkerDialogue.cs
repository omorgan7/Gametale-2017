using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkTinkerDialogue : MonoBehaviour {
	private int step = 0;
	public GameObject kettle;
	public GameObject bunbuku;
	public GameObject monk;
	public GameObject tinker;
	private DialogueSystemBadger dialogueSystemBadger;
	private DialogueSystemMonk dialogueSystemMonk;
	private DialogueSystemTinker dialogueSystemTinker;
	private GameObject monkBox = null;
	private GameObject badgerBox = null;
	private GameObject tinkerBox = null;
	public GameObject speechBubble;
	private bool started = false;
	SpriteAnimationController MonkSAC;
	SpriteAnimationController TinkerSAC;
	SpriteAnimationController kettleSac;
	bool isDoneAnimating = true;


	// Use this for initialization
	void Start () {
		dialogueSystemBadger = GameObject.Find("EventSystem").GetComponent<DialogueSystemBadger>();
		dialogueSystemMonk = GameObject.Find("EventSystem").GetComponent<DialogueSystemMonk>();
		dialogueSystemTinker = GameObject.Find("EventSystem").GetComponent<DialogueSystemTinker>();
		TinkerSAC = tinker.transform.GetChild(0).GetComponent<SpriteAnimationController>();
		MonkSAC = monk.transform.GetChild(0).GetComponent<SpriteAnimationController>();
		kettleSac = kettle.GetComponent<SpriteAnimationController>();
		StartCoroutine(DelayedStart());
		TinkerSAC.sendToIdle();
		MonkSAC.sendToIdle();
	}
	
	void Update () {
		if(!DialogueSystemMonk.isTalking && !DialogueSystemBadger.isTalking && !DialogueSystemTinker.isTalking && isDoneAnimating && started){
			++step;
			conversation(step);
		}
	}

	void conversation(int i){ //add enumerator
		if(i == 0){
			StartCoroutine(dialogueSystemMonk.speak(0,1, speechBubble, monkBox));
		}
		if(i == 1){
			StartCoroutine(dialogueSystemTinker.speak(0,3, speechBubble, tinkerBox));
			isDoneAnimating = false;
			StartCoroutine(Animation1());
		}
		if(i == 2){
			++step;
			conversation(step);
		}
		if(i == 3){
			StartCoroutine(dialogueSystemBadger.speak(0,2, speechBubble, badgerBox));
		}
		if(i == 4){
			StartCoroutine(dialogueSystemTinker.speak(4,6, speechBubble, tinkerBox));
		}
		if(i == 5){
			StartCoroutine(dialogueSystemBadger.speak(3,8, speechBubble, badgerBox));
			StartCoroutine(DelayedEnd());
		}
	}

	IEnumerator DelayedStart(){
		var loadText = GameObject.Find("EventSystem").GetComponent<LoadText>();
		while(!loadText.isDone){
			yield return null;
		}
		conversation(step);
		started = true;
	}
	IEnumerator DelayedEnd(){
		while(DialogueSystemBadger.isTalking){
			yield return null;
		}
		EndLevel.sceneFinished = true;
	}

	IEnumerator Animation1(){
		while(DialogueSystemTinker.isTalking){
			yield return null;
		} 
		yield return new WaitForSecondsRealtime(0.5f);
		MonkSAC.nextAnimation = Enums.AnimStates.MoveForward;
		float elapsedTime = 0f;
		float yPos = monk.transform.position.y;
		while(elapsedTime <= 3f){
			monk.transform.position = new Vector3(monk.transform.position.x, yPos - Mathf.SmoothStep(0f,5,0.5f*elapsedTime),0);
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		GameObject.Find("Head Monk").SetActive(false);
		kettle.SetActive(true);
		yield return new WaitForSecondsRealtime(1f);
		kettleSac.nextAnimation = Enums.AnimStates.MoveRight;
		yield return new WaitForSecondsRealtime(3f);
		kettle.SetActive(false);
		bunbuku.SetActive(true);
		isDoneAnimating = true;
	}
}
