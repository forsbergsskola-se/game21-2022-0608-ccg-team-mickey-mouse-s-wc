using System.Threading.Tasks;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory.FighterInventory {
    public class Card : IInventoryItem, ISaveData {
        public string Name{ get; set; }
        public Alignment Alignment{ get; set; }
        public string SpriteName{ get; set; }
        public Sprite FighterImage{ get; private set; } //TODO: Sprite or image?
        public Rarity Rarity{ get; set; }
        public short Level{ get; set; }
        public float Attack{ get; set; }
        public float MaxHealth{ get; set; }
        public float Speed{ get; set; }
        
        public StringGUID ID{
            get;
            set;
        }
        
        public Card(StringGUID stringGuid,string name, Alignment alignment, string spriteName, Rarity rarity, short level, float attack, float maxHealth, float speed){
            ID = stringGuid;
            Name = name;
            Alignment = alignment;
            SpriteName = spriteName;
            Rarity = rarity;
            Level = level;
            Attack = attack;
            MaxHealth = maxHealth;
            Speed = speed;
            Save();
        }
        
        public void Save(){
            SaveManager.Save(this);
        }

        public async void TryLoadData(){
            var card = await SaveManager.Load<OwnedCard>(ID);
            //InstanceID = card.InstanceID;
            Name = card.Name;
            Alignment = card.Alignment;
            SpriteName = card.SpriteName;
            FighterImage = Resources.Load<Sprite>($"Art/Sprites/{card.SpriteName}");
            Rarity = card.Rarity;
            Level = card.Level;
            Attack = card.Attack;
            MaxHealth = card.MaxHealth;
            Speed = card.Speed;
            ID = card.ID;
        }
    }
}