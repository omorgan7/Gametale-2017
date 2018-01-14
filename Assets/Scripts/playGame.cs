using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {
	FadeController fadeController;
    void Start(){
        fadeController = gameObject.GetComponent<FadeController>();
    }
    void Update(){
        if(Input.GetButtonUp("Submit") && !fadeController.isDone){
            fadeController.FadeOut();
        }
        if(fadeController.isDone){
            SceneManager.LoadScene("house.scene");
        }
    }
}
