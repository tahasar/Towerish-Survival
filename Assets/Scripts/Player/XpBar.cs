using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class XpBar : MonoBehaviour
    {
        public Slider slider;
        public Image fill;
        public Image border;
        public TextMeshProUGUI xpText;
        public TextMeshProUGUI levelText;
        private Color _oldBorderColor;

        private Color _oldFillColor;

        private void Start()
        {
            _oldFillColor = fill.color;
            _oldBorderColor = border.color;
            UpdateLevelText(1);
        }

        public void UpdateXpText(float currentXp, float target)
        {
            slider.maxValue = target;
            slider.value = currentXp;
            fill.color = Color.white;
            StartCoroutine(XpGain());
            StopCoroutine(XpGain());
            double xpPercentage = 100 / target * currentXp;
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

        private IEnumerator XpGain()
        {
            yield return new WaitForSeconds(0.05f);
            fill.color = _oldFillColor;
        }

        private IEnumerator LevelGain()
        {
            yield return new WaitForSeconds(0.1f);
            border.color = _oldBorderColor;
        }
    }
}