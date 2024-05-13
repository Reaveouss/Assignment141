using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageUp", menuName = "Upgrades/DamageUp")]
public class DamageUp : Upgrade
{
    public override void ActivateEffet(GameObject player)
    {
        MeleeAttack damage = player.GetComponent<MeleeAttack>();
        damage.rawDamage += 5f;
        base.ActivateEffet(player);
    }
}
