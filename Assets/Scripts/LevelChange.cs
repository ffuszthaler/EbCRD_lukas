using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private string level;

    private int openedDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AkSoundEngine.StopAll();
            SceneManager.LoadSceneAsync(level);

            AkSoundEngine.PostEvent("Play_Doors", other.gameObject);

            if (SceneManager.GetActiveScene().name == "Level02")
            {
                AkSoundEngine.SetSwitch("scenes", "indoors", gameObject);
            }
            else
            {
                AkSoundEngine.SetSwitch("scenes", "outdoors", gameObject);
            }
        }
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