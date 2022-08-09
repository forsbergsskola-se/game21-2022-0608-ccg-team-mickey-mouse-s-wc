using System.Threading.Tasks;
using Meta.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Meta.Inventory.FighterInventory {
    /// <summary>
    /// The serialized data model of a card.
    /// </summary>
    [System.Serializable]
    public class Card : IInventoryItem, ISaveData {
        public string libraryID{ get; set; }
        [SerializeField] private short level;

        public short Level {
            get => level;
            set {
                level = value;
                value = level;
            }
        }
        
       public string Name{ get; set; }
        public float Attack{ get; set; }
        public float MaxHealth{ get; set; }
        public float Speed{ get; set; }
        public Alignment Alignment{ get; set; }
        public string SpriteName{ get; set; }
        // [DoNotSerialize] public Sprite Image{ get; set; } //TODO: Sprite or Image?
        public Rarity Rarity{ get; set; }

        public Card(string _libraryID){
            libraryID = _libraryID;
        }
        public async void TryLoadData(){
            var card = await SaveManager.Load<OwnedCard>(ID);
            Name = card.Name;
            Alignment = card.Alignment;
            SpriteName = card.SpriteName;
            Rarity = card.Rarity;
            Level = card.Level;
            Attack = card.Attack;
            MaxHealth = card.MaxHealth;
            Speed = card.Speed;
        }
        public StringGUID ID { get; set; }

        public void Save() {
            SaveManager.Save(this);
        }
        
    }
}