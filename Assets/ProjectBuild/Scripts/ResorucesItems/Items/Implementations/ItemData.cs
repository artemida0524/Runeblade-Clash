namespace Game.Core.ResourceItem.Item
{
    public class ItemData : IItemData
    {
        public string Name { get; protected set; }
        public ItemType ItemType { get; protected set; }

        public ItemData(string name, ItemType type)
        {
            Name = name;
            ItemType = type;
        }
    }
}