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
	bool needsStarting = false;
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
	void Start(){
		StartCoroutine(spriteAnimation());
	}
	// void FixedUpdate(){
	// 	if(needsStarting){
	// 		StartCoroutine(animation());
	// 		needsStarting = false;
	// 	}
	// }
	public void startAnimation(){
		isPlaying = true;
	}
	public void stopAnimation(){
		isPlaying = false;
		indexDirection = 1;
		spriteIndex = 0;
	}

	public void goIdle(){
		stopAnimation();
		spriteIndex = 0;
		spriteRenderer.sprite = sprites[idleIndex];
	}

	IEnumerator spriteAnimation(){
		while(true){
			if(isPlaying){
				spriteRenderer.sprite = sprites[spriteIndex];
				if(spriteIndex == numSprites - 1 || (spriteIndex == 0 && indexDirection == -1)){
					if(!isLooping){
						break;
					}
					indexDirection *= -1;
				}
				spriteIndex += indexDirection;
			}
			yield return new WaitForSecondsRealtime(frameTime);
		}
	}

	public bool isCurrentlyPlaying(){
		return isPlaying;
	}
}