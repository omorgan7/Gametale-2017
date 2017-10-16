using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkTinkerDialogue : MonoBehaviour {
	private int step =0;
	public GameObject kettle;
	private DialogueSystemBadger dialogueSystemBadger;
	private DialogueSystemMonk dialogueSystemMonk;
	private DialogueSystemTinker dialogueSystemTinker;
	private GameObject monkBox;
	private GameObject badgerBox;
	private GameObject tinkerBox;
	public GameObject speechBubble;
	private bool isTalking = false;
	SpriteAnimationController MonkSAC;
	SpriteAnimationController TinkerSAC;
	private bool animating = false;


	// Use this for initialization
	void Start () {
		dialogueSystemBadger = GameObject.Find("EventSystem").GetComponent<DialogueSystemBadger>();
		dialogueSystemMonk = GameObject.Find("EventSystem").GetComponent<DialogueSystemMonk>();
		dialogueSystemTinker = GameObject.Find("EventSystem").GetComponent<DialogueSystemTinker>();
		TinkerSAC = GameObject.Find("Tinker").transform.GetChild(0).GetComponent<SpriteAnimationController>();
		MonkSAC = GameObject.Find("Head Monk").transform.GetChild(0).GetComponent<SpriteAnimationController>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		StartCoroutine(speak(step));
	}

	void conversation(int i){ //add enumerator
		if( i == 0){
			StartCoroutine(dialogueSystemMonk.speak(0,1, speechBubble, monkBox));
		}
		if(i == 1){
			StartCoroutine(dialogueSystemTinker.speak(0,2, speechBubble, tinkerBox));
		}
		if(i == 2){
			StartCoroutine(Animation1());
		}
		if(i ==3 ){
			StartCoroutine(dialogueSystemBadger.speak(0,1, speechBubble, badgerBox));
		}
		if( i == 4){
			StartCoroutine(dialogueSystemTinker.speak(3,5, speechBubble, tinkerBox));
		}
		if( i==5){
			StartCoroutine(dialogueSystemBadger.speak(2,4, speechBubble, badgerBox));
		}
		if (i==6){
			EndLevel.sceneFinished = true;
		}
	}
	IEnumerator speak(int i){
		while((DialogueSystemMonk.isTalking)||(DialogueSystemBadger.isTalking)||(DialogueSystemTinker.isTalking)||(animating)){
			yield return null;
		}
		if((Input.GetButtonUp("Submit"))){
			conversation(i);
			++step;
		}
	}

	IEnumerator Animation1(){ 
		animating = true;
		TinkerSAC.nextAnimation = Enums.AnimStates.MoveForward;
		yield return new WaitForSecondsRealtime(1f);
		MonkSAC.nextAnimation = Enums.AnimStates.MoveForward;
		yield return new WaitForSecondsRealtime(1f);
		GameObject.Find("Head Monk").SetActive(false);
		yield return (0.2f);
		kettle.SetActive(true);
		yield return (0.5f);
		animating = false;
	
	}
}
