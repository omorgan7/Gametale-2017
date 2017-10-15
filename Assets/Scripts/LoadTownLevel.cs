using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTownLevel : MonoBehaviour {

	// Use this for initialization
	FadeController fadeController;

	void Start(){
		fadeController = gameObject.GetComponent<FadeController>();
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "door"){
			fadeController.FadeOut();
			StartCoroutine(loadLevel());
		}
	}

	IEnumerator loadLevel(){
		while(!fadeController.isDone){
			yield return null;
		}
		SceneManager.LoadScene("town.scene");
	}
}
