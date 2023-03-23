using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InventorySystem.UI
{
    public class UI_inventory : MonoBehaviour
    {
        [SerializeField] private GameObject _inventortSlotPrefab;

        [SerializeField] private Inventory _inventory;

        [SerializeField] private List<UI_InventorySlot> _slots;

        public Inventory Inventory => _inventory;

        [ContextMenu("Initilize Inventory")]
        private void InitializeInventoryUi()
        {
            if (_inventory == null || _inventortSlotPrefab ==null) return;

            _slots = new List<UI_InventorySlot>(_inventory.Size);

            for (var i = 0; i < _inventory.Size; i++)
            {
                var uiSlot = PrefabUtility.InstantiatePrefab(_inventortSlotPrefab) as GameObject;
                uiSlot.transform.SetParent(transform,false);
                var uiSlotScript = uiSlot.GetComponent<UI_InventorySlot>();
                uiSlotScript.AssignSlot(i);
                _slots.Add(uiSlotScript);
            }
        }
    }
}
