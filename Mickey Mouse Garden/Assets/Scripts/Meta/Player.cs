using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour{
    public static StringGUID testCollectionGuid = new StringGUID("0e4b39c1-75e0-4f21-b3c1-b017dce032e0");
    public CardCollection cardCollection = new CardCollection(testCollectionGuid); //ID for test rn
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
        cardCollection.TryLoadData();
        foreach (var propertyInfo in cardCollection.GetType().GetProperties()){
            Debug.Log($"{propertyInfo.Name}: {propertyInfo.GetValue(cardCollection)}", this);
        }
    }
    
    


    [ContextMenu("LoadCardCollection")]
    async void  LoadCardCollection1(){
        Debug.Log("Loading cards for Card Collections...", this);
         cardCollection.TryLoadData();
        Debug.Log("Loaded Cards in Card Collections: ",this);
        foreach (var KeyValuePair in cardCollection.ownedCards){
            Debug.Log($"Key: ({KeyValuePair.Key}), Value: ({KeyValuePair.Value})");
            foreach (var propertyInfo in KeyValuePair.Value.GetType().GetProperties()){
                Debug.Log($"{propertyInfo.Name}: {propertyInfo.GetValue(KeyValuePair.Value)}", this);
            }
        }
    }
    [ContextMenu("SaveCardCollection")]
    void SaveCardCollection(){
        cardCollection.Save();
    }
    [ContextMenu("AddCardToCollection")]
    void AddCardToCollection(){
      StringGUID testCardGuid = new StringGUID().NewGuid();
        cardCollection.AddCard(testCardGuid,new OwnedCard(testCardGuid,"Abbathon the Carrot", Alignment.Scissors,"fighter1",Rarity.Legendary,1,10f,100f,20f));
    }
    
    [ContextMenu("LoadSPECIALCardToCollection")]
    async Task LoadSPECIALCardToCollection(){
        OwnedCard card = new OwnedCard();
        card.ID = new StringGUID().NewGuid(); // Does this work?
         card.TryLoadData();
        cardCollection.ownedCards.Add(card.ID,card);
        foreach (var propertyInfo in cardCollection.ownedCards[card.ID].GetType().GetProperties()){
            Debug.Log($"{propertyInfo.Name}: {propertyInfo.GetValue(card)}", this);
        }
        Debug.Log(cardCollection.ownedCards[card.ID]);
    }
    
    [ContextMenu("IDIncrementorTest")]
    void IDIncrementorTest(){
      //  IDIncrementor.Instance.IncrementID();
    }
}
