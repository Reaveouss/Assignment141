using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "RangeUp", menuName = "Upgrades/RangeUp")]
public class RangeUp : Upgrade
{
    public override void ActivateEffet(GameObject player)
    {
        MeleeAttack Range = player.GetComponent<MeleeAttack>();
        Range.range += 1f;
        base.ActivateEffet(player);
    }
}
