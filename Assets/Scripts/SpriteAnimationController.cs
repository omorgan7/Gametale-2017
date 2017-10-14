using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationController : MonoBehaviour {

	SpriteAnimator[] animations;

	public AnimationStates.States nextAnimation = AnimationStates.States.Idle;
	//SpriteAnimator animationToPlay;
	SpriteAnimator animationCurrentlyPlaying;
	int numAnimations;
	// Use this for initialization
	void Start () {
		animations = gameObject.GetComponents<SpriteAnimator>();
		animationCurrentlyPlaying = findAnimation(nextAnimation);
		animationCurrentlyPlaying.startAnimation();
	}
	
	// Update is called once per frame
	void Update () {
		if(nextAnimation != animationCurrentlyPlaying.state){
			animationCurrentlyPlaying.stopAnimation();
			animationCurrentlyPlaying = findAnimation(nextAnimation);
			animationCurrentlyPlaying.startAnimation();
		}
	}

	SpriteAnimator findAnimation(AnimationStates.States state){
		foreach(var animation in animations){
			if(animation.state == nextAnimation){
				return animation ;
			}
		}
		return null;
	}
}
