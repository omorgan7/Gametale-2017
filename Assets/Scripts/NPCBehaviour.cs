using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCBehaviour : MonoBehaviour {

	public int catchphrase;
	public GameObject speechBubble;
	public GameObject CharName;
	private GameObject box;
	public string NPCname;
	public int getCatchphrase(){
		return catchphrase;
	}
	void Start(){
		StartCoroutine(start());		
	}
	
	void FixedUpdate(){
		if(Input.GetButtonUp("Submit")){
			turnOffBox();
			var gameobjects = GameObject.FindGameObjectsWithTag("Player");
			gameobjects[0].GetComponent<InteractiveSpriteMover>().moveAgain();
		}
	}

	IEnumerator start(){
		while(!DialogueSystemNPC.isDone){
			yield return null;
		}
		box = Instantiate(speechBubble, Vector3.zero, Quaternion.identity);
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		txt.text = (DialogueSystemNPC.NPCword[0]);
		CharName.transform.GetChild(0).GetComponent<Text>().text = name;
		box.SetActive(false);
	}
	public void turnOnBox(){
		box.SetActive(true);
	}
	public void turnOffBox(){
		box.SetActive(false);
	}
	
}
