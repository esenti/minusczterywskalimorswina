using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour {

    public GameObject Virus;
    public float SpawnInterval = 5;
    public int MaxViruses = 10;

    private float toSpawn = 1;

    public void Spawn()
    {
            Virus[] viruses = GetComponentsInChildren<Virus>();
            if (viruses.Length >= MaxViruses)
            {
                ShipSpawner shipSpawner = GetComponentInChildren<ShipSpawner>();
                GameObject ship = shipSpawner.Spawn();
                ship.GetComponent<Ship>().MakeUnfriendly();
            }
            else
            {
                PolygonCollider2D col = GetComponent<PolygonCollider2D>();
                Vector2 position = new Vector2();
                bool spawn = false;

                for(int i = 0; i < 1000; ++i)
                {
                    position = Random.insideUnitCircle * 2 + new Vector2(transform.position.x, transform.position.y);
                    bool inSpawnZone = col.OverlapPoint(position);

                    if (inSpawnZone)
                    {
                        spawn = true;
                        break;
                    }
                }

                if (spawn)
                {
                    GameObject virus = (GameObject)Instantiate(Virus, position, transform.rotation, transform);
                    Debug.Log("SPAWNED");
                }
                else
                {
                    Debug.Log("DUPA!");
                }
            }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        toSpawn -= Time.deltaTime;

        if(toSpawn <= 0)
        {
            toSpawn = SpawnInterval;
            Spawn();
        }
		
	}
}
