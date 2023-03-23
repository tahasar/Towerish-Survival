namespace InventorySystem
{
    public class InventorySlotStateChangeArgs
    {
        public ItemStack NewState { get; }
        public bool Active { get; }

        public InventorySlotStateChangeArgs(ItemStack newState, bool active)
        {
            NewState = newState;
            Active = active;
        }
    }
}