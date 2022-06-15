using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;


public class CardCollection : ISaveData
{
    public Dictionary<Guid, OwnedCard> ownedCards;

    internal CardCollection(){
        ownedCards = new Dictionary<Guid, OwnedCard>();
        TryLoadData();
    }

    public Guid ID{ get; }
    public void TryLoadData(){
        //Try load data, if data found, override current data, otherwise, do nothing.
    }

    public void Save(){
        throw new NotImplementedException();
    }
}
