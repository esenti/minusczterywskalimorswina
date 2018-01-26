using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public GameObject fan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D col = fan.GetComponent<Collider2D>();

        bool inFan = col.OverlapPoint(new Vector2(transform.position.x, transform.position.y));
        Debug.Log(inFan);

        if (inFan)
        {
            Vector3 direction = fan.transform.rotation * new Vector3(0, 1, 1);
            transform.position += Time.deltaTime * 1 * direction;
        }
	}
}