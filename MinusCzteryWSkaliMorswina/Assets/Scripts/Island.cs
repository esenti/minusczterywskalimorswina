using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{

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
        Debug.Log(other);
        Virus[] viruses = GetComponentsInChildren<Virus>();

        for(int i = 0; i < System.Math.Min(viruses.Length, 3); ++i)
        {
            Destroy(viruses[i].gameObject);
        }

        Destroy(other.gameObject);
    }
}