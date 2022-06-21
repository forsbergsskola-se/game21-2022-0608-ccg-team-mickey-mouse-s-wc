using System;
using UnityEngine;

public class ChangeOpponentCommand : ICommand{
    
    public ChangeOpponentCommand(out FighterInfo nextFighter){
        nextFighter = new FighterInfo();
    }

    public void Execute(){
       Debug.Log("NextFighter!");
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}