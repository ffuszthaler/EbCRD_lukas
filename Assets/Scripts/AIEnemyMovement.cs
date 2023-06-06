using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float radius;

    private void AssignTargetPosition()
    {
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        Vector3 targetPosition = transform.position + randomPosition;

        NavMeshHit navMeshHit;
        if (NavMesh.SamplePosition(targetPosition, out navMeshHit, radius, 1))
        {
            navMeshAgent.SetDestination(targetPosition);
            AkSoundEngine.PostEvent("Play_Enemy_Grunts", gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.velocity == new Vector3(0, 0, 0))
        {
            AssignTargetPosition();
        }

        transform.position = navMeshAgent.nextPosition;
    }
}