using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndLevel : MonoBehaviour {
	static public bool sceneFinished = false;
	bool startedFade = false;
	public GameObject textPanel;
	public TextAsset sceneText;
	public AudioSource audioSource;
	bool isQuitting = false;
	private GameObject box;
	LoadText loadText;
	FadeController fadeController;
	void Start () {
		loadText = GameObject.Find("EventSystem").GetComponent<LoadText>();
		LoadInDialogue(SceneManager.GetActiveScene ().name);
		sceneFinished = false;
		fadeController = gameObject.GetComponent<FadeController>();
	}
	
	void LoadInDialogue(string level){
		if(loadText){
			loadText.Load(sceneText.text, LoadText.characters.narrator);
		}
	}
	void FixedUpdate(){
		if((sceneFinished)&&(SceneManager.GetActiveScene().name == "temple2.scene")){
			if(!startedFade){
				StartCoroutine(loadLevel());
			}
			startedFade = true;
		}
		else if((sceneFinished)&&(SceneManager.GetActiveScene().name == "town3.scene")){
			if(!startedFade){
				StartCoroutine(loadLevel());
			}
			startedFade = true;
			DialogueSystemNPC.isDone = false;
		}
		else if((sceneFinished)&&(SceneManager.GetActiveScene().name == "house_monk-tinker-chat")){
			if(!startedFade){
				StartCoroutine(loadLevel());
			}
			startedFade = true;
		}
		else if(sceneFinished){
			if(Input.GetButtonUp("Submit")){

				if(!startedFade){
					StartCoroutine(loadLevel());
				}
				startedFade = true;
				sceneFinished = false;
				DialogueSystemNPC.isDone = false;
			}
		}
	}
	void Update(){
		if(isQuitting){
			audioSource.volume -= 0.04f*Time.deltaTime;
		}
	}
	public void endLevelText(GameObject textPanel){
		box = Instantiate(textPanel, Vector3.zero, Quaternion.identity); 
		Text txt = box.transform.GetChild(0).GetChild(0).GetComponent<Text>();
		txt.text = loadText.narration[0];
	}
	
	IEnumerator loadLevel(){
		fadeController.FadeOut();
		while(!fadeController.isDone){
			yield return null;
		}
		sceneFinished = false;
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
		else if (SceneManager.GetActiveScene().name == "temple2.scene"){
			SceneManager.LoadScene("Credits.scene");
		}
	}

}
