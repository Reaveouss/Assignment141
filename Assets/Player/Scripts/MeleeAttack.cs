using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    Transform cameraTransform;
    float range = 1f;
    LayerMask layermask;
    [SerializeField] float rawDamage = 10f;
    void Start()
    {
        layermask = ~LayerMask.GetMask(LayerMask.LayerToName(gameObject.layer));
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
    }
}
