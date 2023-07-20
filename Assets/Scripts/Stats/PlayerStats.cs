public class PlayerStats : CharacterStats
{
    private Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;
        Inventory.Instance.onItemChangedCallback += OnItemChanged;
    }

    public void OnItemChanged()
    {
        foreach (var item in inventory.items)
        {
            //foreach (float dict in item.stats)
            //{
            //    Debug.Log(dict);
            //}
        }
    }
}