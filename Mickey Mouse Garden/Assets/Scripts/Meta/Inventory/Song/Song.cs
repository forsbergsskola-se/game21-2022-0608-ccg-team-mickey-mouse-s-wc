using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;
[Serializable]
public class Song : IInventoryItem{
    public string libraryID{ get; set; }
    public StringGUID ID{ get; }
    public void TryLoadData(){
        throw new NotImplementedException();
    }

    public void Save(){
        throw new NotImplementedException();
    }
}
