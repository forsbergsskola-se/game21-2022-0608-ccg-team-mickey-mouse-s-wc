using System;
using Meta.Interfaces;
using Meta.Inventory;
using UnityEngine;

namespace Meta.Seeds {
    public abstract class Seed : MonoBehaviour, IInventoryItem {
        [SerializeField] private Sprite inventorySprite;

        public Sprite InventorySprite {
            get => inventorySprite;
            set => inventorySprite = value;
        }

        private void OnMouseDown() {
            var collectedMessage = new ItemCollectedMessage<Seed>(this);
            Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage);
            Destroy(gameObject);
        }
        
        //TODO: Hardcode inventory sprite based on rarity
        
        //TODO: Implement things below when more info has been given by the designers
        /*[SerializeField] private float growthTime;

        public float GrowthTime {
            get => growthTime;
            set {
                growthTime = value;
                growthTime = SetGrowthTime();
            }
        }

        private float SetGrowthTime() {
            switch (SeedQuality) {
                //Return different times
            }
        }*/
    }
}