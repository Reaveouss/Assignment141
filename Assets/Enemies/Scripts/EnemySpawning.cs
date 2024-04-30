using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    [SerializeField] GameObject Enemy3;
    [SerializeField] float delayTimer = 3f;
    float tick;
    public int spawnRadius = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(5);
    }

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;
        if (tick > delayTimer)
        {
            tick = tick - delayTimer;
            SpawnEnemy(1);
        }
    }
    void SpawnEnemy(int amount)
    {
        while (amount != 0)
        {
            Vector3 randomPos = Random.insideUnitSphere * spawnRadius;
            Vector3 spawnPos = new Vector3(randomPos.x, 0, randomPos.y);
            int EnemySelect = Random.Range(0, 3) + 1;
            if (EnemySelect == 1)
            {
                Instantiate(Enemy1, transform);
                Enemy1.transform.position = spawnPos;
            }
            if (EnemySelect == 2)
            {
                Instantiate(Enemy2, transform);
                Enemy2.transform.position = spawnPos;
            }
            if (EnemySelect == 3)
            {
                Instantiate(Enemy3, transform);
                Enemy3.transform.position = spawnPos;
            }
            amount--;
        }
    }
}
