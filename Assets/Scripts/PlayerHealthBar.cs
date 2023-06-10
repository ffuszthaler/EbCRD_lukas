using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] public GameStats gameStats;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = gameStats.PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(gameStats.PlayerHealth / maxHealth, 1, 1);
    }
}