using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

	public bool isActive = false;

	// Use this for initialization
	void Start () {
		GameState gameState = GameObject.Find("GameState").GetComponent<GameState>();
		gameState.fanlist.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
		if (isActive) {
			transform.Rotate (new Vector3 (0, 0, -100 * horizontal * Time.deltaTime));
		}
	}
}