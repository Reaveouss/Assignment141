using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public GameObject Player;
    Rigidbody Rigidbody;
    [SerializeField] Animator animator;
    [SerializeField] bool Melee = false;
    [SerializeField] bool Ranged = false;
    [SerializeField] bool Thief = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetDestination(other.transform);
        }
    }


    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        Player = GameObject.FindWithTag("Player");
        navMeshAgent = this.GetComponentInParent<NavMeshAgent>();
        if (this.CompareTag("Melee"))
        {
            Melee = true;
        }
        if (this.CompareTag("Ranged"))
        {
            Ranged = true;
        }
        if (this.CompareTag("Thief"))
        {
            Thief = true;
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
        if(Melee)
        {
            MeleeMovement();
        }
        if (Ranged)
        {
            RangedMovement();
        }
        if (Thief)
        {
            ThiefMovement();
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
    void MeleeMovement()
    {
        Player = GameObject.FindWithTag("Player");
        if(Vector3.Distance(transform.position, Player.transform.position) >= 3)
        {
            SetDestination(Player.transform);
        }
    }
    void RangedMovement()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) >= 6)
        {
            SetDestination(Player.transform);
        }
        else
        {
            navMeshAgent.ResetPath();
        }
    }
    void ThiefMovement()
    {
        EnemyHealth healthScript = this.GetComponent<EnemyHealth>();
        float HitPoints = healthScript.HitPoints;
        float MaxHitPoints = healthScript.MaxHealth;
        if (HitPoints < MaxHitPoints/4)
        {
            GameObject EnemyStall = GameObject.FindWithTag("EnemyStand");
        }
        else
        {
            int Stall = Random.Range(0, 4);
            if(Stall == 1)
            {
                GameObject stall1 = GameObject.FindWithTag("Stand1");
                if(Vector3.Distance(transform.position, stall1.transform.position) > 2)
                {
                    SetDestination(stall1.transform);
                }
            }
            else if(Stall == 2)
            {
                GameObject stall2 = GameObject.FindWithTag("Stand2");
                if (Vector3.Distance(transform.position, stall2.transform.position) > 2)
                {
                    SetDestination(stall2.transform);
                }
            }
            else if (Stall == 3)
            {
                GameObject stall3 = GameObject.FindWithTag("Stand3");
                if (Vector3.Distance(transform.position, stall3.transform.position) > 2)
                {
                    SetDestination(stall3.transform);
                }
            }
            else if (Stall == 4)
            {
                GameObject stall4 = GameObject.FindWithTag("Stand4");
                if (Vector3.Distance(transform.position, stall4.transform.position) > 2)
                {
                    SetDestination(stall4.transform);
                }
            }
        }
    }
}
