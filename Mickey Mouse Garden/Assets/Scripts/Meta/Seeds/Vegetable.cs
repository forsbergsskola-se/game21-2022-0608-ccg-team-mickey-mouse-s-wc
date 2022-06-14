using Meta.Interfaces;
using Meta.Inventory;
using UnityEngine;

namespace Meta.Seeds {
    public class Vegetable : MonoBehaviour, IInventoryItem{
        public Sprite InventorySprite { get; set; }
        
        private void OnMouseDown() {
            var collectedMessage = new ItemCollectedMessage<Vegetable>(this);
            Broker.InvokeSubscribers(collectedMessage.GetType(), collectedMessage);
            Destroy(gameObject);
        }
    }
}