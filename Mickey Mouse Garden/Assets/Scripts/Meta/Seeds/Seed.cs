using System;
using Meta.Interfaces;
using Meta.Inventory;
using UnityEngine;

namespace Meta.Seeds {
    public abstract class Seed : MonoBehaviour, IInventoryItem {
        public Rarity rarity;
        public float GrowthTime { get; private set; }
        
        [SerializeField] private Sprite inventorySprite;         //TODO: Hardcode inventory sprite based on rarity
        
        
        private void Start() {
            GrowthTime = SetGrowthTime();
        }

        public Sprite InventorySprite {
            get => inventorySprite;
            set => inventorySprite = value;
        }

        private void OnMouseDown() {
            var collectedMessage = new ItemCollectedMessage<Seed>(this);
            Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage);
            Destroy(gameObject);
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