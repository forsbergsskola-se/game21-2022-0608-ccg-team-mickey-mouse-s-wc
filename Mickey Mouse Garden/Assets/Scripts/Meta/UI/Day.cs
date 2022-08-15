using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Day : ISaveData
{
    public int claimedDay; // day of the week (1-7)
    public DateTime dateOfClaim;

    public StringGUID ID{ get; } = new StringGUID().CreateStringGuid(995599);
    public async void TryLoadData(){
        var loadedDay = await SaveManager.Load<Day>(ID);
        claimedDay = loadedDay.claimedDay;
        dateOfClaim = loadedDay.dateOfClaim;
    }

    public void Save(){
        SaveManager.Save(this);
    }
}
