using UnityEngine;
using UnityEngine.UI;

public class InteractiveSpriteMover : MonoBehaviour {
	// Use this for initialization
	SpriteMover spriteMover;
	private GameObject box;
	private NPCBehaviour _npc;
	float right, forward;
	private bool isTalking = false;
	//LoadText loadText = new LoadText();

	DialogueSystemNPC DSnpc = new DialogueSystemNPC();
	// Update is called once per frame
	void Start(){
		spriteMover = gameObject.GetComponent<SpriteMover>();
	}
	void FixedUpdate(){
		if(isTalking){
			spriteMover.pauseMoving();
			return;
		}
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
		if(other.gameObject.tag != "npc"){
			return;
		}
		// have an if for if you press the spacebar.
		if(Input.GetButtonUp("Submit")){
			//face the player:
			isTalking = true;
			Vector3 positionDifference = transform.position - other.transform.position;
			if(Mathf.Abs(positionDifference.x) > Mathf.Abs(positionDifference.y)){
				if(positionDifference.x <= 0f){
					other.gameObject.GetComponent<NPCSpriteMover>().spriteMover.moveLeft(1f);
				}
				else{
					other.gameObject.GetComponent<NPCSpriteMover>().spriteMover.moveRight(1f);
				}
			}
			else{
				if(positionDifference.y <= 0f){
					other.gameObject.GetComponent<NPCSpriteMover>().spriteMover.moveForward(1f);
				}
				else{
					other.gameObject.GetComponent<NPCSpriteMover>().spriteMover.moveBackward(1f);
				}
			}
			other.gameObject.GetComponent<NPCSpriteMover>().stopMoving();
			_npc = other.gameObject.GetComponent<NPCBehaviour>();
			_npc.turnOnBox();
		}
		
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag != "npc"){
			return;
		}
		other.gameObject.GetComponent<NPCSpriteMover>().startMoving();
	}

	public void moveAgain(){
		isTalking = false;
	}
}
