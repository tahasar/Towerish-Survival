using UnityEngine;

namespace StatSystem
{
    [CreateAssetMenu(fileName = "StatDefinition", menuName = "StatSystem/StatDefinition", order = 0)]
    public class StatDefinition : ScriptableObject
    {
        [SerializeField] private float m_BaseValue;
        [SerializeField] private float m_Cap = -1;
        public float baseValue => m_BaseValue;
        public float cap => m_Cap;

    }
}