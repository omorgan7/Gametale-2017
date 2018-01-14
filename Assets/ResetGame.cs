using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {
	public GameObject eventSystem;
	private Button button;
	private FadeController fadeController;
    void Start(){
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
		fadeController = eventSystem.GetComponent<FadeController>();
    }
	void TaskOnClick(){
		fadeController.FadeOut();
		StartCoroutine(loadLevel());
	}

	IEnumerator loadLevel(){
		while(!fadeController.isDone){
			yield return null;
		}
		SceneManager.LoadScene("house.scene");
	}
}
