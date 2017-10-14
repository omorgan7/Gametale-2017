using UnityEngine;
using UnityEngine.UI;

public class UIPerformanceSelector : MonoBehaviour {

	MenuInput menuInput;
	Enums.Performances previousSelection = Enums.Performances.Flip;

	float[] anchorPositions = {0.8f, 0.6f, 0.4f};
	public RectTransform arrow;
	// Use this for initialization
	void Start () {
		menuInput = gameObject.GetComponent<MenuInput>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(previousSelection != menuInput.selected){
			previousSelection = menuInput.selected;
			Vector2 minAnchors = arrow.anchorMin;
			Vector2 maxAnchors = arrow.anchorMax;
			//print((int)previousSelection);
			arrow.anchorMax = new Vector2(maxAnchors.x,anchorPositions[(int)previousSelection]);
			arrow.anchorMin = new Vector2(minAnchors.x, arrow.anchorMax.y - 0.2f);
		}
	}
}
