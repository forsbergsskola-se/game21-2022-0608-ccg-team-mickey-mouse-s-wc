using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour{
    public CardCollection cardCollection = new CardCollection(new Guid("11111111-1111-1111-1111-000000000000")); //ID for test rn
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
        var newCardID = Guid.NewGuid();
        cardCollection.AddCard(newCardID,new OwnedCard(newCardID,(Card) ScriptableObject.CreateInstance("Card"),Rarity.Common,50,40,30,20));
    }
}
