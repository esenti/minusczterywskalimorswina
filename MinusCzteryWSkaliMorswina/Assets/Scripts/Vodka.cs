using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vodka : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(Mathf.Sin(Time.time * 0.2f) * 0.005f, Mathf.Sin(Time.time * 0.2f) * 0.005f, 0);	
	}
}
