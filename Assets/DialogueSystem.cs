using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	//public GameObject textBox;
	private enum character {tinker, badger, monk};
	private GameObject box;


	// Update is called once per frame
	void Update () {
		
	}

	static public void speak(string dialogue, GameObject speechBubble, GameObject box){
		box = Instantiate(speechBubble, Vector3.zero, Quaternion.identity); 
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		txt.text = dialogue;
	}
	static public string getDialogue(){
		 return "hello";
	}
}
