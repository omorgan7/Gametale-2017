using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceActions : MonoBehaviour {

	// Use this for initialization
	MenuInput menuInput;
	public GameObject bunbuku;
	bool isPerforming = false;
	bool canPerformAgain = true;
	float elapsedTime = 0f;
	float height = 2f;
	void Start () {
		menuInput = gameObject.GetComponent<MenuInput>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isPerforming){
			canPerformAgain = false;
			isPerforming = false;
			switch(menuInput.selected){
				case(Enums.Performances.Flip):
				StartCoroutine(flip());
				break;
				case(Enums.Performances.Twirl):
				StartCoroutine(twirl());
				break;
				case(Enums.Performances.Jump):
				StartCoroutine(jump());
				break;
			}
			
		}
	}
	void FixedUpdate(){
		if(canPerformAgain){
			if(Input.GetButtonDown("Submit")){
				isPerforming = true;
			}
		}
	}

	IEnumerator flip(){
		Vector3 initialPosition = bunbuku.transform.position;
		elapsedTime = 0f;
		do{
			bunbuku.transform.Rotate(new Vector3(0f,0f, 360f*Time.fixedDeltaTime));
			bunbuku.transform.position = initialPosition;
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForEndOfFrame();
		}while(elapsedTime <= 1f);
		bunbuku.transform.Rotate(new Vector3(0f,0f, -7.2f));
		bunbuku.transform.position = initialPosition;
		canPerformAgain = true;
	}

	IEnumerator jump(){
		elapsedTime = 0f;
		Vector3 initialPosition = bunbuku.transform.position;
		while(elapsedTime <= 0.5f){
			bunbuku.transform.position = new Vector3(initialPosition.x, initialPosition.y + Mathf.SmoothStep(0f,height,2f*elapsedTime),initialPosition.z);
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		while(elapsedTime > 0f){
			bunbuku.transform.position = new Vector3(initialPosition.x, initialPosition.y + Mathf.SmoothStep(0f,height,2f*elapsedTime ),initialPosition.z);
			elapsedTime -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		canPerformAgain = true;
	}

	IEnumerator twirl(){
		Vector3 initialPosition = bunbuku.transform.position;
		var spriteController = bunbuku.transform.GetChild(0).GetComponent<SpriteAnimationController>();
		spriteController.nextAnimation = Enums.AnimStates.Idle;
		yield return new WaitForSecondsRealtime(0.25f);
		spriteController.nextAnimation = Enums.AnimStates.MoveRight;
		yield return new WaitForSecondsRealtime(0.25f);
		spriteController.nextAnimation = Enums.AnimStates.Idle;
		yield return new WaitForSecondsRealtime(0.25f);
		spriteController.nextAnimation = Enums.AnimStates.MoveLeft;
		yield return new WaitForSecondsRealtime(0.25f);
		canPerformAgain = true;
	}
}
