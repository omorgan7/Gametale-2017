using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayers : MonoBehaviour {
	public int defaultLayer = 0;
	private int tempLayer;
	
	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "scenery"){
			print("hit house");
			if(gameObject.transform.position.y < other.gameObject.transform.position.y){
				print("lower");
				if(gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder < other.gameObject.GetComponent<SpriteRenderer>().sortingOrder){
					tempLayer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder;
					gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = other.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
					other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = tempLayer;
				}
			}
			if(gameObject.transform.position.y > other.gameObject.transform.position.y){
				print("higher");
				if(gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder > other.gameObject.GetComponent<SpriteRenderer>().sortingOrder){
					tempLayer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder;
					gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = other.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
					other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = tempLayer;
				}
			}
		}
	}
	void OnTriggerLeave2D(Collider2D other){
		gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = defaultLayer;
	}
}
