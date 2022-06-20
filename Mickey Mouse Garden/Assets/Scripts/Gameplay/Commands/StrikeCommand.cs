using System;
using UnityEngine;

public class StrikeCommand : ICommand{
    private FighterInfo target;
    private FighterInfo striker;

    public StrikeCommand(FighterInfo target, FighterInfo striker){
        this.target = target;
        this.striker = striker;
    }
    public void Execute(){
        var targetHealth = target.MaxHealth;
        var strikerDmg = striker.Attack;
        targetHealth -= strikerDmg;
        target.MaxHealth = targetHealth;
        Debug.Log(targetHealth);
        Debug.Log(strikerDmg);
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}