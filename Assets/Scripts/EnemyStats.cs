using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [field: SerializeField] public float enemyHealth { private set; get; }

    public void ReduceHealth(float amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log("Enemy Health: " + enemyHealth);
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