using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystemMonk : MonoBehaviour {

	public GameObject speechBubble;
	//private bool isTalking = false; 
	private GameObject box;
	LoadText loadText ;
	void Start () {
		loadText = gameObject.AddComponent<LoadText>() as LoadText;
		LoadInDialogue(SceneManager.GetActiveScene ().name);
	}
	
	void LoadInDialogue(string level){
		loadText.Load("Assets/Character Dialogue/monk/" +level + ".txt", LoadText.characters.monk);
	}
	
	public IEnumerator speak(int startIndex, int EndIndex){
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
			yield return new WaitForSeconds(loadText.sentencePause);
			
		}	
		Destroy(box);	
	}
}
