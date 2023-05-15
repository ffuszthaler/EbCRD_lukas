using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] public float speed = 1;

    IEnumerator Fly()
    {
        yield return new WaitForEndOfFrame();

        while (true)
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemyStats = other.GetComponentInParent<EnemyStats>();
            enemyStats.ReduceHealth(2f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fly());
    }

    // Update is called once per frame
    void Update()
    {
    }
}