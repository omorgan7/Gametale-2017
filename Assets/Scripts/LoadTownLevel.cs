using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTownLevel : MonoBehaviour {

	// Use this for initialization
	FadeController fadeController;
	public GameObject sound;
	private AudioSource doorClose;

	void Start(){
		fadeController = gameObject.GetComponent<FadeController>();
		doorClose = sound.GetComponent<AudioSource>();
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "door"){
			doorClose.Play();
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
