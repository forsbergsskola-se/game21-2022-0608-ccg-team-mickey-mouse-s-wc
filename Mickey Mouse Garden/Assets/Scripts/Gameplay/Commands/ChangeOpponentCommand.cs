using System;
using UnityEngine;

public class ChangeOpponentCommand : ICommand{
    private GameObject newTarget;

    public ChangeOpponentCommand(GameObject newTarget){
        this.newTarget = newTarget;
    }
    public void Execute(){
        newTarget = new GameObject();
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}