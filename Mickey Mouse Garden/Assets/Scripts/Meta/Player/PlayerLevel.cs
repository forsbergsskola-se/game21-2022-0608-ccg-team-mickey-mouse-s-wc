using System;
using Meta.Cards;

[Serializable]
public class PlayerLevel : ISaveData{
    public int Level{
        get;
        set;
    } = 1;
    public StringGUID ID{ get; } = new StringGUID().CreateStringGuid(0010113);
    public async void TryLoadData(){
        var playerLevel = await SaveManager.Load<PlayerLevel>(ID);
        if (playerLevel == null) return;
        Level = playerLevel.Level;
    }

    public void Save(){
        SaveManager.Save(this);
    }

    public void OnCombatLevelMessageReceived(EnterLevelMessage message){
        if(message.Level == Level){
            LevelUp();
        }
    }

    private void LevelUp(){
        Level++;
        Save();
    }

    public void CheckLevelUp(int attemptedCombatLevel){
        if(attemptedCombatLevel == Level){
            LevelUp();
        }
    }
}