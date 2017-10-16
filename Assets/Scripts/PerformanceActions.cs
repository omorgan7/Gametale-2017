using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceActions : MonoBehaviour {

	// Use this for initialization
	MenuInput menuInput;
	PerformanceResults performanceResults;
	public GameObject bunbuku;
	public GameObject bunbukuShadow;
	public GameObject audience;
	public GameObject audienceShadow;

	bool isPerforming = false;
	bool canPerformAgain = false;
	float elapsedTime = 0f;
	float height = 2f;

	float twirlAngle = 45f;
	float twirlTime = 0.05f;
	void Start () {
		menuInput = gameObject.GetComponent<MenuInput>();
		performanceResults = gameObject.GetComponent<PerformanceResults>();
		StartCoroutine(comeInFromSides());
	}

	IEnumerator comeInFromSides(){
		float elapsedTime = 0f;
		float bunbukuInitialX = bunbuku.transform.position.x;
		float bunbukuShadowInitialX = bunbukuShadow.transform.position.x;
		float audienceInitialX = audience.transform.position.x;
		float audienceShadowInitialX = audienceShadow.transform.position.x;
		while(elapsedTime <= 1f){
			bunbuku.transform.position = new Vector3(bunbukuInitialX + Mathf.SmoothStep(0f,7,elapsedTime), bunbuku.transform.position.y,0);
			bunbukuShadow.transform.position = new Vector3(bunbukuShadowInitialX + Mathf.SmoothStep(0f,7,elapsedTime), bunbukuShadow.transform.position.y,0);
			audience.transform.position = new Vector3(audienceInitialX - Mathf.SmoothStep(0f,7,elapsedTime), audience.transform.position.y,0);
			audienceShadow.transform.position = new Vector3(audienceShadowInitialX - Mathf.SmoothStep(0f,7,elapsedTime), audienceShadow.transform.position.y,0);
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		canPerformAgain = true;
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
		yield return new WaitForSecondsRealtime(0.5f);
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
		float result = Random.value;
		if(result < 0.3){
			performanceResults.amazed();
		}
		else{
			performanceResults.mild();
		}
		
	}

	IEnumerator jump(){
		yield return new WaitForSecondsRealtime(0.5f);
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
		float result = Random.value;
		if(result < 0.1){
			performanceResults.amazed();
		}
		else if(result < 0.6){
			performanceResults.mild();
		}
		else{
			performanceResults.disappointed();
		}
		canPerformAgain = true;
	}

	IEnumerator twirl(){
		yield return new WaitForSecondsRealtime(0.5f);
		Vector3 initialPosition = bunbuku.transform.position;
		float elapsedTime = 0f;
		for(int i = 0; i < 3; ++i){
			do{
			bunbuku.transform.Rotate(new Vector3(0f,0f, twirlAngle*Time.deltaTime));
			bunbuku.transform.position = initialPosition;
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForEndOfFrame();
		}while(elapsedTime <= twirlTime);
		elapsedTime = 0f;
		do{
			bunbuku.transform.Rotate(new Vector3(0f,0f, -2*twirlAngle*Time.deltaTime));
			bunbuku.transform.position = initialPosition;
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForEndOfFrame();
		}while(elapsedTime <= twirlTime);
		elapsedTime = 0f;
		do{
			bunbuku.transform.Rotate(new Vector3(0f,0f, twirlAngle*Time.deltaTime));
			bunbuku.transform.position = initialPosition;
			elapsedTime += Time.fixedDeltaTime;
			yield return new WaitForEndOfFrame();
		}while(elapsedTime <= twirlTime);
		elapsedTime = 0f;
		bunbuku.transform.Rotate(new Vector3(0f,0f, -bunbuku.transform.rotation.eulerAngles.z));
		}
		
		bunbuku.transform.position = initialPosition;
		float result = Random.value;
		if(result < 0.1){
			performanceResults.amazed();
		}
		else if(result < 0.8){
			performanceResults.mild();
		}
		else{
			performanceResults.disappointed();
		}
		canPerformAgain = true;
	}
}
