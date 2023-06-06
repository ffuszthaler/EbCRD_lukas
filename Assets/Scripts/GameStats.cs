using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField] private float playerScore = 0f;
    [SerializeField] private float playerHealth = 100f;

    public static GameStats instance;

    public void IncreaseScore(float value)
    {
        playerScore += value;
        Debug.Log("Score: " + playerScore);

        if (playerScore == 5.0f)
        {
            AkSoundEngine.PostEvent("Play_finished", gameObject);
            AkSoundEngine.SetState("music", "won");
        }
    }

    public void LooseHealth(float value)
    {
        playerHealth -= value;

        AkSoundEngine.SetRTPCValue("playerHealth", playerHealth);
        AkSoundEngine.PostEvent("Play_Player_Damage", gameObject);

        Debug.Log("Health: " + playerHealth);

        if (playerHealth == 0.0f)
        {
            AkSoundEngine.PostEvent("Play_gameover", gameObject);
            AkSoundEngine.SetState("music", "gameover");
        }
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