using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBehaviour : MonoBehaviour {
	// Use this for initialization
	public AudioSource audioSource;
	public AudioClip chaseMusic;
	public GameObject monkContainer;
	GameObject[] monks;
	public GameObject bunbuku;
	enum Direction {Left, Right, Forward, Backward, None};
	bool hasBegun = false;
	public bool hasBeenCaught;
	bool isMoving;
	void Start(){
		monks = new GameObject[monkContainer.transform.childCount];
		for(int i = 0; i<monkContainer.transform.childCount; ++i){
			monks[i] = monkContainer.transform.GetChild(i).gameObject;
		}	
	}
	
	void Update () {
		if(hasBeenCaught){
			return;
		}
		if(bunbuku.activeSelf){
			if(!hasBegun){
				hasBegun = true;
				audioSource.Stop();
				audioSource.clip = chaseMusic;
				audioSource.Play();
				wildCraziness();
			}
		}
	}
	void wildCraziness(){
		foreach(var monk in monks){
			monk.GetComponent<NPCSpriteMover>().randomThreshold /= 5f;
			monk.GetComponent<NPCSpriteMover>().moveDuration *= 2f;
			monk.GetComponent<SpriteMover>().speed *= 5f;
		}
	}
}
