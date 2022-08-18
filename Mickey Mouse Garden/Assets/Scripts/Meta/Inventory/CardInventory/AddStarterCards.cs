using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private void AddStarterCardsToInventory(){
        foreach (var newCard in starterCardConfigs.Select(cardConfig => new Card(cardConfig.id){
                     Alignment = cardConfig.alignment,
                     Attack = cardConfig.attack,
                     ID = new StringGUID().NewGuid(),
                     Level = cardConfig.level,
                     MaxHealth = cardConfig.maxHealth,
                     Name = cardConfig.Name,
                     Rarity = cardConfig.rarity,
                     Speed = cardConfig.speed,
                     SpriteIndex = cardConfig.spriteIndex
                 })){
            Broker.InvokeSubscribers(typeof(AddItemToInventoryMessage<Card>), new AddItemToInventoryMessage<Card>(newCard,1));
        }
    }

    private IEnumerator Delay(){
            yield return new WaitForSeconds(1);
           if(cardInventory.InventoryList.Items.Count == default)
           {
                AddStarterCardsToInventory();
           }
    }

}
