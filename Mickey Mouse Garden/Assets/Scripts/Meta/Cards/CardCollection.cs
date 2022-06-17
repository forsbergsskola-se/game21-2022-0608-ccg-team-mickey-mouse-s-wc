using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using Task = System.Threading.Tasks.Task;

[Serializable]
public class CardCollection : ISaveData
{
     public Dictionary<int, OwnedCard> ownedCards{ get; private set; }

     public CardCollection(int id){
        ID = id;
        ownedCards = new Dictionary<int, OwnedCard>();
     }

    public int ID{ get; }
    public async Task TryLoadData(){ //Try load data, if data found, override current data, otherwise, do nothing.
      var savedDictionary =  await SaveManager.Load<CardCollection>(ID);
      ownedCards = savedDictionary.ownedCards;
    }

    public void Save(){
        SaveManager.Save(this);
    }

    public void AddCard(int id, OwnedCard card){
        ownedCards.Add(id,card);
        Save();
    }
}
