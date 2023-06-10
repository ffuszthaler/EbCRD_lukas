using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
    // [SerializeField] private float PlayerScore = 0f;
    [field: SerializeField] public float PlayerScore { private set; get; }

    // [SerializeField] private float PlayerHealth = 100f;
    [field: SerializeField] public float PlayerHealth { private set; get; }

    public static GameStats instance;

    public void IncreaseScore(float value)
    {
        PlayerScore += value;
        Debug.Log("Score: " + PlayerScore);

        if (PlayerScore == 5.0f)
        {
            AkSoundEngine.PostEvent("Play_finished", gameObject);
            AkSoundEngine.SetState("music", "won");
        }

        if (PlayerScore == 6.0f)
        {
            SceneManager.LoadScene("GameWon");
        }
    }

    public void LooseHealth(float value)
    {
        PlayerHealth -= value;

        AkSoundEngine.SetRTPCValue("PlayerHealth", PlayerHealth);
        AkSoundEngine.PostEvent("Play_Player_Damage", gameObject);

        Debug.Log("Health: " + PlayerHealth);

        if (PlayerHealth == 0.0f)
        {
            AkSoundEngine.PostEvent("Play_gameover", gameObject);
            AkSoundEngine.SetState("music", "gameover");

            SceneManager.LoadScene("GameOver");
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