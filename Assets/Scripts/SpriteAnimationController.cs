using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationController : MonoBehaviour {

	SpriteAnimator[] animations;
	Hashtable animationTable;
	public Enums.AnimStates nextAnimation = Enums.AnimStates.Idle;
	//SpriteAnimator animationToPlay;
	SpriteAnimator animationCurrentlyPlaying;
	int numAnimations;
	// Use this for initialization
	void Start(){
		animationTable = new Hashtable();
		animations = gameObject.GetComponents<SpriteAnimator>();
		foreach(var animation in animations){
			animationTable.Add(animation.state, animation);
		}
		animationCurrentlyPlaying = findAnimation(nextAnimation);
		if(!animationCurrentlyPlaying){
			return;
		}
		animationCurrentlyPlaying.startAnimation();
	}
	
	// Update is called once per frame
	void Update(){
		if(nextAnimation != animationCurrentlyPlaying.state || !animationCurrentlyPlaying.isCurrentlyPlaying()){
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
	
	SpriteAnimator findAnimation(Enums.AnimStates state){
		return (SpriteAnimator) animationTable[state];
	}

	IEnumerator animationStarter(SpriteAnimator oldAnimation, SpriteAnimator newAnimation){
		oldAnimation.stopAnimation();
		yield return null;
		newAnimation.startAnimation();
	}
}
