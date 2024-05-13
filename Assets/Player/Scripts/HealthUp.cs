using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthUp", menuName ="Upgrades/HealthUp")]
public class HealthUp : Upgrade
{
    public override void ActivateEffet(GameObject player)
    {
        PlayerHealth playerhealth = player.GetComponent<PlayerHealth>();
        playerhealth.MaxHitPoints += 250f;
        playerhealth.Health += 250f;
        base.ActivateEffet(player);
    }
}
