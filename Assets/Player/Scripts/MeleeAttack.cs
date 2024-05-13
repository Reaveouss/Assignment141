using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    Transform cameraTransform;
    public float range = 1f;
    LayerMask layermask;
    public float rawDamage = 5f;
    [SerializeField] Animator animator;
    void Start()
    {
        layermask = ~LayerMask.GetMask(LayerMask.LayerToName(gameObject.layer));
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //if (!MenuController.IsGamePaused)
        //{
            Mordor();
        //}
    }
    void Mordor()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Attacking", true);
            cameraTransform = Camera.main.transform;
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, range, layermask))
            {
                if(hit.transform != null)
                {
                    hit.collider.SendMessageUpwards("Mordor", rawDamage, SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Raycasted");
                }
                else
                {
                    Debug.Log("no raycast");
                }
            }
        }
        animator.SetBool("Attacking", false);
    }
}
