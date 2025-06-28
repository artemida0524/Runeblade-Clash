using Game.Core.ResourceItem.Item;

namespace Game.Core.ResourceItem.InventoryItem
{
    public class InventoryItemData : ItemData, IInventoryItemData
    {
        public int Amount { get; protected set; }
        public InventoryItemType InventoryItemType { get; protected set; }

        public InventoryItemData(string name, InventoryItemType type, int amount) : base(name, ItemType.Inventory)
        {
            Amount = amount;
            InventoryItemType = type;
        }
    }



}
