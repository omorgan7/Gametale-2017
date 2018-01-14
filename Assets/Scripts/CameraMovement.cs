using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public float xDamping = 3.0f;
	public float yDamping = 3.0f;
	private Vector3 playerPosition;
	private Vector3 CameraPosition;
	private float currentX;
	private float currentY;
	private float goalX;
	private float goalY;
	private float interpX;
	private float interpY;

	void Start () {
		playerPosition = player.transform.position;
		gameObject.transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);
	}
	
	void Update () {
		currentX = gameObject.transform.position.x;
		currentY = gameObject.transform.position.y;
		goalX = player.transform.position.x;
		goalY = player.transform.position.y;

		interpX = Mathf.Lerp (currentX, goalX, xDamping * Time.deltaTime);
		interpY = Mathf.Lerp (currentY, goalY, yDamping * Time.deltaTime);

		gameObject.transform.position = new Vector3(interpX, interpY, -10);		
	}
}
