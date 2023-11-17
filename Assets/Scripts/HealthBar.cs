using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slide;

    public void SetMaxHealth(int health)
    {
        slide.maxValue = health;
        slide.value = health;
    }

    public void SetHealth(int health)
    {
        slide.value = health;
    }
}
