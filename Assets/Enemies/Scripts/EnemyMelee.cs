using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMelee : MonoBehaviour
{
    [SerializeField] 
    Transform destination;
    NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent != null)
        {
            SetDestination();
        }
    }
    void SetDestination()
    {
        
    }
}
