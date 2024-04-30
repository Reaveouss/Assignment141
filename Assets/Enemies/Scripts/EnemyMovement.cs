using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform destination;
    NavMeshAgent navMeshAgent;
    public GameObject Player;
    Rigidbody Rigidbody;
    [SerializeField] Animator animator;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetDestination(other.transform);
        }
    }


    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        destination = Player.transform;
        navMeshAgent = this.GetComponentInParent<NavMeshAgent>();
        if (navMeshAgent != null)
        {
            SetDestination(destination);
        }
    }
    private void Update()
    {
        if (navMeshAgent.velocity.magnitude >= 0.2)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

    }
    void SetDestination(Transform destination)
    {
        
       if ((destination) != null)
        {
            Vector3 targetVector = (destination).position;
            navMeshAgent.SetDestination(targetVector);
        }
    }
}
