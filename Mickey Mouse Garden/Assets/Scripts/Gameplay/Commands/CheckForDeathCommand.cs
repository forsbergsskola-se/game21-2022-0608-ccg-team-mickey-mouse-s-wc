using System;

public class CheckForDeathCommand : ICommand{
    private FighterInfo firstFighter;
    private FighterInfo secondFighter;

    public CheckForDeathCommand(FighterInfo firstFighter, FighterInfo secondFighter){
        this.firstFighter = firstFighter;
        this.secondFighter = secondFighter;
    }
    public void Execute(){
        FighterDeathMessage deathMessage = new();
        if (firstFighter.MaxHealth <= 0){
            deathMessage.fighterInfo = firstFighter;
            Broker.InvokeSubscribers(typeof(FighterDeathMessage), deathMessage);
            return;
        }
        if (secondFighter.MaxHealth <= 0){
            deathMessage.fighterInfo = secondFighter;
            Broker.InvokeSubscribers(typeof(FighterDeathMessage), deathMessage);
        }
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}