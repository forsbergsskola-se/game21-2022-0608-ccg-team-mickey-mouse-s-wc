using Meta.Inventory.FighterInventory;
using Meta.Inventory.NewSeedInventory;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Cards {
    /// <summary>
    /// Class for designers to configure values for a kind of card.
    /// </summary>
    [CreateAssetMenu]
    public class CardConfig : ItemConfig {
        //TODO: Properties should have capital
        [Tooltip("Only used for to see correct sprite name")]public Sprite Image;
        public short spriteIndex;
        public string Name;
        public float MaxHealth;
        public float Attack;
        public float Speed;
        public Alignment Alignment;
        public Rarity Rarity;
        public short Level;
        public float HealthMultiplier, AttackMultiplier, SpeedMultiplier;
        
        public ConfigLibrary<CardConfig> library;
        
        public short LibraryID{ get; set; }
        
        void OnEnable(){
            TryAddToLibrary();
        }
        public override void SendCreateItemMessage(short libraryID){
            Debug.Log("Invoking Card Create Message" + " " + libraryID);
            var message = new CreateNewInventoryItemMessage<Card>(libraryID);
            Broker.InvokeSubscribers(message.GetType(), message);
        }
        public override void SendRemoveItemMessage(short libraryID){
            Debug.Log("Invoking Card Remove Message" + " " + libraryID);
            var message = new RemoveInventoryItemMessage<Card>(libraryID);
            Broker.InvokeSubscribers(message.GetType(), message);
        }

        public override void TryAddToLibrary(){
            library.AddItemConfigToLibrary(this);
        }
    }
}