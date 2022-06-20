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
        CheckAlignment();
        target.MaxHealth -= striker.Attack * multiplier;
        Debug.Log(target.MaxHealth);
    }

    private void CheckAlignment(){
        if (target.Alignment == striker.Alignment){
            return;
        }
        switch (striker.Alignment){
            case Alignment.Paper:{
                switch (target.Alignment){
                    case Alignment.Rock:
                        multiplier += 0.5f;
                        break;
                    case Alignment.Scissors:
                        multiplier -= 0.5f;
                        break;
                }
                break;
            }
            case Alignment.Rock:{
                switch (target.Alignment){
                    case Alignment.Scissors:
                        multiplier += 0.5f;
                        break;
                    case Alignment.Paper:
                        multiplier -= 0.5f;
                        break;
                }
                break;
            }
            case Alignment.Scissors:{
                switch (target.Alignment){
                    case Alignment.Paper:
                        multiplier += 0.5f;
                        break;
                    case Alignment.Rock:
                        multiplier -= 0.5f;
                        break;
                }
                break;
            }
        }
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}