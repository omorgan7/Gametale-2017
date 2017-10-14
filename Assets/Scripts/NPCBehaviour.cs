using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCBehaviour : MonoBehaviour {

	public int catchphrase;
	public string nameOfNPC;
	public GameObject speechBubble;
	private GameObject box;
	
	
	public int getCatchphrase(){
		return catchphrase;
	}
	void Start(){
		StartCoroutine(start());		
	}
	
	void FixedUpdate(){
		if((Input.GetButtonUp("Submit"))&&(DialogueSystemNPC.isDone)){
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
		txt.text = (DialogueSystemNPC.NPCword[catchphrase]);
		Text txtName = box.transform.GetChild(1).GetChild(0).GetComponent<Text>();
		txtName.text = nameOfNPC;
		box.SetActive(false);
	}
	public void turnOnBox(){
		if(!box){
			return;
		}
		box.SetActive(true);
	}
	public void turnOffBox(){
		if(!box){
			return;
		}
		box.SetActive(false);
	}
	
}
