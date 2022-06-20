using System;
using UnityEngine;

public class StrikeCommand : ICommand{
    private GameObject target;
    private GameObject striker;

    public StrikeCommand(GameObject target, GameObject striker){
        this.target = target;
        this.striker = striker;
    }
    public void Execute(){
        Debug.Log($"{striker} hit {target}");
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}