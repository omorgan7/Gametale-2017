using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemTinker : MonoBehaviour {
	public GameObject speechBubble;
	public enum scene {a, b};
	private string [] dialogue;// = new string [1] {"I'm the monk"};
	private bool isTalking = false; 
	private float pauseTime = 0.1f; //maybe use deltaTime
	// Use this for initialization
	private GameObject box;
	void Start () {
		LoadInDialogue(scene.a);
		//DialogueSystem.speak(dialogue[0], speechBubble, box);
		StartCoroutine( sayParagragh(0,4));
	}
	
	void LoadInDialogue(scene _scene){
		switch (_scene){
			case scene.a:
				dialogue = new string [5] {"hello", "I'm the tinker", "this is level a", "wooo", "bye"};
				//load in text a
				break;
			case scene.b:
				dialogue = new string [1];
				dialogue[0] = "hello level b";
				//load in text b
				break;
		}

	}
	// Update is called once per frame
	void Update () {

		if (isTalking == true){
			DialogueSystem.speak("hello world", speechBubble, box);
			//delete bubble
			isTalking = false;
		}
		
	}
	string getTinkerDialogue(int i){
		if((i<0)||(i>(dialogue.Length-1))){
			print("error no such dialogue exists");
			return "ERROR";
		}
		return dialogue[0];
	}
	IEnumerator sayParagragh(int startIndex, int EndIndex){
		box = Instantiate(speechBubble, Vector3.zero, Quaternion.identity); 
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		for(int i = startIndex; i< EndIndex + 1; ++i){
			txt.text = dialogue[i];
			yield return new WaitForSeconds(2f);
			
		}	
		Destroy(box);	
	}
}
