using System;
using System.Threading.Tasks;

public class CheckForFaintedCommand : ICommand{
    private FighterInfo playerFighter;
    private FighterInfo enemyFighter;

    public CheckForFaintedCommand(FighterInfo playerFighter, FighterInfo enemyFighter){
        this.playerFighter = playerFighter;
        this.enemyFighter = enemyFighter;
    }

    public Task ExecuteAsync(){
        if (playerFighter.MaxHealth <= 0){
            FighterFaintMessage faintMessage = new(){fighterInfo = playerFighter, wasPlayerFighter = true};
            Broker.InvokeSubscribers(typeof(FighterFaintMessage), faintMessage);
        }
        if (!(enemyFighter.MaxHealth <= 0)) return Task.CompletedTask;
        {
            FighterFaintMessage faintMessage = new(){fighterInfo = enemyFighter, wasPlayerFighter = false};
            Broker.InvokeSubscribers(typeof(FighterFaintMessage), faintMessage);
        }
        return Task.CompletedTask;
    }
}