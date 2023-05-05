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
    }

    public void LooseHealth(float value)
    {
        playerHealth -= value;
        Debug.Log("Health: " + playerHealth);
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