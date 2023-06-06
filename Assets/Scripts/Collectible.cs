using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        bool isPlayer = other.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            AkSoundEngine.PostEvent("Play_Item_Pickups", gameObject);

            Destroy(this.gameObject);

            GameStats.instance.IncreaseScore(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
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