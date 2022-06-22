using System.Threading.Tasks;
using UnityEngine;

public class EndOfCombatCommand : ICommand{
    private int playerTeamIncrementor;
    private int enemyTeamIncrementor;
    ICurrency reward;
    public EndOfCombatCommand(int playerTeamIncrementor, int enemyTeamIncrementor, ICurrency reward){
        this.playerTeamIncrementor = playerTeamIncrementor;
        this.enemyTeamIncrementor = enemyTeamIncrementor;
        this.reward = reward;
    }
    public Task ExecuteAsync(){
        if (playerTeamIncrementor > 2){
            //TODO: celebrate the win
            Debug.Log("player wins!");
            
            
            //Await Load Reward Scene to display reward
            var message = new CurrencyRewardMessage();
            message.Currency = reward;
            Broker.InvokeSubscribers(typeof(CurrencyRewardMessage),message );
            
        }

        if (enemyTeamIncrementor > 2){
            //TODO: cry about defeat
            Debug.Log("enemy wins!");

        }
        return Task.CompletedTask;
    }

    public void Undo(){
        throw new System.NotImplementedException();
    }
}