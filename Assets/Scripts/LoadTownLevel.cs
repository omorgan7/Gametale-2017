using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTownLevel : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "door"){
			 SceneManager.LoadScene("town.scene");
    
		}
	}
}
