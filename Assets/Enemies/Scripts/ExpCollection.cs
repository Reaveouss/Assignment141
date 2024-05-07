using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;

public class ExpCollection : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float rawExp = 5f;
    public GameObject Player;
    Collider collider;
    NavMeshAgent navMeshAgent;
    Transform Destination;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        collider = this.GetComponent<Collider>();
    }
    void Update()
    {
        Destination = Player.transform;
        SetDestination(Destination);
    }
    void SetDestination(Transform destination)
    {
        Vector3 targetVector = Player.transform.position;
        navMeshAgent.SetDestination(targetVector);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.SendMessageUpwards("ExpAdded", rawExp, SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }
    }
}
