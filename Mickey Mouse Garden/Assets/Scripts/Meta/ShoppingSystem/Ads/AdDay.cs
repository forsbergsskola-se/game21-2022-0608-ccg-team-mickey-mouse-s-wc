using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class AdDay : ISaveData
{

    public DateTime dateOfAdWatch;

    public StringGUID ID{ get; } = new StringGUID().CreateStringGuid(555555);
    public async void TryLoadData(){
        var loadedDay = await SaveManager.Load<AdDay>(ID);
        dateOfAdWatch = loadedDay.dateOfAdWatch;
        Debug.Log(loadedDay.dateOfAdWatch);
    }

    public void Save(){
        SaveManager.Save(this);
    }
}
