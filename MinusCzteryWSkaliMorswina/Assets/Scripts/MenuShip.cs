using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShip : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		Vector3 movement = new Vector3 (0, 1, 0);
		transform.Translate(movement * Time.deltaTime * 0.2f);

	}
}
