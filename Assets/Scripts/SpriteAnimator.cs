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

	public float frameTime = 0.1f;

	public AnimationStates.States state = AnimationStates.States.Idle;

	void Awake () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		numSprites = sprites.Length;
		if(numSprites == 1){
			isLooping = false;
		}
	}
	public void startAnimation(){
		if(!isPlaying){
			isPlaying = true;
			StartCoroutine(animation());
		}
	}
	public void stopAnimation(){
		isPlaying = false;
		indexDirection = 1;
		spriteIndex = 0;
	}
	IEnumerator animation(){
		while(isPlaying){
			spriteRenderer.sprite = sprites[spriteIndex];
			if(spriteIndex == numSprites - 1 || (spriteIndex == 0 && indexDirection == -1)){
				if(!isLooping){
					break;
				}
				indexDirection *= -1;
			}
			spriteIndex += indexDirection;
			yield return new WaitForSecondsRealtime(frameTime);
		}
	}
}
