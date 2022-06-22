using System;
using System.Collections.Generic;
[Serializable]
public class CardCollection : ISaveData
{
     public Dictionary<StringGUID, OwnedCard> ownedCards{ get; private set; }

     public CardCollection(StringGUID id){
        ID = id;
        ownedCards = new Dictionary<StringGUID, OwnedCard>();
     }

    public StringGUID ID{ get; }
    public async void TryLoadData(){ //Try load data, if data found, override current data, otherwise, do nothing.
      var savedDictionary =  await SaveManager.Load<CardCollection>(ID);
      ownedCards = savedDictionary.ownedCards;
    }

    public void Save(){
        SaveManager.Save(this);
    }

    public void AddCard(StringGUID id, OwnedCard card){
        ownedCards.Add(id,card);
        Save();
    }
}
