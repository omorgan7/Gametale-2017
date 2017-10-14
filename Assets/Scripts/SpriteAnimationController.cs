using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationController : MonoBehaviour {

	SpriteAnimator[] animations;

	public Enums.States nextAnimation = Enums.AnimStates.Idle;
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
	void Update () {
		if(nextAnimation != animationCurrentlyPlaying.state){
			print("hello");
			var animation = findAnimation(nextAnimation);
			if(!animation){
				return;
			} 
			animationCurrentlyPlaying.stopAnimation();
			animationCurrentlyPlaying = animation;
			animationCurrentlyPlaying.startAnimation();
		}
	}

	public void sendToIdle(){
		animationCurrentlyPlaying.goIdle();
	}
	SpriteAnimator findAnimation(Enums.States state){
		foreach(var animation in animations){
			if(animation.state == nextAnimation){
				return animation ;
			}
		}
		return null;
	}
}
