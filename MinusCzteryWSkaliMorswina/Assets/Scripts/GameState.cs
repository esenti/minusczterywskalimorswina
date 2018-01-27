using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public List<Fan> fanlist = new List<Fan>();

    public GameObject CurrentFan;
	public Fan currentFan;
    public GameObject FanPrefab;

	// Use this for initialization
	void Start () {
		currentFan = CurrentFan.GetComponent<Fan> ();
		currentFan.isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("tab")) {
			int idx = (fanlist.IndexOf (currentFan)+1)%fanlist.Count;
			currentFan.isActive = false;
			currentFan = fanlist [idx];
			currentFan.isActive = true;
		}
	}
}
