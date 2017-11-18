using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTanuki : MonoBehaviour {
	public GameObject bunbuku;
	public GameObject textPanel;
	private bool caught = false;
	private WildBehaviour wildBehaviour;
	EndLevel endLevel;

	void Start () {
		wildBehaviour = GameObject.Find("EventSystem").GetComponent<WildBehaviour>();
		endLevel = GameObject.Find("EventSystem").GetComponent<EndLevel>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "bunbuku" && Input.GetButtonUp("Submit")){
			if(!caught){
				caught = true;
				wildBehaviour.hasBeenCaught = true;
				bunbuku.GetComponent<SpriteMover>().enabled=false;
				bunbuku.GetComponent<NPCSpriteMover>().enabled=false;
				transform.parent = bunbuku.transform.parent; //hmmmm
				EndLevel.sceneFinished=true;
				endLevel.endLevelText(textPanel);
			}
		}
	}
}
