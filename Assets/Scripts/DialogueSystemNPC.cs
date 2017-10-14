using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueSystemNPC : MonoBehaviour {
	public GameObject speechBubble;
	private GameObject box;
	LoadText loadText = new LoadText();
	static public List <string> NPCword;

	// Use this for initialization
	void Start () {
		LoadInDialogue(SceneManager.GetActiveScene ().name);
		print(loadText.npcDialogue.Count);
		print(loadText.npcDialogue[0]);
		NPCword = loadText.npcDialogue;
		print(NPCword.Count);
	}
	void LoadInDialogue(string level){
		loadText.Load("Assets/Character Dialogue/npc/"+ level + ".txt", LoadText.characters.npc);
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
