using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public bool isSick = true;
    public bool isMain = false;
    public GameObject myFan;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Ship ship = other.gameObject.GetComponent<Ship>();

        if (isSick)
        {
            Debug.Log(other);

            if (ship.IsFriendly)
            {
                Virus[] viruses = GetComponentsInChildren<Virus>();

                for (int i = 0; i < System.Math.Min(viruses.Length, 3); ++i)
                {
                    Destroy(viruses[i].gameObject);
                }

                Destroy(other.gameObject);

                if (viruses.Length <= 3)
                {
                    isSick = false;
                    GameState gameState = GameObject.Find("GameState").GetComponent<GameState>();
                    GameObject fan = (GameObject)Instantiate(gameState.FanPrefab, transform.position, transform.rotation);
                    myFan = fan;

                    foreach (VirusSpawner spawner in gameObject.GetComponents<VirusSpawner>())
                    {
                        spawner.enabled = false;
                    }

                    GetComponentInChildren<ShipSpawner>().IsFriendly = true;
                    GetComponentInChildren<ShipSpawner>().EnableSpawn = false;
                }
            }
            else
            {
                Destroy(other.gameObject);
                VirusSpawner spawner = GetComponentInChildren<VirusSpawner>();

                if(ship.Spawner != GetComponentInChildren<ShipSpawner>())
                {
                    spawner.Spawn();
                }
            }
        }
        else
        {
            Destroy(other.gameObject);

            if (ship && !ship.IsFriendly)
            {
                GameState gameState = GameObject.Find("GameState").GetComponent<GameState>();

                if (isMain)
                {
                    --gameState.Health;

                    if (gameState.Health <= 0)
                    {
                        Application.LoadLevel("GameOverScreen");
                    }
                }
                else
                {
                    isSick = true;
                    Fan fan = myFan.GetComponent<Fan>();

                    foreach (VirusSpawner spawner in gameObject.GetComponents<VirusSpawner>())
                    {
                        spawner.enabled = true;
                    }

                    GetComponentInChildren<ShipSpawner>().IsFriendly = false;
                    GetComponentInChildren<ShipSpawner>().EnableSpawn = true;

                    if (gameState.currentFan == fan)
                    {
                        int idx = (gameState.fanlist.IndexOf(gameState.currentFan) + 1) % gameState.fanlist.Count;
                        gameState.currentFan = gameState.fanlist[idx];
                        gameState.currentFan.isActive = true;
                    }

                    gameState.fanlist.Remove(fan);

                    Destroy(fan.gameObject);
                    GetComponentInChildren<VirusSpawner>().Spawn();
                }
            }
        }
    }
}