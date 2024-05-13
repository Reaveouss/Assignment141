using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonUpgrade : MonoBehaviour
{
    public Upgrade Upgrade;
    public TMP_Text title;
    public TMP_Text description;

    public void Awake()
    {
        title.text = Upgrade.UpgradeName;
        description.text = Upgrade.UpgradeDescription;
    }
}
