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
            //TODO: Based on seed rarity, random chance to spawn card of rarity x
            //Method that does calculation and returns a card should be here
            
            var card = new Card {
                cardId = cardLibrary.cards[Random.Range(0, cardLibrary.cards.Length)].id
            };
            
            var cardCollectedMessage = new AddItemToInventoryMessage<Card>(card, 1);
            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);
        }
    }
}