using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationController : MonoBehaviour {

	public SpriteAnimator[] animations;

	public int animationToPlay;
	int animationCurrentlyPlaying;
	int numAnimations;
	// Use this for initialization
	void Start () {
		numAnimations = animations.Length;
		animationCurrentlyPlaying = animationToPlay;
		animations[animationToPlay].startAnimation();
	}
	
	// Update is called once per frame
	void Update () {
		if(animationToPlay < 0 || animationToPlay >= numAnimations){
			animationToPlay = animationCurrentlyPlaying;
			return;
		}
		if(animationToPlay != animationCurrentlyPlaying){
			animations[animationCurrentlyPlaying].stopAnimation();
			animations[animationToPlay].startAnimation();
			animationCurrentlyPlaying = animationToPlay;
		}
	}
}
