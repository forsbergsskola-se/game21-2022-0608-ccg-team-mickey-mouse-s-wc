using System;
using UnityEngine;

public class ChangeOpponnentCommand : ICommand{
    private GameObject newTarget;

    public ChangeOpponnentCommand(GameObject newTarget){
        this.newTarget = newTarget;
    }
    public void Execute(){
        newTarget = new GameObject();
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}