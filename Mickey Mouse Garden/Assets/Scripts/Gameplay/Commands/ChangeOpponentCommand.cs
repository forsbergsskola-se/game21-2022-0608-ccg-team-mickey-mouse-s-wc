using System;
using UnityEngine;

public class ChangeOpponentCommand : ICommand{
    public void Execute(){
       Debug.Log("next command");
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}