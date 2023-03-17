using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Image border;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI levelText;
    
    private Color oldFillColor;
    private Color oldBorderColor;

    private void Start()
    {
        oldFillColor = fill.color;
        oldBorderColor = border.color;
        UpdateLevelText(1);
    }

    public void UpdateXpText(float currentXp, float target)
    {
        slider.maxValue = target;
        slider.value = currentXp;
        fill.color = Color.white;
        StartCoroutine(XpGain());
        StopCoroutine(XpGain());
        double xpPercentage = (100 / target) * currentXp;
        xpPercentage = Math.Round(xpPercentage, 1);
        xpText.SetText($"%{xpPercentage}");
    }
    
    public void UpdateLevelText(float level)
    {
        border.color = Color.yellow;
        StartCoroutine(LevelGain());
        StopCoroutine(LevelGain());
        levelText.SetText($"{level}");
    }
    
    IEnumerator XpGain()
    {
        yield return new WaitForSeconds(0.05f);
        fill.color = oldFillColor;
    }

    IEnumerator LevelGain()
    {
        yield return new WaitForSeconds(0.1f);
        border.color = oldBorderColor;
    }
}
