using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour {

    public GameObject Virus;
    public float SpawnInterval = 5;
    public int MaxViruses = 10;

    private float toSpawn = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        toSpawn -= Time.deltaTime;

        if(toSpawn <= 0)
        {
            toSpawn = SpawnInterval;
            
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
                Vector2 position;

                while (true)
                {
                    position = Random.insideUnitCircle * 10;
                    bool inSpawnZone = col.OverlapPoint(position);

                    if (inSpawnZone)
                    {
                        break;
                    }
                }
                GameObject virus = (GameObject)Instantiate(Virus, position, transform.rotation, transform);
            }
        }
		
	}
}
