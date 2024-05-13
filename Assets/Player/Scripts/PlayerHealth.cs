using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public float MaxHitPoints = 1000f;
    public Slider healthSlider;
    [SerializeField] GameObject Death;
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
        SetHealthSlider();
        if(Health < 0)
        {
            OnDeath();
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
    private void OnDeath()
    {
        Time.timeScale = 0f;
        Death.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
