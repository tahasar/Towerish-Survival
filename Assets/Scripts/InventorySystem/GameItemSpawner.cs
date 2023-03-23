using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace InventorySystem
{
    public class GameItemSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _itemBasePrefab;
        [SerializeField] private GameObject characterSpriteObject;

        public void SpawnItem(ItemStack itemStack)
        {
            if(_itemBasePrefab == null) return;
            GameObject item = Instantiate(_itemBasePrefab);
            item.transform.position = transform.position;
            var gameItemScript = item.GetComponent<GameItem>();
            gameItemScript.SetStack(new ItemStack(itemStack.Item, itemStack.NumberOfItems));
            gameItemScript.Throw(characterSpriteObject.transform.localScale.x);
        }
    }
}
