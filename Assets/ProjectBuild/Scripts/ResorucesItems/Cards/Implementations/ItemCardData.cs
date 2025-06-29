using Game.Core.ResourceItem.Item;

namespace Game.Core.ResourceItem.Card
{

    public class ItemCardData : ItemData
    {
        public StarType StarType { get; protected set; }

        public ItemCardData(string name, StarType starType) : base(name)
        {
            StarType = starType;
        }
    } 
}
