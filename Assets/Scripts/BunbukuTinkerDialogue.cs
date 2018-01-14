using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunbukuTinkerDialogue : MonoBehaviour {
	private int step = 0;
	public GameObject tinker;
	public GameObject bunbuku;
	public GameObject kettle;
	SpriteAnimationController TinkerSAC;
	private DialogueSystemBadger dialogueSystemBadger;
	private DialogueSystemTinker dialogueSystemTinker;
	private GameObject badgerBox = null;
	private GameObject tinkerBox = null;
	public GameObject speechBubble;

	void Start () {
		dialogueSystemBadger = GameObject.Find("EventSystem").GetComponent<DialogueSystemBadger>();
		dialogueSystemTinker = GameObject.Find("EventSystem").GetComponent<DialogueSystemTinker>();
		TinkerSAC = tinker.transform.GetChild(0).GetComponent<SpriteAnimationController>();
	}

	void Update () {
		StartCoroutine(speak(step));
	}
	void conversation(int i){ //add enumerator
		if( i == 0){
			StartCoroutine(dialogueSystemTinker.speak(0,1, speechBubble, tinkerBox));
			TinkerSAC.sendToIdle();
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
			StartCoroutine(dialogueSystemBadger.speak(4,6, speechBubble, badgerBox));
		}
		if(i==6){
			StartCoroutine(dialogueSystemTinker.speak(4,4, speechBubble, tinkerBox));
		}
		if(i==7){
			StartCoroutine(dialogueSystemBadger.speak(7,7, speechBubble, badgerBox));
		}
		if(i==8){
			StartCoroutine(dialogueSystemTinker.speak(5,5, speechBubble, tinkerBox));
		}
		if(i==9){
			StartCoroutine(dialogueSystemBadger.speak(8,8, speechBubble, badgerBox));
		}
		if(i == 10){
			StartCoroutine(animationSequence());
		}
	}
	IEnumerator speak(int i){
		while((DialogueSystemBadger.isTalking)||(DialogueSystemTinker.isTalking)){
			yield return null;
		}
		if(step < 11){
			conversation(i);
			++step;
		}
	}

	IEnumerator animationSequence(){

		yield return new WaitForSecondsRealtime(0.5f);

		float _elapsedTime = 0f;
		float _yPos = bunbuku.transform.position.y;
		int x = -1;

		while(_elapsedTime <= 2.35f){
			x *= -1;
			bunbuku.transform.position = new Vector3(bunbuku.transform.position.x + 0.1f*x, _yPos , 0);
			_elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		kettle.SetActive(true);
		bunbuku.SetActive(false);
		yield return new WaitForSecondsRealtime(1.0f);
		TinkerSAC.nextAnimation = Enums.AnimStates.MoveLeft;
		yield return new WaitForSecondsRealtime(1.0f);
		kettle.SetActive(false);
		yield return (1f);
		TinkerSAC.nextAnimation = Enums.AnimStates.MoveBack;
		float elapsedTime = 0f;
		float yPos = tinker.transform.position.y;

		while(elapsedTime <= 2.35f){
			tinker.transform.position = new Vector3(tinker.transform.position.x, yPos + Mathf.SmoothStep(0f, 5, 0.25f*elapsedTime), 0);
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		EndLevel.sceneFinished=true;
	}
}
