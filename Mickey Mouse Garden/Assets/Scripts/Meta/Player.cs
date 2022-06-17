using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour{
    public CardCollection cardCollection = new CardCollection(1); //ID for test rn
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    
    [ContextMenu("LoadCardCollection")]
    async Task LoadCardCollection(){
        Debug.Log("Loading cards for Card Collections...", this);
        await cardCollection.TryLoadData();
        Debug.Log("Loaded Cards in Card Collections: ",this);
        foreach (var KeyValuePair in cardCollection.ownedCards){
            Debug.Log($"Key: ({KeyValuePair.Key}), Value: ({KeyValuePair.Value})");
        }
    }
    [ContextMenu("SaveCardCollection")]
    void SaveCardCollection(){
        cardCollection.Save();
    }
    [ContextMenu("AddCardToCollection")]
    void AddCardToCollection(){
        var newCardID = 2;
        //cardCollection.AddCard(newCardID,new OwnedCard(newCardID,(Card) ScriptableObject.CreateInstance("Card"),Rarity.Common,50,40,30,20));
    }
    
    [ContextMenu("LoadSPECIALCardToCollection")]
    async Task LoadSPECIALCardToCollection(){
        OwnedCard card = new OwnedCard();
        card.ID = 66;
        await card.TryLoadData();
        cardCollection.ownedCards.Add(card.ID,card);
        foreach (var propertyInfo in cardCollection.ownedCards[card.ID].GetType().GetProperties()){
            Debug.Log($"{propertyInfo.Name}: {propertyInfo.GetValue(card)}", this);
        }
        Debug.Log(cardCollection.ownedCards[card.ID]);
    }
}
