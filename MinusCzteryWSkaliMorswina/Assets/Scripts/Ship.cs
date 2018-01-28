using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public bool IsFriendly = true;

    private GameState gameState;

    public void MakeUnfriendly()
    {
        IsFriendly = false;
        transform.Find("Ship virus").gameObject.SetActive(true);
    }

	// Use this for initialization
	void Start () {
         gameState = GameObject.Find("GameState").GetComponent<GameState>();

	}
	
	// Update is called once per frame
	void Update () {
        Fan fan = gameState.currentFan;

        if(!IsFriendly)
        {
            Vector3 toFan = (fan.transform.position - transform.position).normalized;
            transform.position += Time.deltaTime * toFan * 0.5f;

            Quaternion rotation = Quaternion.LookRotation(toFan, Vector3.forward);
            rotation.x = 0;
            rotation.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * 128);
            Debug.Log("attack!");
        }

        Collider2D col = fan.gameObject.GetComponent<Collider2D>();

        bool inFan = col.OverlapPoint(new Vector2(transform.position.x, transform.position.y));

        if (inFan)
        {
            float distance = Vector2.Distance(transform.position, fan.transform.position);
            float magnitude = Mathf.Max(3, 10 - distance) / 2;

            Ray2D ray = new Ray2D(fan.transform.position, fan.transform.rotation * new Vector2(0, 1));
            float centerDistance = Vector3.Cross(ray.direction, new Vector2(transform.position.x, transform.position.y) - ray.origin).magnitude;

            magnitude = Mathf.Max(0, magnitude - centerDistance * 0.4f);

            Vector3 direction = fan.transform.rotation * new Vector3(0, 1, 1);
            Vector3 fromFan = (transform.position - fan.transform.position).normalized;
            transform.position += Time.deltaTime * magnitude * fromFan;
			Quaternion rotateSprite = Quaternion.AngleAxis (90, new Vector3 (0, 0, 1));
            Quaternion rotation = Quaternion.LookRotation(rotateSprite * fromFan);

            rotation.x = 0;
            rotation.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * 128);
        }
	}
}