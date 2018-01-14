using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InteractiveSpriteMover : MonoBehaviour {
	// Use this for initialization
	SpriteMover spriteMover;
	private GameObject bunbukuBox;
	private GameObject monkBox;
	private NPCBehaviour _npc;
	private RayCastTrigger rayCaster;
	float right, forward;
	public bool isTalking = false;
	private bool hasKettle = false;
	public GameObject speechBubble;
	public GameObject kettle;
	public GameObject textPanel;
	float speedMultiplier = 3f;
	float currentSpeed = 1f;
	EndLevel endLevel;
	
	void Start(){
		endLevel = GameObject.Find("EventSystem").GetComponent<EndLevel>();
		spriteMover = gameObject.GetComponent<SpriteMover>();
		rayCaster = gameObject.GetComponent<RayCastTrigger>();
	}
	void LateUpdate(){
		if(isTalking){
			spriteMover.pauseMoving();
			return;
		}

		right = Input.GetAxisRaw("Horizontal");
		forward = Input.GetAxisRaw("Vertical");

		if(Input.GetKey(KeyCode.LeftShift)){
			currentSpeed = speedMultiplier;
		}
		else{
			currentSpeed = 1f;
		}

		if(forward == 0 && right == 0){
			spriteMover.pauseMoving();
			return;
		}

		if(right > 0f){
			spriteMover.moveRight(right*currentSpeed);
		}
		else if(right < 0f){
			spriteMover.moveLeft(right*currentSpeed);
			return;
		}

		if(forward < 0f){
			spriteMover.moveForward(forward*currentSpeed);
		}
		else if(forward > 0f){
			spriteMover.moveBackward(forward*currentSpeed);
		}
	}

	void Update(){
		if(rayCaster.triggeredObject != null){
			collidedFunction(rayCaster.triggeredObject);
		}
	}
	void collidedFunction(GameObject other){
		
		if(other.gameObject.tag == "fire"){
			if(kettle){
				kettle.SetActive(true);
			}
				
			if(SceneManager.GetActiveScene().name == "temple2.scene"){
				EndLevel.sceneFinished = true;
			}
			return;	
		}

		if((other.tag == "bunbuku") && (SceneManager.GetActiveScene().name == "town.scene")){
			if(isTalking){
				return;
			}
			if((Input.GetButtonUp("Submit")) && (!isTalking) && (!DialogueSystemBadger.isTalking)){
				isTalking =  true;
				DialogueSystemBadger.isTalking = true;
				StartCoroutine(waitBunbuku());
				StartCoroutine(other.GetComponent<DialogueSystemBadger>().speak(0, 0, speechBubble,bunbukuBox));
				StartCoroutine(other.GetComponent<DialogueSystemBadger>().disappear());
				kettle.SetActive(true);
			}
			return;
		}

		if(other.tag == "kettle"){ //collect kettle
			if(Input.GetButtonUp("Submit")){
				other.SetActive(false);
				hasKettle = true;
			}
			return;
		}

		if(other.tag != "npc"){
			return;
		}

		if(Input.GetButtonUp("Submit")){
			if(isTalking){
				NPCBehaviour tempNPC = other.GetComponent<NPCBehaviour>();
				if(tempNPC != null){
					tempNPC.turnOffBox();
					isTalking = false;
					other.GetComponent<NPCSpriteMover>().startMoving();
				}
			}
			else{
				submitInteraction(other);
			}
			
		}
	}
	void submitInteraction(GameObject other){
		isTalking = true;
		Vector3 positionDifference = transform.position - other.transform.position;
		if(Mathf.Abs(positionDifference.x) > Mathf.Abs(positionDifference.y)){
			if(positionDifference.x <= 0f){
				other.GetComponent<NPCSpriteMover>().spriteMover.moveLeft(1f);
			}
			else{
				other.GetComponent<NPCSpriteMover>().spriteMover.moveRight(1f);
			}
		}
		else{
			if(positionDifference.y <= 0f){
				other.GetComponent<NPCSpriteMover>().spriteMover.moveForward(1f);
			}
			else{
				other.GetComponent<NPCSpriteMover>().spriteMover.moveBackward(1f);
			}
		}
		other.GetComponent<NPCSpriteMover>().stopMoving();
		// other.GetComponent<SpriteMover>().pauseMoving();

		_npc = other.GetComponent<NPCBehaviour>();

		if((!hasKettle) | (_npc.getName() != "Head Monk")){
			_npc.turnOnBox();
		}
		else{
			if(_npc.getName() == "Head Monk"){
				if(!DialogueSystemMonk.isTalking){
					StartCoroutine(other.GetComponent<DialogueSystemMonk>().speak(0, 2, speechBubble, monkBox));
					StartCoroutine(waitMonk());
				}
			}
		}
	}
	IEnumerator waitMonk(){
		while(DialogueSystemMonk.isTalking){
			yield return null;
		}
		EndLevel.sceneFinished = true;
		endLevel.endLevelText(textPanel);
	}
	
	IEnumerator waitBunbuku(){
		while(DialogueSystemBadger.isTalking){
			yield return null;
		}
		isTalking = false;
	}

	public void moveAgain(){
		isTalking = false;
	}
}
