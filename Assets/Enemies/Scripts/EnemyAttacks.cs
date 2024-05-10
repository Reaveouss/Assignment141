using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttacks : MonoBehaviour
{
    public GameObject Player;
    Rigidbody Rigidbody;
    [SerializeField] Animator animator;
    [SerializeField] bool Melee = false;
    [SerializeField] bool Ranged = false;
    [SerializeField] bool Thief = false;
    [SerializeField] float rawDamage = 1f;
    float MeleeDistance = 1f;
    float RangedDistance = 6f;
    LayerMask layermask;
    void Start()
    {
        layermask = ~LayerMask.GetMask(LayerMask.LayerToName(gameObject.layer));
        animator = GetComponentInParent<Animator>();
        Player = GameObject.FindWithTag("Player");
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
    void Update()
    {
        if (Melee)
        {
            MeleeAttacking();
        }
        if (Ranged)
        {
            RangedAttacking();
        }
        if (Thief)
        {
            ThiefStealing();
        }
    }
    void MeleeAttacking()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= 3.5f)
        {
            animator.SetBool("Attacking", true);
            Ray ray = new Ray(transform.position, Player.transform.position - transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3.5f, layermask))
            {
                if (hit.transform != null)
                {
                    hit.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Melee Raycasted");
                }
            }
        }
        else
        {
            animator.SetBool("Attacking", false);
        }
    }
    void RangedAttacking()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) >= 5f)
        {
            Debug.Log("Working");
            animator.SetBool("Attacking", true);
            Ray ray = new Ray(transform.position, Player.transform.position - transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 7f, layermask))
            {
                if (hit.transform != null)
                {
                    hit.collider.SendMessageUpwards("Hit", rawDamage/2, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Ranged Raycasted");
                }
            }
        }
        else
        {
            Debug.Log("Else");
            animator.SetBool("Attacking", false);
        }
    }
    void ThiefStealing()
    {

    }
}
