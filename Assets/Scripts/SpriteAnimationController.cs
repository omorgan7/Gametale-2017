using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationController : MonoBehaviour {

	SpriteAnimator[] animations;

	public Enums.AnimStates nextAnimation = Enums.AnimStates.Idle;
	//SpriteAnimator animationToPlay;
	SpriteAnimator animationCurrentlyPlaying;
	int numAnimations;
	// Use this for initialization
	void Start(){
		animations = gameObject.GetComponents<SpriteAnimator>();
		animationCurrentlyPlaying = findAnimation(nextAnimation);
		if(!animationCurrentlyPlaying){
			return;
		}
		animationCurrentlyPlaying.startAnimation();
	}
	
	// Update is called once per frame
	void Update(){
		if(nextAnimation != animationCurrentlyPlaying.state){
			var animation = findAnimation(nextAnimation);
			if(!animation){
				return;
			}
			SpriteAnimator old = animationCurrentlyPlaying;
			StartCoroutine(animationStarter(old, animation));
			animationCurrentlyPlaying = animation;
			// animationCurrentlyPlaying.startAnimation();
		}
	}

	public void sendToIdle(){
		animationCurrentlyPlaying.goIdle();
	}
	
	SpriteAnimator findAnimation(Enums.AnimStates state){
		foreach(var animation in animations){
			if(animation.state == state){
				return animation;
			}
		}
		return null;
	}

	IEnumerator animationStarter(SpriteAnimator oldAnimation, SpriteAnimator newAnimation){
		oldAnimation.stopAnimation();
		yield return null;
		newAnimation.startAnimation();
	}
}
