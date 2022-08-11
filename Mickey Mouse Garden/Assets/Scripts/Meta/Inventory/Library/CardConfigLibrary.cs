using System.Collections.Generic;
using Meta.Cards;
using UnityEngine;

namespace Meta.Inventory.Library{
    [CreateAssetMenu(fileName = "New Card Library", menuName = "Library/Cards")]
    public class CardConfigLibrary: ConfigLibrary<CardConfig>{
        public override List<CardConfig> itemConfigs{ get; set; }
    }
}