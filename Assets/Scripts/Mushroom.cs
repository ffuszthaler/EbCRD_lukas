using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    private MeshCollider meshCollider;
    
    // turn mushroom into prefab
    private void OnCollisionEnter(Collision collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            GameStats.instance.LooseHealth(5);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
