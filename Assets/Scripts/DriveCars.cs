using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCars : MonoBehaviour
{
    private static readonly float defaultSpeed = 8.0f;
    public float speed = defaultSpeed;

    private bool carAtEnd = false;

    // private bool playerDamageReceived = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RoadEnd"))
        {
            if (carAtEnd == false)
            {
                var Pivot = transform.Find("PivotPoint").position;
                transform.RotateAround(Pivot, transform.up, 180);
            }

            carAtEnd = true;
        }

        if (other.gameObject.CompareTag("RoadStart"))
        {
            if (carAtEnd == true)
            {
                var Pivot = transform.Find("PivotPoint").position;
                transform.RotateAround(Pivot, transform.up, 180);
            }

            carAtEnd = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            GameStats.instance.LooseHealth(2);
            speed = speed + 2;
        }
    }

    // void carCollision()
    // {
    // RaycastHit raycastHit;
    //
    // Ray ray = new Ray(transform.position, transform.forward);
    // Debug.DrawRay(ray.origin, ray.direction, Color.magenta);
    //
    // bool hasHitObject = Physics.Raycast(ray, out raycastHit, 3000.0f);
    //
    // if (hasHitObject)
    // {
    //     if (raycastHit.transform.CompareTag("Player"))
    //     {
    // GameStats.instance.LooseHealth(5);
    // speed = speed + 2;
    //     }
    //     else
    //     {
    //         // speed = defaultSpeed;
    //     }
    // }
    // }

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Play_Car", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        // RaycastHit raycastHit;
        //
        // Ray ray = new Ray(transform.position, transform.forward);
        // Debug.DrawRay(ray.origin, ray.direction, Color.magenta);
        //
        // bool hasHitObject = Physics.Raycast(ray, out raycastHit, 3000.0f);
        //
        // if (hasHitObject)
        // {
        //     if (raycastHit.transform.CompareTag("Player"))
        //     {
        //         if (playerDamageReceived == false)
        //         {
        //             GameStats.instance.LooseHealth(5);
        //             speed = speed + 2;
        //
        //             playerDamageReceived = true;
        //         }
        //
        //         // carCollision();
        //     }
        //     else
        //     {
        //         // speed = defaultSpeed;
        //     }
        //
        //     playerDamageReceived = false;
        // }
    }
}