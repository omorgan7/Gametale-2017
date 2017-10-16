using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunbukuTinkerDialogue : MonoBehaviour {
	private int step = 0;

	private DialogueSystemBadger dialogueSystemBadger;
	private DialogueSystemTinker dialogueSystemTinker;
	private GameObject badgerBox;
	private GameObject tinkerBox;
	public GameObject speechBubble;
	//private bool isTalking = false;

	// Use this for initialization
	void Start () {
		dialogueSystemBadger = GameObject.Find("EventSystem").GetComponent<DialogueSystemBadger>();
		dialogueSystemTinker = GameObject.Find("EventSystem").GetComponent<DialogueSystemTinker>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		StartCoroutine(speak(step));
	}
	void conversation(int i){ //add enumerator
		if( i == 0){
			StartCoroutine(dialogueSystemTinker.speak(0,1, speechBubble, tinkerBox));
		}
		if( i == 1){
			StartCoroutine(dialogueSystemBadger.speak(0,1, speechBubble, badgerBox));
		}
		if (i ==2){
			StartCoroutine(dialogueSystemTinker.speak(2,2, speechBubble, tinkerBox));
		}
		if (i==3){
			StartCoroutine(dialogueSystemBadger.speak(2,3, speechBubble, badgerBox));
		}
		if(i==4){
			StartCoroutine(dialogueSystemTinker.speak(3,3, speechBubble, tinkerBox));
		}
		if( i == 5){
			StartCoroutine(dialogueSystemBadger.speak(4,5, speechBubble, badgerBox));
		}
		if(i==6){
			StartCoroutine(dialogueSystemTinker.speak(4,4, speechBubble, tinkerBox));
		}
		if(i==7){
			StartCoroutine(dialogueSystemBadger.speak(6,6, speechBubble, badgerBox));
		}
		if(i==8){
			StartCoroutine(dialogueSystemTinker.speak(5,5, speechBubble, tinkerBox));
		}
		if(i==9){
			StartCoroutine(dialogueSystemBadger.speak(7,7, speechBubble, badgerBox));
		}
		if(i == 10){
			EndLevel.sceneFinished = true;
			//animation!
		}
	}
	IEnumerator speak(int i){
		while((DialogueSystemBadger.isTalking)||(DialogueSystemTinker.isTalking)){
			yield return null;
		}
		if((Input.GetButtonUp("Submit"))){
			conversation(i);
			++step;
		}
	}
}
