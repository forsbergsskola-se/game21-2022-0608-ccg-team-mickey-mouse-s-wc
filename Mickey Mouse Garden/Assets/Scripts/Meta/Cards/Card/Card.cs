using System.Threading.Tasks;
using Meta.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Meta.Inventory.FighterInventory {
    /// <summary>
    /// The serialized data model of a card.
    /// </summary>
    [System.Serializable]
    public class Card : IInventoryItem {
        public string libraryID{ get; set; }
        [SerializeField] private short level;

        public short Level {
            get => level;
            set => level = value;
        }
        
       public string Name{ get; set; }
        public float Attack{ get; set; }
        public float MaxHealth{ get; set; }
        public float Speed{ get; set; }
        public Alignment Alignment{ get; set; }
        public short SpriteIndex{ get; set; }
        public Rarity Rarity{ get; set; }

        public Card(string _libraryID){
            libraryID = _libraryID;
        }
        
        public StringGUID ID { get; set; }
        public async void TryLoadData(){
            var loadedCard = await SaveManager.Load<Card>(ID);
            if (loadedCard == null){
                return;
            }
            Name = loadedCard.Name;
            Alignment = loadedCard.Alignment;
            SpriteIndex = loadedCard.SpriteIndex;
            Rarity = loadedCard.Rarity;
            Level = loadedCard.Level;
            Attack = loadedCard.Attack;
            MaxHealth = loadedCard.MaxHealth;
            Speed = loadedCard.Speed;
        }
        public void Save() {
            SaveManager.Save(this);
        }
        
    }
}