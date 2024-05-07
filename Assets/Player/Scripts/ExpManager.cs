using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpManager : MonoBehaviour
{
    [SerializeField] float ExpMultiplier = 1.2f;
    public float Exp = 0f;
    public float ExpMax = 100;
    public Slider ExpSlider;
    void Start()
    {
        SetExpSlider();
    }
    void Update()
    {
        
    }
    void ExpAdded(float rawExp)
    {
        Exp += rawExp;
        SetExpSlider();
        if(Exp >= ExpMax)
        {
            Exp = 0f;
            ExpMax = ExpMax * ExpMultiplier;
            SetExpSlider();
        }
    }
    private void SetExpSlider()
    {
        if(ExpSlider != null )
        {
            ExpSlider.value = NormalisedExp();
        }
    }
    float NormalisedExp()
    {
        return Exp / ExpMax;
    }
}
