using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkFixer : MonoBehaviour {

	// Use this for initialization
	Vector3 pos;
	void Start () {
		pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = pos;
	}
}
