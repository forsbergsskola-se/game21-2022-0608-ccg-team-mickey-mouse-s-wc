using UnityEngine;

namespace Meta.Interfaces {
    public interface IInventoryItem {
        public Sprite InventorySprite { get; set; }
        public void OnReceived();
    }
}