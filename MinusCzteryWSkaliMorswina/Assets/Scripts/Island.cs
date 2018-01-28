using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public bool isSick = true;

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
        if (isSick)
        {
            Debug.Log(other);
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

                foreach (VirusSpawner spawner in gameObject.GetComponents<VirusSpawner>())
                {
                    spawner.enabled = false;
                }

                GetComponentInChildren<ShipSpawner>().IsFriendly = true;
            }
        }
        else
        {
            GameState gameState = GameObject.Find("GameState").GetComponent<GameState>();
            Destroy(other.gameObject);
            --gameState.Health;

            if(gameState.Health <= 0)
            {
                Application.LoadLevel("GameOverScreen");
            }
        }
    }
}