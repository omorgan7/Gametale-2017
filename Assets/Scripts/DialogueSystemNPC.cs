using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueSystemNPC : MonoBehaviour {
	public GameObject speechBubble;
	private GameObject box;
	LoadText loadText = new LoadText();

	// Use this for initialization
	void Start () {
		LoadInDialogue(SceneManager.GetActiveScene ().name);
	}
	void LoadInDialogue(string level){
		loadText.Load("Assets/Character Dialogue/npc/"+ level + ".txt", LoadText.characters.npc);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void say(int catchPhrase){
		speak(catchPhrase,catchPhrase);
	}
	IEnumerator speak(int startIndex, int EndIndex){
		box = Instantiate(speechBubble, Vector3.zero, Quaternion.identity); 
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		for(int i = startIndex; i< EndIndex + 1; ++i){
			string _string = loadText.badgerDialogue[i];
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
