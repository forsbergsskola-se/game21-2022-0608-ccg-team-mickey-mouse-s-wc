using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using UnityEngine;

public class PlayerLevel : ISaveData{
    int level;
    public int Level{
        get => level;
        set{
            level = value;
            Save();
        }
    }

    internal PlayerLevel(){
        TryLoadData();
    }
    public StringGUID ID{ get; }
    public void TryLoadData(){
        Level = SaveManager.Load<PlayerLevel>(ID).Result.Level;
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