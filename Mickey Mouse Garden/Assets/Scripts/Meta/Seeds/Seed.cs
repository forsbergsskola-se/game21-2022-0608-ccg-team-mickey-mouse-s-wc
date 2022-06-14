using Meta.Enums;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Seeds {
    public abstract class Seed : MonoBehaviour, IInventoryItem {
        [SerializeField] private Sprite inventorySprite;
        
        public Sprite InventorySprite {
            get => inventorySprite;
            set => inventorySprite = value;
        }

        public SeedQuality SeedQuality;

        public float GrowthTime {
            get;
            private set;
        }

        private void SetGrowthTime() {
            //TODO: Implement based on seedQuality
            switch (SeedQuality) {
                //Return different times
            }
        }
        public virtual void OnReceived() {
            
        }
    }
}