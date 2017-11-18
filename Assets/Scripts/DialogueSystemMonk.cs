using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystemMonk : MonoBehaviour {
	public TextAsset MonkSpeech;
	LoadText loadText ;
	static public bool isTalking = false;
	private bool pressed = false;
	void Start () {
		loadText = GameObject.Find("EventSystem").GetComponent<LoadText>();
		StartCoroutine(LoadInDialogue(SceneManager.GetActiveScene ().name));
	}
	
	IEnumerator LoadInDialogue(string level){
		while(!loadText.isDone){
			yield return null;
		}
		loadText.Load(MonkSpeech.text, LoadText.characters.monk);
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
		box.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Head Monk";
		for(int i = startIndex; i< EndIndex + 1; ++i){
			string _string = loadText.monkDialogue[i];
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
		pressed = false;
		isTalking = false;
		
	}
	
}
