﻿using UnityEngine;

public class NPCSpriteMover : MonoBehaviour {

	// Use this for initialization
	public SpriteMover spriteMover;
	float right, forward;

	public float randomThreshold = 0.1f;
	public float moveDuration = 1f;

	bool isMoving = true;

	float elapsedTime = 0f;
	void Start(){
		spriteMover = gameObject.GetComponent<SpriteMover>();
	}

	void Update(){
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= moveDuration){
			float randomNumber = Random.value;
			elapsedTime = 0;
			if(randomNumber > randomThreshold){
				Vector2 direction = Random.insideUnitCircle;
				if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
					right = direction.x;
					forward = 0f;
				}
				else{
					forward = direction.y;
					right = 0f;
				}
			}
			else{
				right = 0;
				forward = 0;
			}
		}
	}
	public void pauseMoving(){
		right = 0f;
		forward = 0f;
		spriteMover.pauseMoving();
	}
	public void startMoving(){
		isMoving = true;
	}

	public void stopMoving(){
		isMoving = false;
		right = 0f;
		forward = 0f;
	}
	void FixedUpdate(){
		if(!isMoving){
			pauseMoving();
			return;
		}
		if(forward == 0 && right == 0){
			spriteMover.pauseMoving();
			return;
		}
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
	}
}
