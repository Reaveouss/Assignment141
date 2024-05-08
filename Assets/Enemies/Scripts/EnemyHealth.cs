using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HitPoints;
    public float MaxHealth = 10f;
    [SerializeField] GameObject EXP;
    Vector3 expSpawn;
    void Start()
    {
        HitPoints = Random.Range(MaxHealth / 2, MaxHealth);
    }
    void Update()
    {
        
    }
    void Mordor(float rawDamage)
    {
        HitPoints -= rawDamage;
        Debug.Log("EnemyHit");
        if(HitPoints <= 0)
        {
            OnDeath();
        }
    }
    private void OnDeath()
    {
        Instantiate(EXP);
        expSpawn = transform.position;
        EXP.transform.position = expSpawn;
        Destroy(this.gameObject);
    }
}
