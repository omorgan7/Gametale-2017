using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour {
	private Button button;
    void Start(){
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }
	void TaskOnClick(){
		 Application.Quit();
	}
}
