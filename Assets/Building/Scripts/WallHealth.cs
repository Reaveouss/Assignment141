using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    [SerializeField] float maxWallHealth = 150;
    [SerializeField] float wallHealth;
    [SerializeField] GameObject brokenWall;
    [SerializeField] GameObject Wall;
    // Start is called before the first frame update
    void Start()
    {
        wallHealth = maxWallHealth;
        Wall = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (wallHealth <= 0)
        {
            GameObject.Instantiate(brokenWall, this.transform.position, this.transform.rotation, this.transform.parent);
            Debug.Log("Instance");
            GameObject.Destroy(Wall);
        }
    }
    public void Hit(float rawDamage)
    {
        wallHealth -= rawDamage;
        if (wallHealth <= 0)
        {
            GameObject.Instantiate(brokenWall, this.transform.position, this.transform.rotation);
            Debug.Log("wrong one");
            GameObject.Destroy(Wall);
        }
    }
}
