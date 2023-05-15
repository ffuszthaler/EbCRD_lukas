using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] float currentHealth;

    public void ReduceHealth(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy Health: " + currentHealth);
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