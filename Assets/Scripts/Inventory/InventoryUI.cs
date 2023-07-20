using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryHolder;
    public Transform itemsParent;

    private Inventory inventory;

    private InventorySlot[] slots;

    // Start is called before the first frame update
    private void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryHolder.activeSelf)
                inventoryHolder.SetActive(false);
            else
                inventoryHolder.SetActive(true);
        }
    }

    private void UpdateUI()
    {
        for (var i = 0; i < slots.Length; i++)
            if (i < inventory.items.Count)
                slots[i].AddItem(inventory.items[i]);
            else
                slots[i].ClearSlot();
    }
}