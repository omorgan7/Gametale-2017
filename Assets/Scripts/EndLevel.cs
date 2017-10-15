using System.Collections;
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
		loadText = gameObject.AddComponent<LoadText>() as LoadText;
		LoadInDialogue(SceneManager.GetActiveScene ().name);
		fadeController = gameObject.GetComponent<FadeController>();
	}
	
	// Update is called once per frame
	void LoadInDialogue(string level){
		loadText.Load("Assets/Character Dialogue/sceneDescription/" +level + ".txt", LoadText.characters.narrator);
	}
	void FixedUpdate(){
		print(fadeController == null);
		print(gameObject.name);
		if(sceneFinished){
			if(Input.GetButtonUp("Submit")){
				fadeController.FadeOut();
				StartCoroutine(loadLevel());
				SceneManager.LoadScene("temple.scene");
				sceneFinished = false;
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
		SceneManager.LoadScene("temple.scene");
	}
}
