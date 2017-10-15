using UnityEngine;
using UnityEngine.UI;

public class InteractiveSpriteMover : MonoBehaviour {
	// Use this for initialization
	SpriteMover spriteMover;
	private GameObject box;
	private NPCBehaviour _npc;
	float right, forward;
	private bool isTalking = false;
	private bool hasKettle = false;
	//LoadText loadText = new LoadText();

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
		//print(new Vector2(right, forward));
		if(forward == 0 && right == 0){
			spriteMover.pauseMoving();
			return;
		}
		if(right > 0f){
			spriteMover.moveRight(right);
		}
		else if(right < 0f){
			spriteMover.moveLeft(right);
			return;
		}
		if(forward < 0f){
			spriteMover.moveForward(forward);
		}
		else if(forward > 0f){
			spriteMover.moveBackward(forward);
		}


	}
	void OnTriggerStay2D(Collider2D other){
		// if(other.gameObject.tag == "kettle"){ //collect kettle
		// 	if(Input.GetButtonUp("Submit")){
		// 		print("got kettle");
		// 		other.gameObject.SetActive(false);
		// 		hasKettle = true;
		// 	}
		// 	return;
		// }
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
			//if(!hasKettle){
				_npc.turnOnBox();
			// }
			// else{
			// 	if(_npc.getName()=="Head Monk"){
			// 		StartCoroutine(other.gameObject.GetComponent<DialogueSystemMonk>().speak(0,2));
			// 	}
			// }
			
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
