using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using Task = System.Threading.Tasks.Task;


public class CardCollection : ISaveData
{
    public Dictionary<Guid, OwnedCard> ownedCards;

    internal CardCollection(){
        ownedCards = new Dictionary<Guid, OwnedCard>();
        TryLoadData(); // TODO: Probably needs to be awaited.
    }

    public Guid ID{ get; }
    public async Task TryLoadData(){ //Try load data, if data found, override current data, otherwise, do nothing.
      var savedDictionary =  await SaveManager.Load<Dictionary<Guid, OwnedCard>>(ID);
      ownedCards = savedDictionary;
    }

    public void Save(){
        throw new NotImplementedException();
    }
}
