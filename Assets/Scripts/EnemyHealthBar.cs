using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] public EnemyStats enemyStats;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = enemyStats.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(enemyStats.enemyHealth / maxHealth, 1, 1);
    }
}