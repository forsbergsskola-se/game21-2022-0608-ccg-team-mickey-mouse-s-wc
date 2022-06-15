using System;
using Meta.Interfaces;
using Meta.Inventory;
using UnityEngine;

namespace Meta.Seeds {
    public abstract class Seed : MonoBehaviour, IInventoryItem {
        [SerializeField] private Sprite inventorySprite;         //TODO: Hardcode inventory sprite based on rarity
        public Rarity rarity;
        private float growthTime;
        
        public float GrowthTime {
            get => growthTime;
            set {
                growthTime = value;
                growthTime = SetGrowthTime();
            }
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
                Rarity.Common => 2,
                Rarity.Rare => 3,
                Rarity.Epic => 4,
                Rarity.Legendary => 5,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}