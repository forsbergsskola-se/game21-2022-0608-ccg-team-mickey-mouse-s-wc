using System;
using UnityEngine;

public class ChangeOpponentCommand : ICommand{
    
    public ChangeOpponentCommand(){
    }

    public void Execute(){
       Debug.Log("NextFighter!");
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}