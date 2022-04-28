using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMana(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetMana(float health)
    {
        slider.value = health;
    }
}
