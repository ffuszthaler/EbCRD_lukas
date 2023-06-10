using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreText : MonoBehaviour
{
    [SerializeField] public GameStats gameStats;

    public TMP_Text playerScore;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerScore.text = gameStats.PlayerScore.ToString();
    }
}