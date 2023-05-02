using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField]
    private float playerScore = 100f;

    public static GameStats instance;
    
    public void IncreaseScore(float value)
    {
        playerScore += value;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}