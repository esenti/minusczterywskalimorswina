using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour {

    public Object ShipPrefab;
    public float SpawnInterval = 5;
    public bool IsFriendly = true;

    private float toSpawn = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(!IsFriendly)
        {
            return;
        }

        toSpawn -= Time.deltaTime;

        if(toSpawn <= 0)
        {
            CircleCollider2D[] colliders = FindObjectsOfType<CircleCollider2D>();
            bool spawn = true;

            foreach(CircleCollider2D collider in colliders)
            {
                if(collider.OverlapPoint(transform.position))
                {
                    Debug.Log("Cannot spawn, something is blocking the way!");
                    toSpawn = 0.5f;
                    spawn = false;
                    break;
                }
            }

            if (spawn)
            {
                toSpawn = SpawnInterval;
                Spawn();
            }
        }
	}

    public GameObject Spawn()
    {
        GameObject ship = (GameObject)Instantiate(ShipPrefab, transform.position, transform.rotation);

        return ship;
    }
}
