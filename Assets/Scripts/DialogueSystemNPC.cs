using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueSystemNPC : MonoBehaviour {
	public GameObject speechBubble;
	private GameObject box;
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
		loadText.Load("Assets/Character Dialogue/npc/"+ level + ".txt", LoadText.characters.npc);
		isDone = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator speak(int catchphrase, GameObject box, GameObject speechBubble){
		box = Instantiate(speechBubble, Vector3.zero, Quaternion.identity); 
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
			string _string = loadText.badgerDialogue[catchphrase];
			txt.text = " ";
			foreach(char s in _string){
				txt.text += s;
				yield return new WaitForSeconds (loadText.letterPause);
			}				
		Destroy(box);	
	}
}
