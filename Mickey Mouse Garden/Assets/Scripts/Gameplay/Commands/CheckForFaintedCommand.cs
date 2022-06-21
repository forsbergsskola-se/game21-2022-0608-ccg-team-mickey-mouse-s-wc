using System;

public class CheckForFaintedCommand : ICommand{
    private FighterInfo targetedFighter;

    public CheckForFaintedCommand(FighterInfo targetedFighter){
        this.targetedFighter = targetedFighter;
    }
    public void Execute(){
        FighterFaintMessage faintMessage = new();
        if (targetedFighter.MaxHealth <= 0){
            faintMessage.fighterInfo = targetedFighter;
            Broker.InvokeSubscribers(typeof(FighterFaintMessage), faintMessage);
        }
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}