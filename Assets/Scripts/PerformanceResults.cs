using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PerformanceResults : MonoBehaviour {

	// Use this for initialization
	public GameObject[] topPanels = new GameObject[3];
	public AudioClip[] clips = new AudioClip[3];
	public AudioClip ambient;
	public RectTransform progressBar;
	AudioSource audioSource;
	public float progress;
	float newProgress;
	void Start(){
		progress = progressBar.anchorMax.x;
		newProgress = progress;
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = ambient;
		audioSource.Play();
	}
	IEnumerator switchLevel(){
		audioSource.Stop();
		audioSource.clip = clips[2];
		audioSource.volume *= 2f;
		audioSource.Play();
		yield return new WaitForSecondsRealtime(5f);
		var fadecontroller = gameObject.GetComponent<FadeController>();
		fadecontroller.FadeOut();
		while(!fadecontroller.isDone){
			yield return null;
		}
		SceneManager.LoadScene("town3.scene");
	}
	void LateUpdate(){
		if(newProgress >1f){
			newProgress = 1f;
			StartCoroutine(switchLevel());
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
		audioSource.Stop();
		audioSource.clip = clips[0];
		audioSource.volume *= 2;
		audioSource.Play();
		StartCoroutine(switchPanel(0));
		newProgress -= 0.05f;
	}

	public void mild(){
		audioSource.Stop();
		audioSource.clip = clips[1];
		audioSource.volume *= 2;
		audioSource.Play();
		StartCoroutine(switchPanel(1));
		newProgress += 0.1f;
	}

	public void amazed(){
		audioSource.Stop();
		audioSource.clip = clips[2];
		audioSource.volume *= 2;
		audioSource.Play();
		StartCoroutine(switchPanel(2));
		newProgress += 0.5f;
	}

	IEnumerator switchPanel(int index){
		topPanels[index].SetActive(true);
		yield return new WaitForSecondsRealtime(5f);
		topPanels[index].SetActive(false);
		audioSource.Stop();
		audioSource.clip = ambient;
		audioSource.volume = 0.2f;
		audioSource.Play();
	}
}

