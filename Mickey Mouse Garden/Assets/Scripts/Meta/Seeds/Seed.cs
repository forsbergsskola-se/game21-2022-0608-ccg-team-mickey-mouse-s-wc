using System;
using Meta.Enums;
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
        
        //TODO: Method for being picked up/harvested
        // Destroy game object
        //Invoke subscribers

        private void OnMouseDown() {
            var collectedMessage = new ItemCollectedMessage<Seed>(this);
            Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage);
            Destroy(gameObject);
        }


        //TODO: Implement things below when more info has been given by the designers
        /*
        public SeedQuality SeedQuality;
        [SerializeField] private float growthTime;

        public float GrowthTime {
            get => growthTime;
            set {
                growthTime = value;
                growthTime = SetGrowthTime();
            }
        }

        private float SetGrowthTime() {
            //TODO: Implement based on seedQuality
            switch (SeedQuality) {
                //Return different times
            }

            return 1;
        }*/
    }
}