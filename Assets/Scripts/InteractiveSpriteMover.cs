using UnityEngine;

public class InteractiveSpriteMover : MonoBehaviour {

	// Use this for initialization
	
	public SpriteAnimationController spriteAnimationController;
	SpriteMover spriteMover;
	public float speed = 1f;

	float right, forward;
	// Update is called once per frame
	void Update () {

		if(right == 0 && forward == 0){
			spriteAnimationController.animationToPlay = (int) AnimationStates.States.Idle;
			return;
		}
		if(forward != 0 && right == 0){
			transform.position = transform.position + new Vector3(0, forward * speed, 0);
			if(forward < 0f){
				spriteAnimationController.animationToPlay = (int) AnimationStates.States.MoveForward;	
			}
			else{
				spriteAnimationController.animationToPlay = (int) AnimationStates.States.MoveBack;
			}
		}
		if(right != 0){
			transform.position = transform.position + new Vector3(right * speed, 0, 0);
			spriteAnimationController.animationToPlay = (int) AnimationStates.States.MoveLeft;
		}
	}
	void FixedUpdate(){
		right = Input.GetAxisRaw("Horizontal");
		forward = Input.GetAxisRaw("Vertical");
	}
	void OnTriggerStay2D(Collider2D other){
		print(other.gameObject.name);
	}
}
