using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {
	public GameObject eventSystem;
	private FadeController fadeController;

	void Start(){
        fadeController = gameObject.GetComponent<FadeController>();
    }
	void Update(){
		if(Input.GetButtonUp("Submit") && !fadeController.isDone){
            fadeController.FadeOut();
        }
        if(fadeController.isDone){
            SceneManager.LoadScene("splashScreen.scene");
        }
	}
}
