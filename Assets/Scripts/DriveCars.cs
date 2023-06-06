using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCars : MonoBehaviour
{
    private static readonly float defaultSpeed = 8.0f;
    public float speed = defaultSpeed;

    private bool carAtEnd = false;

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

    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Play_Car", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        RaycastHit raycastHit;

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.magenta);

        bool hasHitObject = Physics.Raycast(ray, out raycastHit, 3000.0f);

        if (hasHitObject)
        {
            if (raycastHit.transform.CompareTag("Player"))
            {
                speed = 15.0f;
            }
            else
            {
                speed = defaultSpeed;
            }
        }
    }
}