using UnityEngine;

public class SpriteMover : MonoBehaviour {

	// Use this for initialization
	
	public SpriteAnimationController spriteAnimationController;
	public float speed = 1f;
	// Update is called once per frame
	public void MoveLeft(float amount){
		transform.position = transform.position + new Vector3(amount * speed, 0, 0);
		spriteAnimationController.animationToPlay = (int) AnimationStates.States.MoveLeft;
	}
	public void MoveRight(float amount){
		transform.position = transform.position + new Vector3(amount * speed, 0, 0);
		spriteAnimationController.animationToPlay = (int) AnimationStates.States.MoveRight;
	}
	public void MoveForward(float amount){
		transform.position = transform.position + new Vector3(0, amount * speed, 0);
		spriteAnimationController.animationToPlay = (int) AnimationStates.States.MoveForward;
	}
	public void MoveBackward(float amount){
		transform.position = transform.position + new Vector3(0, amount * speed, 0);
		spriteAnimationController.animationToPlay = (int) AnimationStates.States.MoveBack;
	}
}
