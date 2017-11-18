using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueSystemNPC : MonoBehaviour {
	public TextAsset NPCSpeech;
		private bool pressed;
	LoadText loadText;
	static public List <string> NPCword;
	static public bool isDone = false;

	void Start () {
		loadText = GameObject.Find("EventSystem").GetComponent<LoadText>();
		LoadInDialogue(SceneManager.GetActiveScene ().name, loadText);
		NPCword = loadText.npcDialogue;
	}
	void LoadInDialogue(string level, LoadText loadText){
		loadText.Load(NPCSpeech.text, LoadText.characters.npc);
		isDone = true;
	}

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
		}	
		while(!pressed){
			yield return null;
		}
		pressed = false;			
		Destroy(box);	
	}
}
