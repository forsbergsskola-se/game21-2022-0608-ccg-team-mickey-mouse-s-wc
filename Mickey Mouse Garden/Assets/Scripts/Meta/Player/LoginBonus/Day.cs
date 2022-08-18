using System;

[Serializable]
public class Day : ISaveData
{
    public int claimableDay; // day of the week (1-7)
    public DateTime dateOfClaim;
    public StringGUID ID{ get; } = new StringGUID().CreateStringGuid(995599);
    
    public async void TryLoadData(){
        var loadedDay = await SaveManager.Load<Day>(ID);
        if (loadedDay == null){
            return;
        }
        
        claimableDay = loadedDay.claimableDay;
        dateOfClaim = loadedDay.dateOfClaim;
    }

    public void Save(){
        SaveManager.Save(this);
    }
}
