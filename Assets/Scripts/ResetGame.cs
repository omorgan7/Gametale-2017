using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {
	private Button button;
    void Start(){
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }
	

	void TaskOnClick(){
	}
}
