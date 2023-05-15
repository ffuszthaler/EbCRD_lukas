using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    void OnShoot(InputValue inputValue)
    {
        var currentBullet = Instantiate(bullet, Camera.main.transform.position, Quaternion.identity);
        currentBullet.transform.LookAt(Camera.main.transform.position + Camera.main.transform.forward);
        currentBullet.transform.Translate(new Vector3(0, 0, 1) *
                                          Vector3.Distance(Camera.main.transform.position, transform.position));
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