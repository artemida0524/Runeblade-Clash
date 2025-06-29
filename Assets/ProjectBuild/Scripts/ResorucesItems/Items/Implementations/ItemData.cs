namespace Game.Core.ResourceItem.Item
{
    public class ItemData : IItemData
    {
        public string Name { get; protected set; }

        public ItemData(string name)
        {
            Name = name;
        }
    }
}