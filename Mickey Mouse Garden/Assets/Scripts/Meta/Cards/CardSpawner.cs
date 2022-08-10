using System.Linq;
using Meta.Cards;
using UnityEngine;
using Meta.Inventory.FighterInventory;
using Random = UnityEngine.Random;

namespace Meta.Inventory {
    public class CardSpawner : MonoBehaviour {
        public CardLibraryConfig cardLibrary;
        private bool rarityIncrease;

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
            
            var cardCollectedMessage = new AddItemToInventoryMessage<Card>(card,1);

            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);
        }
        
        // Fusion Below
        private void TryFuseCards(Card card1, Card card2){
            if (CheckForMaxLevel(card1, card2)) {
                SpawnFusedCard(card1, card2);
                // Message Beelzebub to sacrifice both cards.
            }
        }
        
        private static bool CheckForMaxLevel(Card card1, Card card2){
            return (card1.Rarity != Rarity.Legendary && card1.Level != 10) || (card2.Rarity != Rarity.Legendary && card2.Level != 10);
        }

        private void SpawnFusedCard(Card card1, Card card2){
            var fusedCard = new Card(card1.libraryID);
            
            fusedCard.ID = new StringGUID().NewGuid();
            fusedCard.Level = IncreaseCardLevel(card1, card2);
            fusedCard.Rarity = CheckForRarityIncrease(card1);
            
            fusedCard.MaxHealth += GenerateNewStats(fusedCard);
            fusedCard.Attack += GenerateNewStats(fusedCard);
            fusedCard.Speed += GenerateNewStats(fusedCard);
            
            fusedCard.Name = card1.Name;
            fusedCard.Alignment = card1.Alignment;
            fusedCard.SpriteIndex = card1.SpriteIndex;
            
            rarityIncrease = false;

            var cardCollectedMessage = new AddItemToInventoryMessage<Card>(fusedCard,1);

            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);	
        }

        private short IncreaseCardLevel(Card card1, Card card2){
            var newLevel = (short) (card1.Level + card2.Level);
            if (newLevel > 10) {
                newLevel = 1;
                rarityIncrease = true;
                return newLevel;
            }
            return newLevel;
        }

        private Rarity CheckForRarityIncrease(Card card1){
            if (!rarityIncrease){
                return card1.Rarity;
            }
            return card1.Rarity switch {
                Rarity.Common => Rarity.Rare,
                Rarity.Rare => Rarity.Epic,
                Rarity.Epic => Rarity.Legendary,
            };
        }
        
        private float GenerateNewStats(Card fusedCard){
            var statsIncrease = 0f;
            // Ideally Library Index
            var statsMultiplier = cardLibrary.cards[fusedCard.SpriteIndex].StatsMultiplier;
            switch (fusedCard.Rarity){
                case Rarity.Common:
                    statsIncrease = fusedCard.Level * statsMultiplier;
                    break;
                case Rarity.Rare:
                    statsIncrease += fusedCard.Level * statsMultiplier * 2 + statsMultiplier * 10;
                    break;
                case Rarity.Epic:
                    statsIncrease += fusedCard.Level * statsMultiplier * 3 + statsMultiplier * 40;
                    break;
                case Rarity.Legendary:
                    statsIncrease += fusedCard.Level * statsMultiplier * 4 + statsMultiplier * 80;
                    break;
            }
            return statsIncrease;
        }
    }
}