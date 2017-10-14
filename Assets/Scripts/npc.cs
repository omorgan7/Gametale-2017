using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class npc : MonoBehaviour {
	public GameObject speechBubble;
	private GameObject box;
	LoadText loadText = new LoadText();
	private enum npcs {a,b,c};

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
	void say(npcs _name){
		switch(_name){
			case npcs.a:
				speak(0,0);
				break;
			case npcs.b:
				speak(1,1);
				break;
			case npcs.c:
				speak(2,2);
				break;
		}
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
