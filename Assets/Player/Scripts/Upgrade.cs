using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : ScriptableObject
{
    public string UpgradeName;
    public string UpgradeDescription;

    public virtual void ActivateEffet(GameObject player)
    {
    }

}
