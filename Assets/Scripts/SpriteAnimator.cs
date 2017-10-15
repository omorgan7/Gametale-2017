using UnityEngine;
using System.Collections;

public class SpriteAnimator : MonoBehaviour {

	// Use this for initialization
	SpriteRenderer spriteRenderer;
	int spriteIndex = 0;
	int numSprites;

	int indexDirection = 1;

	public Sprite[] sprites;
	bool isPlaying = false;
	public bool isLooping = true;
	bool needsStarting = true;
	public int idleIndex;

	public float frameTime = 0.1f;

	public Enums.AnimStates state = Enums.AnimStates.Idle;

	void Awake () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		numSprites = sprites.Length;
		if(numSprites == 1){
			isLooping = false;
		}
	}
	public void startAnimation(){
		if(isPlaying){
			return;
		}
		needsStarting = true;
		isPlaying = true;
		indexDirection = 1;
	}
	public void stopAnimation(){
		// StopCoroutine(animation());
		isPlaying = false;
		indexDirection = 1;
		spriteIndex = 0;
	}

	public void goIdle(){
		//stopAnimation();
		if(idleIndex < 0 || idleIndex > numSprites){
			return;
		}
		spriteRenderer.sprite = sprites[idleIndex];
		indexDirection = 0;
	}
	void FixedUpdate(){
		if(needsStarting){
			StartCoroutine(spriteAnimation());
			needsStarting = false;
		}
		if(!isPlaying){
			StopCoroutine(spriteAnimation());
		}
	}
	// IEnumerator animation(){
	// 	while(isPlaying){
	// 		spriteRenderer.sprite = sprites[spriteIndex];
	// 		if(spriteIndex == numSprites - 1 || (spriteIndex == 0 && indexDirection == -1)){
	// 			if(!isLooping){
	// 				break;
	// 			}
	// 			indexDirection *= -1;
	// 		}
	// 		spriteIndex += indexDirection;
	// 		yield return new WaitForSecondsRealtime(frameTime);
	// 	}
	// }
	IEnumerator spriteAnimation(){
		while(isPlaying){
			spriteRenderer.sprite = sprites[spriteIndex];
			yield return new WaitForSecondsRealtime(frameTime);
			if(spriteIndex == numSprites - 1 || (spriteIndex == 0 && indexDirection == -1)){
					if(!isLooping){
						indexDirection = 0;
					}
					indexDirection *= -1;
				}
			spriteIndex += indexDirection;
		}
	}

}
