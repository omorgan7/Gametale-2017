﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemMonk : MonoBehaviour {

	public GameObject speechBubble;
	private bool isTalking = false; 
	private float pauseTime = 0.1f; //maybe use deltaTime
	private GameObject box;
	LoadText loadText  = new LoadText();
	void Start () {
		LoadInDialogue(LoadText.scene.b);
		StartCoroutine( speak(0,4));
	}
	
	void LoadInDialogue(LoadText.scene _scene){
		switch (_scene){
			case LoadText.scene.a:
				loadText.Load("Assets/Character Dialogue/monk/level1.txt", LoadText.characters.monk);
				break;
			case LoadText.scene.b:
				loadText.Load("Assets/Character Dialogue/monk/level2.txt", LoadText.characters.monk);
				break;
		}

	}
	// Update is called once per frame
	void Update () {

		if (isTalking == true){
		//speak
			isTalking = false;
		}
		
	}
	IEnumerator speak(int startIndex, int EndIndex){
		box = Instantiate(speechBubble, Vector3.zero, Quaternion.identity); 
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		for(int i = startIndex; i< EndIndex + 1; ++i){
			string _string = loadText.monkDialogue[i];
			txt.text = " ";
			foreach(char s in _string){
				txt.text += s;
				yield return new WaitForSeconds (loadText.letterPause);
			}
			yield return new WaitForSeconds(loadText.sentencePause);
			
		}	
		Destroy(box);	
	}
}