using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is a learning piece and courtesy of UnityCollege3D : 'Health Bars in Unity3D - Quick...'
/// </summary>

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedInSeconds = 0.5f;

    private void Awake()
    {
        GetComponentInParent<HealthTracker>().OnHealthPercentChanged += HandleHealthUpdate;
    }

    private void HandleHealthUpdate(float percent) // called when the OnHealthPercentChanged
    {
        StartCoroutine(UpdateHealthBar(percent));
    }

    private IEnumerator UpdateHealthBar(float percent)
    {
        float preChangePercent = foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedInSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePercent, percent, elapsed / updateSpeedInSeconds); // take the value to 'percent' over updateSpeedInSeconds time...
            yield return null;
        }

        foregroundImage.fillAmount = percent;
    }

}
