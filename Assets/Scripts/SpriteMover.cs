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
		print("left");
		transform.position = transform.position + new Vector3(amount * speed, 0, 0);
		spriteAnimationController.nextAnimation = Enums.AnimStates.MoveLeft;
	}
	public void moveRight(float amount){
		print("right");
		transform.position = transform.position + new Vector3(amount * speed, 0, 0);
		spriteAnimationController.nextAnimation = Enums.AnimStates.MoveRight;
	}
	public void moveForward(float amount){
		print("forward");
		transform.position = transform.position + new Vector3(0, amount * speed, 0);
		spriteAnimationController.nextAnimation = Enums.AnimStates.MoveForward;
	}
	public void moveBackward(float amount){
		print("back");
		transform.position = transform.position + new Vector3(0, amount * speed, 0);
		spriteAnimationController.nextAnimation = Enums.AnimStates.MoveBack;
	}
	public void stopMoving(){
		print("stop");
		spriteAnimationController.nextAnimation = Enums.AnimStates.Idle;
	}

	public void pauseMoving(){
		print("pause");
		spriteAnimationController.sendToIdle();
	}
}
