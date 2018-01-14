using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimator : MonoBehaviour {

	// Use this for initialization
	SpriteRenderer spriteRenderer;
	public float framerate = 0.1f;
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.PingPong(Time.time, 0.8f) + 0.2f);
	}
}
