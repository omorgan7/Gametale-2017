using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		dialogueSystemBadger = GameObject.Find("EventSystem").GetComponent<DialogueSystemBadger>();
	} 
	void Update () {
		if(kettle && kettle.activeSelf && !bunbuku.activeSelf){
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
		Destroy(kettle);
		bunbuku.SetActive(true);
		if (SceneManager.GetActiveScene().name == "temple.scene"){
			StartCoroutine(dialogueSystemBadger.speak(0,0, speechBubble, box));
		}
	}
}
