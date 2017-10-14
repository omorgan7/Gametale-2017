using UnityEngine;

public class NPCSpriteMover : MonoBehaviour {

	// Use this for initialization
	SpriteMover spriteMover;
	float right, forward;

	public float randomThreshold = 0.1f;
	public float moveDuration = 1f;

	bool isMoving = true;

	float elapsedTime = 0f;
	// Update is called once per frame
	void Start(){
		spriteMover = gameObject.GetComponent<SpriteMover>();
	}

	void Update(){
		if(!isMoving){
			pauseMoving();
			return;
		}
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= moveDuration){
			float randomNumber = Random.value;
			elapsedTime = 0;
			if(randomNumber > 0.1f){
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
				pauseMoving();
			}
		}
	}

	void pauseMoving(){
		right = 0f;
		forward = 0f;
		spriteMover.stopMoving();
	}

	public void startMoving(){
		isMoving = true;
	}

	public void stopMoving(){
		isMoving = false;
	}

	void FixedUpdate(){
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
}
