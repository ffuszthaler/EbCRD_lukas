using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSoundEvents : MonoBehaviour
{
    public void WalkSoundEvent()
    {
        AkSoundEngine.PostEvent("Play_Player_Walking", gameObject);
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