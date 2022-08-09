using System.Linq;
using Meta.Cards;
using UnityEngine;
using Meta.Inventory.FighterInventory;
using Random = UnityEngine.Random;

namespace Meta.Inventory {
    public class CardSpawner : MonoBehaviour {
        public CardLibraryConfig cardLibrary;

        private void Awake() {
            Broker.Subscribe<SpawnCardFromSeed>(CollectRandomCard);
        }
        
        private void CollectRandomCard(SpawnCardFromSeed spawnCardFromSeed) {
            //TODO: Based on seed Rarity, random chance to spawn card of Rarity x
            //Method that does calculation and returns a card should be here
            var randomInt = Random.Range(0, cardLibrary.cards.Length);
            var libraryCardConfig = cardLibrary.cards[randomInt];
            
            var card = new Card(libraryCardConfig.Id);

            card.ID = new StringGUID().NewGuid();
            card.MaxHealth = libraryCardConfig.MaxHealth;
            card.Attack = libraryCardConfig.Attack;
            card.Speed = libraryCardConfig.Speed;
            card.Level = libraryCardConfig.Level; 
            card.Rarity = libraryCardConfig.Rarity;
            card.Name = libraryCardConfig.Name;
            card.Alignment = libraryCardConfig.Alignment;
            card.SpriteIndex = libraryCardConfig.spriteIndex;
            ;
            var cardCollectedMessage = new AddItemToInventoryMessage<Card>(card,1);

            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);
        }
    }
}