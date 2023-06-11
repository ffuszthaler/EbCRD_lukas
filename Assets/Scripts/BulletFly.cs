using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] public float speed = 1;

    [SerializeField] private DestroyType destroyType;
    [SerializeField] private float destroyValue;

    IEnumerator Fly()
    {
        yield return new WaitForEndOfFrame();

        var timePassed = 0f;
        var startPosition = transform.position;
        bool shouldFly = true;

        while (shouldFly)
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
            timePassed += Time.deltaTime;

            var distanceFromStart = Vector3.Distance(transform.position, startPosition);

            if (destroyType == DestroyType.DistanceBased && distanceFromStart >= destroyValue)
            {
                shouldFly = false;
            }
            else if (destroyType == DestroyType.TimeBased && timePassed >= destroyValue)
            {
                shouldFly = false;
            }

            yield return null;
        }

        Destroy(gameObject);
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