using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StatSystem
{
    public class Stat
    {
        protected StatDefinition m_Definition;
        protected float m_Value;
        public float value => m_Value;
        public virtual float baseValue => m_Definition.baseValue;
        public event Action valueChanged;
        public List<StatModifier> m_Modifiers = new List<StatModifier>();

        public Stat(StatDefinition definition)
        {
            m_Definition = definition;
            CalculateValue();
        }

        public void AddModifier(StatModifier modifier)
        {
            m_Modifiers.Add(modifier);
            CalculateValue();
        }

        public void RemoveModifierFromSource(Object source)
        {
            m_Modifiers = m_Modifiers.Where(m => m.source.GetInstanceID() != source.GetInstanceID()).ToList();
            CalculateValue();
        }

        protected void CalculateValue()
        {
            float newValue = baseValue;
            
            m_Modifiers.Sort((x, y) => x.type.CompareTo(y.type));

            for (int i = 0; i < m_Modifiers.Count; i++)
            {
                StatModifier modifier = m_Modifiers[i];
                if (modifier.type == ModifierOperationType.Additive)
                {
                    newValue += modifier.magnitude;
                }
                else if (modifier.type == ModifierOperationType.Multiplicative)
                {
                    newValue *= modifier.magnitude;
                }
            }
            
            if (m_Definition.cap >= 0)
            {
                newValue = Mathf.Min(newValue, m_Definition.cap);
            }

            if (m_Value != newValue)
            {
                m_Value = newValue;
                valueChanged?.Invoke();
            }
        }
    }
}