using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildBehaviour : MonoBehaviour {

	// Use this for initialization
	public GameObject monkContainer;

	GameObject[] monks;

	public GameObject bunbuku;
	enum Direction {Left, Right, Forward, Backward, None};
	Direction direction = Direction.None;
	SpriteMover bunbukuMover;
	bool hasBegun = false;
	public bool hasBeenCaught;
	bool isMoving;
	void Start(){
		monks = new GameObject[monkContainer.transform.childCount];
		bunbukuMover = bunbuku.GetComponent<SpriteMover>();
		for(int i = 0; i<monkContainer.transform.childCount; ++i){
			monks[i] = monkContainer.transform.GetChild(i).gameObject;
		}	
	}
	// Update is called once per frame
	void Update () {
		if(hasBeenCaught){
			return;
		}
		if(bunbuku.activeSelf){
			if(!hasBegun){
				hasBegun = true;
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
		//StartCoroutine(bunbukuMovement());
	}
	void FixedUpdate(){
		// switch(direction){
		// 	case(Direction.Left):
		// 	bunbukuMover.moveLeft(1f);
		// 	break;
		// 	case(Direction.Right):
		// 	bunbukuMover.moveRight(1f);
		// 	break;
		// 	case(Direction.Forward):
		// 	bunbukuMover.moveForward(1f);
		// 	break;
		// 	case(Direction.Backward):
		// 	bunbukuMover.moveBackward(1f);
		// 	break;
		// 	default:
		// 	break;
		// }
	}

	// IEnumerator bunbukuMovement(){
	// 	// SpriteMover bunbukuMover = bunbuku.GetComponent<SpriteMover>();
	// 	// while(!hasBeenCaught){
	// 	// 	direction = Direction.Right;
	// 	// 	yield return new WaitForSecondsRealtime(1f);
	// 	// 	direction = Direction.Forward;
	// 	// 	yield return new WaitForSecondsRealtime(0.5f);
	// 	// 	direction = Direction.Left;
	// 	// 	yield return new WaitForSecondsRealtime(1f);
	// 	// 	direction = Direction.Backward;
	// 	// 	yield return new WaitForSecondsRealtime(0.5f);
	// 	// }
	// 	// direction = Direction.None;
	// }
}
