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
		spriteAnimationController.nextAnimation = AnimationStates.States.MoveLeft;
	}
	public void moveRight(float amount){
		transform.position = transform.position + new Vector3(amount * speed, 0, 0);
		spriteAnimationController.nextAnimation = AnimationStates.States.MoveRight;
	}
	public void moveForward(float amount){
		transform.position = transform.position + new Vector3(0, amount * speed, 0);
		spriteAnimationController.nextAnimation = AnimationStates.States.MoveForward;
	}
	public void moveBackward(float amount){
		transform.position = transform.position + new Vector3(0, amount * speed, 0);
		spriteAnimationController.nextAnimation = AnimationStates.States.MoveBack;
	}
	public void stopMoving(){
		spriteAnimationController.nextAnimation = AnimationStates.States.Idle;
	}

	public void pauseMoving(){
		spriteAnimationController.sendToIdle();
	}
}
