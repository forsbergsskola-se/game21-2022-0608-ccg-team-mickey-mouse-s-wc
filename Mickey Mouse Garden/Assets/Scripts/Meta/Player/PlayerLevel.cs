using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using UnityEngine;
[Serializable]
public class PlayerLevel : ISaveData{
    int level;
    public int Level{
        get => level;
        private set{
            level = value;
            Save();
        }
    }
    public StringGUID ID{ get; } = new StringGUID().CreateStringGuid(0010113);
    public async void TryLoadData(){
        var playerLevel = await SaveManager.Load<PlayerLevel>(ID);
        if(playerLevel != null){
            Level = playerLevel.Level;
        }
        else{
            Level = 1;
        }
        
    }

    public void Save(){
        SaveManager.Save(this);
    }

    public void OnCombatLevelMessageReceived(LevelMessage message){
        if(message.Level == Level){
            LevelUp();
        }
    }

    void LevelUp(){
        Level++;
    }

    public void CheckLevelUp(int attemptedCombatLevel){
        if(attemptedCombatLevel == Level){
            LevelUp();
        }
    }
}