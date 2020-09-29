using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyStatus : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image EnergyFill;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        EnergyFill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        EnergyFill.color = gradient.Evaluate(slider.normalizedValue);
    }



}
