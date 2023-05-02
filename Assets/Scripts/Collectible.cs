using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        bool isPlayer = other.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            Destroy(this.gameObject);

            GameStats.instance.IncreaseScore(3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }
}
