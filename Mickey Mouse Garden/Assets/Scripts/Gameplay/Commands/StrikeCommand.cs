using System;
using UnityEngine;

public class StrikeCommand : ICommand{
    private FighterInfo target;
    private FighterInfo striker;

    private float multiplier = 1f;

    public StrikeCommand(FighterInfo target, FighterInfo striker){
        this.target = target;
        this.striker = striker;
    }
    public void Execute(){
        Strike();
    }

    private void Strike(){
        target.MaxHealth -= striker.Attack * CheckAlignment();
        Debug.Log($"{target.Name}s health is now {target.MaxHealth}");
    }

    private float CheckAlignment(){ //TODO: make a dictionary of dictionaries kinda deal ala Marc
        if (target.Alignment == striker.Alignment) return multiplier;
        if (striker.Alignment == Alignment.Paper){
            if (target.Alignment == Alignment.Rock) return multiplier += 0.5f;
            if (target.Alignment == Alignment.Scissors) return multiplier -= 0.5f;
        }
        else if (striker.Alignment == Alignment.Rock){
            if (target.Alignment == Alignment.Scissors) return multiplier += 0.5f;
            if (target.Alignment == Alignment.Paper) return multiplier -= 0.5f;
        }
        else if (striker.Alignment == Alignment.Scissors)
            if (target.Alignment == Alignment.Paper) return multiplier += 0.5f;
            if (target.Alignment == Alignment.Rock) return multiplier -= 0.5f;
            return multiplier;
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}