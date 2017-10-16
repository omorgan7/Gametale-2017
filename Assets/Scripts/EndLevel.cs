﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndLevel : MonoBehaviour {
	static public bool sceneFinished = false;
	public GameObject textPanel;
	private GameObject box;
	LoadText loadText;

	FadeController fadeController;
	// Use this for initialization
	void Start () {
		loadText = GameObject.Find("EventSystem").GetComponent<LoadText>();
		LoadInDialogue(SceneManager.GetActiveScene ().name);
		fadeController = gameObject.GetComponent<FadeController>();
	}
	
	// Update is called once per frame
	void LoadInDialogue(string level){
		if(loadText){
			loadText.Load("Assets/Character Dialogue/sceneDescription/" +level + ".txt", LoadText.characters.narrator);
		}
	}
	void FixedUpdate(){
//		print(fadeController == null);
		//print(gameObject.name);
		if((sceneFinished)&&(SceneManager.GetActiveScene().name == "temple2.scene")){
			StartCoroutine(finalFade());
			fadeController.FadeOut();
		}
		if((sceneFinished)&&(SceneManager.GetActiveScene().name == "town3.scene")){
			fadeController.FadeOut();
				StartCoroutine(loadLevel());
				//SceneManager.LoadScene("temple.scene");
				sceneFinished = false;
				DialogueSystemNPC.isDone = false;
		}
		else if(sceneFinished){
			if(Input.GetButtonUp("Submit")){
				fadeController.FadeOut();
				StartCoroutine(loadLevel());
				//SceneManager.LoadScene("temple.scene");
				sceneFinished = false;
				DialogueSystemNPC.isDone = false;
			}
		}
	}

	public void endLevelText(GameObject textPanel){
		box = Instantiate(textPanel, Vector3.zero, Quaternion.identity); 
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		txt.text = loadText.narration[0];
	}


	IEnumerator loadLevel(){
		while(!fadeController.isDone){
			yield return null;
		}
		if(SceneManager.GetActiveScene().name=="town.scene"){
			SceneManager.LoadScene("temple.scene");
		}
		else if (SceneManager.GetActiveScene().name == "temple.scene"){
			SceneManager.LoadScene("house_monk-tinker-chat");
		}
		else if (SceneManager.GetActiveScene().name == "house_monk-tinker-chat"){
			SceneManager.LoadScene("town2.scene");
		}
		else if (SceneManager.GetActiveScene().name == "town2.scene"){
			SceneManager.LoadScene("performance.scene");
		}
		else if (SceneManager.GetActiveScene().name == "town3.scene"){
			SceneManager.LoadScene("temple2.scene");
		}
	}

	IEnumerator finalFade(){
		yield return new WaitForSecondsRealtime(5f);
	}

}
