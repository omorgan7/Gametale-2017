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
	float right, forward;
	private bool isTalking = false;
	private bool hasKettle = false;
	public GameObject speechBubble;
	public GameObject kettle;
	public GameObject textPanel;
	float speedMultiplier = 3f;
	float currentSpeed = 1f;
	EndLevel endLevel;
	
	
	//LoadText loadText = new LoadText();

	// Update is called once per frame
	void Start(){
		endLevel = GameObject.Find("EventSystem").GetComponent<EndLevel>();
		spriteMover = gameObject.GetComponent<SpriteMover>();
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
		//print(new Vector2(right, forward));
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
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "fire"){
			kettle.SetActive(true);	
			return;	
		}
		if(other.gameObject.tag != "npc"){
			return;
		}
		if(Input.GetButtonUp("Submit")){
			submitInteraction(other);
		}
	}

	void submitInteraction(Collider2D other){
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
		if((!hasKettle)|(_npc.getName()!="Head Monk")){
			_npc.turnOnBox();
		}
		else{
			if(_npc.getName()=="Head Monk"){
				StartCoroutine(other.gameObject.GetComponent<DialogueSystemMonk>().speak(0,2, speechBubble, monkBox));
				StartCoroutine(waitMonk());
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
		while (DialogueSystemBadger.isTalking){
			yield return null;
		}
		isTalking = false;
	}
	void OnTriggerStay2D(Collider2D other){
		if((other.gameObject.tag == "bunbuku")&&(SceneManager.GetActiveScene().name == "town.scene")){
			if(isTalking){
				return;
			}
			if((Input.GetButtonUp("Submit"))&&(!isTalking)){
				isTalking =  true;
				DialogueSystemBadger.isTalking = true;
				StartCoroutine(waitBunbuku());
				StartCoroutine(other.gameObject.GetComponent<DialogueSystemBadger>().speak(0,0, speechBubble,bunbukuBox));
				StartCoroutine(other.gameObject.GetComponent<DialogueSystemBadger>().disappear());
				kettle.SetActive(true);
			}
			return;
		}
		if(other.gameObject.tag == "kettle"){ //collect kettle
			if(Input.GetButtonUp("Submit")){
				other.gameObject.SetActive(false);
				hasKettle = true;
			}
			return;
		}

		if(other.gameObject.tag != "npc"){
			return;
		}
		if(Input.GetButtonUp("Submit")){
			submitInteraction(other);
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
