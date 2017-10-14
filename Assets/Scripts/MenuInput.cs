using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : MonoBehaviour {

	// Use this for initialization

	public Enums.Performances selected = Enums.Performances.Flip;
	// Update is called once per frame
	void LateUpdate () {

		if(Input.GetButtonDown("Vertical")){
			int sign;
			if(Input.GetAxisRaw("Vertical") < 0){
				sign = -1;
			}
			else{
				sign = 1;
			}
			int selectedIndex = ((int) selected + sign);
			if(selectedIndex == -1){
				selectedIndex = 2;
			}
			if(selectedIndex == 3){
				selectedIndex = 0;
			}
			selected = (Enums.Performances) selectedIndex;
		}
	}
}
