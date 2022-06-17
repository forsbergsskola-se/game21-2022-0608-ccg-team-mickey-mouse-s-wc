using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using Task = System.Threading.Tasks.Task;

[Serializable]
public class CardCollection : ISaveData
{
     public SerializableDictionary<StringGUID, OwnedCard> ownedCards{ get; private set; }

     public CardCollection(StringGUID id){
        ID = id;
        ownedCards = new SerializableDictionary<StringGUID, OwnedCard>();
     }

    public StringGUID ID{ get; }
    public async Task TryLoadData(){ //Try load data, if data found, override current data, otherwise, do nothing.
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
