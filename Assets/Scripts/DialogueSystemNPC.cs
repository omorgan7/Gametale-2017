using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystemNPC : MonoBehaviour {
	public static GameObject[] allNPCS;  

	// Use this for initialization
	void Start () {
		allNPCS = GameObject.FindGameObjectsWithTag("test");
		print(allNPCS.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
