﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystemBadger : MonoBehaviour {
	public TextAsset BadgerSpeech;
	LoadText loadText;
	private bool pressed = false;
	static public bool isTalking = false;
	void Start () {
		loadText = GameObject.Find("EventSystem").GetComponent<LoadText>();
		LoadInDialogue(SceneManager.GetActiveScene ().name);
	}
	
	void LoadInDialogue(string level){
		loadText.Load(BadgerSpeech.text, LoadText.characters.badger);
	}
	void FixedUpdate () {
		if((Input.GetButtonUp("Submit"))){
			pressed = true;
		}
	}

	public IEnumerator speak(int startIndex, int EndIndex, GameObject speechBubble, GameObject box){
		pressed = false;
		isTalking = true;
		box = Instantiate(speechBubble, Vector3.zero, Quaternion.identity); 
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		box.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Tanuki";
		for(int i = startIndex; i < EndIndex + 1; ++i){
			string _string = loadText.badgerDialogue[i];
			txt.text = " ";
			foreach(char s in _string){
				txt.text += s;
				yield return new WaitForSeconds (loadText.letterPause);
			}
			while(!pressed){
				yield return null;
			}
			pressed = false;			
		}	
		Destroy(box);
		isTalking =  false;	
	}
	public IEnumerator disappear(){
		while(isTalking){
			yield return null;
		}
		gameObject.SetActive(false);
	}
}
