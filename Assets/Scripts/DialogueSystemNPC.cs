﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueSystemNPC : MonoBehaviour {
	public TextAsset NPCSpeech;
	public GameObject speechBubble;
	private GameObject box;
	private bool pressed;
	LoadText loadText;
	static public List <string> NPCword;
	static public bool isDone = false;

	// Use this for initialization
	void Start () {
		loadText = GameObject.Find("EventSystem").GetComponent<LoadText>();
		LoadInDialogue(SceneManager.GetActiveScene ().name, loadText);
		NPCword = loadText.npcDialogue;
	}
	void LoadInDialogue(string level, LoadText loadText){
		loadText.Load(NPCSpeech.text, LoadText.characters.npc);
		isDone = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if((Input.GetButtonUp("Submit"))){
			pressed = true;
		}
	}


	public IEnumerator speak(int catchphrase, GameObject box, GameObject speechBubble){
		pressed = false;
		box = Instantiate(speechBubble, Vector3.zero, Quaternion.identity); 
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		string _string = loadText.badgerDialogue[catchphrase];
		txt.text = " ";
		foreach(char s in _string){
			txt.text += s;
			yield return new WaitForSeconds (loadText.letterPause);
<<<<<<< HEAD
		}				
=======
		}	
		while(!pressed){
			yield return null;
		}
		pressed = false;			
>>>>>>> aaeba159078eee479e846a3cf8f1a37fa0b8d32a
		Destroy(box);	
	}
}
