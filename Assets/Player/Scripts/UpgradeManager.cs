using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject Leveling;
    public List<Upgrade> Upgrades = new List<Upgrade>();
    public void ChooseUpgrade(ButtonUpgrade buttonupgrade)
    {
        Upgrade upgrade = buttonupgrade.Upgrade;
        Upgrades.Add(upgrade);
        upgrade.ActivateEffet(this.gameObject);
        Leveling.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
