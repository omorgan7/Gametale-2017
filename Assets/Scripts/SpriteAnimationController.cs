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
	void Start () {
		animations = gameObject.GetComponents<SpriteAnimator>();
		animationCurrentlyPlaying = findAnimation(nextAnimation);
		if(!animationCurrentlyPlaying){
			return;
		}
		animationCurrentlyPlaying.startAnimation();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(nextAnimation != animationCurrentlyPlaying.state){
			var animation = findAnimation(nextAnimation);
			if(!animation){
				return;
			}
			animation.startAnimation(); 
			animationCurrentlyPlaying.stopAnimation();
			animationCurrentlyPlaying = animation;
			// animationCurrentlyPlaying.startAnimation();
		}
	}

	public void sendToIdle(){
		animationCurrentlyPlaying.goIdle();
	}
	SpriteAnimator findAnimation(Enums.AnimStates state){
		foreach(var animation in animations){
			if(animation.state == nextAnimation){
				return animation ;
			}
		}
		return null;
	}
}
