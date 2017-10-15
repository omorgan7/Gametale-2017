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
	// Use this for initialization
	void Start () {
		loadText = gameObject.AddComponent<LoadText>() as LoadText;
		LoadInDialogue(SceneManager.GetActiveScene ().name);
	}
	
	// Update is called once per frame
	void LoadInDialogue(string level){
		loadText.Load("Assets/Character Dialogue/sceneDescription/" +level + ".txt", LoadText.characters.narrator);
	}
	void FixedUpdate(){
		if(sceneFinished){
			if(Input.GetButtonUp("Submit")){
				print("done");
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
}
