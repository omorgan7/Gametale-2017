using UnityEngine;

public class URLClicker : MonoBehaviour {
    public void OpenFigurine() {

		if(Application.platform == RuntimePlatform.WebGLPlayer)
		{
			Application.ExternalEval("window.open(\"https://sketchfab.com/models/7ffa23f14a9e48f89de9e7656dce0ac7\",\"_blank\")");
		}
		else {
			Application.OpenURL("https://sketchfab.com/models/7ffa23f14a9e48f89de9e7656dce0ac7");
		}
        
    }

	public void OpenGametale() {
		if(Application.platform == RuntimePlatform.WebGLPlayer)
		{
			Application.ExternalEval("window.open(\"https://gametale.org/\",\"_blank\")");
		}
		else {
        	Application.OpenURL("https://gametale.org/");
		}
    }
}
