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
        targetHealth = targetHealth - strikerDmg;
        target.MaxHealth = targetHealth;
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}