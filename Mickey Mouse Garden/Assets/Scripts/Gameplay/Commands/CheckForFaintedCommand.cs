using System;

public class CheckForFaintedCommand : ICommand{
    private FighterInfo firstFighter;
    private FighterInfo secondFighter;

    public CheckForFaintedCommand(FighterInfo firstFighter, FighterInfo secondFighter){
        this.firstFighter = firstFighter;
        this.secondFighter = secondFighter;
    }
    public void Execute(){
        FighterFaintMessage faintMessage = new();
        if (firstFighter.MaxHealth <= 0){
            faintMessage.fighterInfo = firstFighter;
            Broker.InvokeSubscribers(typeof(FighterFaintMessage), faintMessage);
            return;
        }
        if (secondFighter.MaxHealth <= 0){
            faintMessage.fighterInfo = secondFighter;
            Broker.InvokeSubscribers(typeof(FighterFaintMessage), faintMessage);
        }
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}