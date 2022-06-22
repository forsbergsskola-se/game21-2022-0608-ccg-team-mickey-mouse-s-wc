using System;
using Meta.Cards;
using UnityEngine;
using Meta.Inventory.FighterInventory;
using Meta.Seeds;
using Random = UnityEngine.Random;

namespace Meta.Inventory {
    public class CardSpawner : MonoBehaviour {
        public CardLibraryValues cardLibrary;

        private void Awake() {
            Broker.Subscribe<SpawnCardFromSeed>(CollectRandomCard);
        }
        
        private void CollectRandomCard(SpawnCardFromSeed spawnCardFromSeed) {
            //TODO: Based on seed rarity, random chance to spawn card of rarity x
            //Method that does calculation and returns a card should be here
            
            var card = new Card {
                cardId = cardLibrary.cards[Random.Range(0, cardLibrary.cards.Length)].id
            };
            
            var cardCollectedMessage = new ItemCollectedMessage<Card>(card);
            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);
        }
    }
}