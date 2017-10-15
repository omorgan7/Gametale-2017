using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceResults : MonoBehaviour {

	// Use this for initialization
	public GameObject[] topPanels = new GameObject[3];
	public RectTransform progressBar;
	public float progress;
	float newProgress;
	void Start(){
		progress = progressBar.anchorMax.x;
		newProgress = progress;
	}

	void LateUpdate(){
		if(newProgress >1f){
			newProgress = 1f;
		}
		if(progress != newProgress){
			if(progress < newProgress){
				progress += Time.deltaTime*0.1f;
			}
			else{
				progress -= Time.deltaTime*0.1f;
			}
			if(Mathf.Abs(progress-newProgress) < 1e-3){
				progress = newProgress;
			}	
			progressBar.anchorMax = new Vector2(progress, progressBar.anchorMax.y);	
		}

	}
	public void disappointed(){
		StartCoroutine(switchPanel(0));
		newProgress -= 0.05f;
	}

	public void mild(){
		StartCoroutine(switchPanel(1));
		newProgress += 0.1f;
	}

	public void amazed(){
		StartCoroutine(switchPanel(2));
		newProgress += 0.5f;
	}

	IEnumerator switchPanel(int index){
		topPanels[index].SetActive(true);
		yield return new WaitForSecondsRealtime(3f);
		topPanels[index].SetActive(false);
	}
}

