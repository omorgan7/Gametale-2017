using UnityEngine;

public class InteractiveSpriteMover : MonoBehaviour {

	// Use this for initialization
	SpriteMover spriteMover;
	float right, forward;
	// Update is called once per frame
	void Start(){
		spriteMover = gameObject.GetComponent<SpriteMover>();
	}
	void FixedUpdate(){
		right = Input.GetAxisRaw("Horizontal");
		forward = Input.GetAxisRaw("Vertical");
		if(forward < 0f){
			spriteMover.moveForward(forward);
		}
		else if(forward > 0f){
			spriteMover.moveBackward(forward);
		}
		if(right > 0f){
			spriteMover.moveRight(right);
		}
		else if(right < 0f){
			spriteMover.moveLeft(right);
		}
		if(forward == 0 && right == 0){
			spriteMover.stopMoving();
		}
	}
	void OnTriggerStay2D(Collider2D other){
		print(other.gameObject.name);
	}
}
