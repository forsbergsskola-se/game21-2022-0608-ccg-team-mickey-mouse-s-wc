using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public CardCollection cardCollection = new CardCollection();
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    
    void LoadAllData(){
        cardCollection.TryLoadData();
    }
    [ContextMenu("LoadCardCollection")]
    void LoadCardCollection(){
        Debug.Log("Loading cards for Card Collections...", this);
        cardCollection.TryLoadData();
        Debug.Log("Loaded Cards in Card Collections: " +cardCollection.ownedCards,this);
    }
    [ContextMenu("SaveCardCollection")]
    void SaveCardCollection(){
        cardCollection.Save();
    }
    [ContextMenu("AddCardToCollection")]
    void AddCardToCollection(){
        cardCollection.AddCard(Guid.NewGuid(),new OwnedCard(Guid.NewGuid(),(Card) ScriptableObject.CreateInstance("Card"),Rarity.Common,50,40,30,20));
    }
}
