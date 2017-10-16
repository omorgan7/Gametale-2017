using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystemTinker : MonoBehaviour {
	public GameObject speechBubble;
	public GameObject CharName;
	private bool isTalking = false; 
	private GameObject box;
	LoadText loadText;
	void Start () {
		loadText = GameObject.Find("EventSystem").GetComponent<LoadText>();
		LoadInDialogue(SceneManager.GetActiveScene ().name);
		StartCoroutine( speak(0,4));
	}
	
	void LoadInDialogue(string level){
		loadText.Load("Assets/Character Dialogue/tinker/"+level + ".txt", LoadText.characters.tinker);
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
		CharName.transform.GetChild(0).GetComponent<Text>().text = "Tinker";
		for(int i = startIndex; i< EndIndex + 1; ++i){
			string _string = loadText.tinkerDialogue[i];
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
