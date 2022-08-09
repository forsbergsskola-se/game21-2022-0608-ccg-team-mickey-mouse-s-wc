using System;
using Meta.Interfaces;
using Meta.Inventory;
using UnityEngine;

namespace Meta.Seeds {
    public abstract class Seed : MonoBehaviour, IInventoryItem {
        public Rarity rarity;
        public string libraryID{ get; set; }
        public float GrowthTime { get; private set; }
        
        [SerializeField] private Sprite inventorySprite;         //TODO: Hardcode inventory sprite based on Rarity
        
        
        private void Start() {
            GrowthTime = SetGrowthTime();
        }

        public Sprite InventorySprite {
            get => inventorySprite;
            set => inventorySprite = value;
        }

        //Currently made for the test spheres in the game, this method can be changed, and should be switched from OnMouseDown (unity event function) to something else
        private void OnMouseDown() {
            var collectedMessage = new AddItemToInventoryMessage<Seed>(this,1); //<--- Needed
            Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage); //<--- Needed
            Destroy(gameObject); //<--- Not needed
        }
        
        private float SetGrowthTime() {
            return rarity switch {             //TODO: Check exact values with designers
                Rarity.Common => 6,
                Rarity.Rare => 8,
                Rarity.Epic => 12,
                Rarity.Legendary => 15,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
    }
}