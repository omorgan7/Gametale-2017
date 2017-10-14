using UnityEngine;

public class SpriteMover : MonoBehaviour {

	// Use this for initialization
	
	SpriteAnimationController spriteAnimationController;
	public float speed = 0.1f;
	bool isMoving;
	void Start(){
		spriteAnimationController = gameObject.GetComponentInChildren<SpriteAnimationController>();
	}
	// Update is called once per frame
	public void moveLeft(float amount){
		transform.position = transform.position + new Vector3(amount * speed, 0, 0);
		spriteAnimationController.nextAnimation = Enums.AnimStates.MoveLeft;
	}
	public void moveRight(float amount){
		transform.position = transform.position + new Vector3(amount * speed, 0, 0);
		spriteAnimationController.nextAnimation = Enums.AnimStates.MoveRight;
	}
	public void moveForward(float amount){
		transform.position = transform.position + new Vector3(0, amount * speed, 0);
		spriteAnimationController.nextAnimation = Enums.AnimStates.MoveForward;
	}
	public void moveBackward(float amount){
		transform.position = transform.position + new Vector3(0, amount * speed, 0);
		spriteAnimationController.nextAnimation = Enums.AnimStates.MoveBack;
	}
	public void stopMoving(){
		spriteAnimationController.nextAnimation = Enums.AnimStates.Idle;
	}

	public void pauseMoving(){
		spriteAnimationController.sendToIdle();
	}
}
