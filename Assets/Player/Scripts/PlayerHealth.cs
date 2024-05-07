using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float Health;
    [SerializeField] float MaxHitPoints = 100f;
    public Slider healthSlider;
    void Start()
    {
        Health = MaxHitPoints;
    }
    void Update()
    {
        if(Health > MaxHitPoints)
        {
            Health = MaxHitPoints;
        }
    }
    private void Hit(float rawDamage)
    {
        Health -= rawDamage;
        SetHealthSlider();
    }
    void Heal(float rawHealing)
    {
        Health += rawHealing;
        SetHealthSlider();
    }
    private void SetHealthSlider()
    {
        if(healthSlider != null)
        {
            healthSlider.value = NormalisedHitPoints();
        }
    }
    float NormalisedHitPoints()
    {
        return Health / MaxHitPoints;
    }
    private void OnDestroy()
    {
        
    }
}
