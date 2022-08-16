using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Day : ISaveData
{
    public int claimableDay; // day of the week (1-7)
    public DateTime dateOfClaim;
    
    public StringGUID ID{ get; } = new StringGUID().CreateStringGuid(995599);
    public async void TryLoadData(){
        var loadedDay = await SaveManager.Load<Day>(ID);
        
        claimableDay = loadedDay.claimableDay;
        dateOfClaim = loadedDay.dateOfClaim;

        if (loadedDay.claimableDay == default){
            Debug.Log("Reset To " + claimableDay);
            claimableDay = 0;
            Save();
        }
    }

    public void Save(){
        SaveManager.Save(this);
    }
}
