using System;
using System.Collections;
using System.Linq;
using Meta.Cards;
using UnityEngine;
using Meta.Inventory.FighterInventory;

namespace Meta.Inventory {
    public class CardFuser : MonoBehaviour {
        public CardLibraryConfig cardLibrary;
        private bool rarityIncrease;

        private void OnEnable() {
            Broker.Subscribe<CardSacrificedMessage>(OnCardSacrificedMessageReceived);
        }
        private void OnDisable(){
            Broker.Unsubscribe<CardSacrificedMessage>(OnCardSacrificedMessageReceived);
        }
        
        private Card CreateNewCard(CardConfig libraryCardConfig){
            var card = new Card(libraryCardConfig.LibraryID);

            card.ID = new StringGUID().NewGuid();
            card.MaxHealth = libraryCardConfig.MaxHealth;
            card.Attack = libraryCardConfig.Attack;
            card.Speed = libraryCardConfig.Speed;
            card.Level = libraryCardConfig.Level;
            card.Rarity = libraryCardConfig.Rarity;
            card.Name = libraryCardConfig.Name;
            card.Alignment = libraryCardConfig.Alignment;
            card.SpriteIndex = libraryCardConfig.spriteIndex;
            return card;
        }

        // !!! SACRIFICE !!!!
        private void SacrificeCards(Card card){
            var removeInventoryItemMessage = new RemoveInventoryItemMessage<Card>(card.libraryID, card.ID);
            Broker.InvokeSubscribers(removeInventoryItemMessage.GetType(), removeInventoryItemMessage);
        }
        
        // and fusion...
        private void OnCardSacrificedMessageReceived(CardSacrificedMessage obj){
            TryFuseCards(obj.Card1, obj.Card2);
        }
        private void TryFuseCards(Card card1, Card card2){
            if (!CheckForMaxLevel(card1, card2))
                return;
            SpawnFusedCard(card1, card2);
            // Removes card from inventory or in other words.... DIEEEEEE!!!!
            SacrificeCards(card1);
            SacrificeCards(card2);
        }

        private static bool CheckForMaxLevel(Card card1, Card card2){
            return (card1.Rarity != Rarity.Legendary && card1.Level != 10) || (card2.Rarity != Rarity.Legendary && card2.Level != 10);
        }

        private void SpawnFusedCard(Card card1, Card card2){
            
            var fusedCard = CreateNewCard(cardLibrary.cards.First(x => x.LibraryID == card1.libraryID));
            
            var cardConfig = cardLibrary.cards[fusedCard.SpriteIndex];

            fusedCard.ID = new StringGUID().NewGuid();
            fusedCard.Level = IncreaseCardLevel(card1, card2); 
            fusedCard.Rarity = CheckForRarityIncrease(card1);

            // Takes base stats adds additional stats
            fusedCard.MaxHealth = GenerateNewStats(fusedCard, cardConfig.HealthMultiplier, fusedCard.MaxHealth, cardConfig.Rarity);
            fusedCard.Attack = GenerateNewStats(fusedCard, cardConfig.AttackMultiplier, fusedCard.Attack, cardConfig.Rarity);
            fusedCard.Speed = GenerateNewStats(fusedCard, cardConfig.SpeedMultiplier, fusedCard.Speed, cardConfig.Rarity);
            

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
        
        private float GenerateNewStats(Card fusedCard, float statsMultiplier, float statComponent, Rarity cardConfigRarity){
            // Get commonBase stats.
            var commonBaseComponent = statComponent - (int)cardConfigRarity * statsMultiplier;
            // Return the difference from common rarity to current rarity and level.
            var newStats = commonBaseComponent + (fusedCard.Level - 1 + (int)fusedCard.Rarity) * statsMultiplier;
            
            return MathF.Floor(newStats);
        }
    }
}