using UnityEngine;

public class InteractiveSpriteMover : MonoBehaviour {
	public GameObject speechBubble;
	// Use this for initialization
	SpriteMover spriteMover;
	private GameObject box;
	private NPC _npc;
	float right, forward;

	DialogueSystemNPC DSnpc = new DialogueSystemNPC();
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
		if(other.gameObject.tag != "npc"){
			return;
		}

		// have an if for if you press the spacebar.
		if(Input.GetButtonUp("Submit")){
			other.gameObject.GetComponent<NPCSpriteMover>().stopMoving();
			_npc = other.GetComponent<NPC>();
			print(_npc.getCatchphrase());
			StartCoroutine(DSnpc.speak(_npc.getCatchphrase(), box, speechBubble));
			//do some other stuff
		}
	//	print(other.gameObject.name);
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag != "npc"){
			return;
		}
		other.gameObject.GetComponent<NPCSpriteMover>().startMoving();
	}
}
