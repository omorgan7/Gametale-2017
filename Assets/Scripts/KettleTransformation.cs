using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettleTransformation : MonoBehaviour {
	private bool isInitialized = false;
	// Use this for initialization

	public GameObject kettle;
	public GameObject bunbuku;
	bool transformationBegun = false;
	DialogueSystemBadger dialogueSystemBadger;
	private GameObject box;
	public GameObject speechBubble;
	
	// Update is called once per frame
	void Start(){
		dialogueSystemBadger = GameObject.Find("ScriptingSystem").GetComponent<DialogueSystemBadger>();
	} 
	void Update () {
		if(kettle.activeSelf & !bunbuku.activeSelf){
			if(!transformationBegun){
				transformationBegun = true;
				StartCoroutine(transformKettle());
			}
		}
	}

	IEnumerator transformKettle(){
		var kettleAnimationController = kettle.GetComponent<SpriteAnimationController>();
		yield return new WaitForSecondsRealtime(1f);
		kettleAnimationController.nextAnimation = Enums.AnimStates.MoveLeft;
		yield return new WaitForSecondsRealtime(1f);
		kettleAnimationController.nextAnimation = Enums.AnimStates.MoveRight;
		yield return new WaitForSecondsRealtime(1f);
		kettleAnimationController.nextAnimation = Enums.AnimStates.MoveLeft;
		yield return new WaitForSecondsRealtime(1f);
		kettle.SetActive(false);
		bunbuku.SetActive(true);
		StartCoroutine(dialogueSystemBadger.speak(0,0, speechBubble, box));
	}
}
