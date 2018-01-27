﻿using System.Collections;
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

        if (inFan)
        {
            float distance = Vector2.Distance(transform.position, fan.transform.position);
            float magnitude = Mathf.Max(3, 10 - distance) / 6;

            Ray2D ray = new Ray2D(fan.transform.position, fan.transform.rotation * new Vector2(0, 1));
            float centerDistance = Vector3.Cross(ray.direction, new Vector2(transform.position.x, transform.position.y) - ray.origin).magnitude;

            magnitude = Mathf.Max(0, magnitude - centerDistance * 0.5f);
            Debug.Log(magnitude);

            Vector3 direction = fan.transform.rotation * new Vector3(0, 1, 1);
            Vector3 fromFan = (transform.position - fan.transform.position).normalized;
            transform.position += Time.deltaTime * magnitude * fromFan;

            Quaternion rotation = Quaternion.LookRotation(fromFan);
            rotation.x = 0;
            rotation.y = 0;
            transform.rotation = rotation;
        }
	}
}