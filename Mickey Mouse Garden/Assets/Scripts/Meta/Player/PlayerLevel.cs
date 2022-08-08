using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using UnityEngine;
[Serializable]
public class PlayerLevel : ISaveData{
    private int level;

    public int Level{
        get;
        set;
    } = 1;
    public StringGUID ID{ get; } = new StringGUID().CreateStringGuid(0010113);
    public async void TryLoadData(){
        var playerLevel = await SaveManager.Load<PlayerLevel>(ID);
        if(playerLevel != null){
            Level = playerLevel.Level;
            Debug.Log("PL" + playerLevel.Level);
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
        Save();
    }

    public void CheckLevelUp(int attemptedCombatLevel){
        if(attemptedCombatLevel == Level){
            LevelUp();
        }
    }
}