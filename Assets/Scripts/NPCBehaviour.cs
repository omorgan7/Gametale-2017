using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviour : MonoBehaviour {

	public int catchphrase;
	public string nameOfNPC;
	public GameObject speechBubble;
	private GameObject box;
	
	public string getName(){
		return nameOfNPC;
	}
	public int getCatchphrase(){
		return catchphrase;
	}
	void Start(){
		StartCoroutine(start());		
	}
	
	void FixedUpdate(){
		if((Input.GetButtonUp("Submit"))){
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
		if(nameOfNPC == "Head Monk"){
			Text txtName = box.transform.GetChild(1).GetChild(0).GetComponent<Text>();
			txtName.text = nameOfNPC;
		}
		else{
			box.transform.GetChild(1).gameObject.SetActive(false);
		}
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
