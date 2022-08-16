using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

[CustomComponent("AddStarterCards", "Populates the player's inventory on first launch")]
public class AddStarterCards : MonoBehaviour
{
    public List<CardConfig> starterCardConfigs;
    public CardInventory cardInventory;
    
    public void Start(){
        StartCoroutine(Delay());
    }
    public void AddStarterCardsToInventory()
    {
        foreach (var cardConfig in starterCardConfigs){
            var newCard = new Card(cardConfig.Id){
                Alignment = cardConfig.Alignment,
                Attack = cardConfig.Attack,
                ID = new StringGUID().NewGuid(),
                Level = cardConfig.Level,
                MaxHealth = cardConfig.MaxHealth,
                Name = cardConfig.Name,
                Rarity = cardConfig.Rarity,
                Speed = cardConfig.Speed,
                SpriteIndex = cardConfig.spriteIndex
            };
            Broker.InvokeSubscribers(typeof(AddItemToInventoryMessage<Card>), new AddItemToInventoryMessage<Card>(newCard,1));
        }
    }

    IEnumerator Delay(){
        yield return new WaitForSeconds(1);
        if (cardInventory.InventoryList.Items.Count == default){
            AddStarterCardsToInventory();
        }
    }
}
