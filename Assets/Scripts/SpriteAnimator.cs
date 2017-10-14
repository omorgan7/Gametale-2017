using UnityEngine;
using System.Collections;

public class SpriteAnimator : MonoBehaviour {

	// Use this for initialization
	public string name;
	SpriteRenderer spriteRenderer;
	int spriteIndex = 0;
	int numSprites;

	int indexDirection = 1;

	public Sprite[] sprites;
	bool isPlaying;

	public float frameTime = 0.1f;

	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		numSprites = sprites.Length;
	}
	public void startAnimation(){
		isPlaying = true;
		StartCoroutine(animation());
	}
	public void stopAnimation(){
		isPlaying = false;
		indexDirection = 1;
		spriteIndex = 0;
	}
	IEnumerator animation(){
		while(isPlaying){
			yield return new WaitForSecondsRealtime(frameTime);
			spriteRenderer.sprite = sprites[spriteIndex];
			if(spriteIndex == numSprites - 1 || (spriteIndex == 0 && indexDirection == -1)){
				indexDirection *= -1;
			}
			spriteIndex += indexDirection;
		}
	}
}
