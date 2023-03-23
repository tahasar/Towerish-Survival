using System;
using System.Collections;
using System.Collections.Generic;
using GameInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem
{
    public class InventoryInputHandler : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = GetComponent<Inventory>();
        }

        private void OnEnable()
        {
            InputActions.Instance.Player.ThrowItem.performed += OnThrowItem;
            InputActions.Instance.Player.NextItem.performed += OnNextItem;
            InputActions.Instance.Player.PreviousItem.performed += OnPreviousItem;
        }

        private void OnDisable()
        {
            InputActions.Instance.Player.ThrowItem.performed -= OnThrowItem;
            InputActions.Instance.Player.NextItem.performed -= OnNextItem;
            InputActions.Instance.Player.PreviousItem.performed -= OnPreviousItem;
        }

        private void OnThrowItem(InputAction.CallbackContext ctx)
        {
            if(_inventory.GetActiveSlot().HasItem)
            {
                _inventory.RemoveItem(_inventory._activeSlotIndex, true);
            }
        }
        
        private void OnNextItem(InputAction.CallbackContext ctx)
        {
            _inventory.ActivateSlot(_inventory._activeSlotIndex + 1);
        }
        
        private void OnPreviousItem(InputAction.CallbackContext ctx)
        {
            _inventory.ActivateSlot(_inventory._activeSlotIndex - 1);
        }
    }
}
