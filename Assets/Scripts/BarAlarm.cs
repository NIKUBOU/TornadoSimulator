using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarAlarm : MonoBehaviour
{
    public GameManager gameManager;
    public Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        // Hide bar at 0 
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        // Show bar above 0 if hidden
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        // Update the Health bar
        float fillValue = gameManager.alarmValue / gameManager.maxAlarm;
        slider.value = fillValue;
    }
}
