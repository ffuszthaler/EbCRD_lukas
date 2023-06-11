using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TMP_Text playerScore;

    public void RestartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore.text = "Score: " + GameStats.instance.PlayerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}