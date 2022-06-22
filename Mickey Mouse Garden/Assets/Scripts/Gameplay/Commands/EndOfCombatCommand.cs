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
        Broker.InvokeSubscribers(typeof(CreatePostCombatUIMessage), new CreatePostCombatUIMessage());
        if (playerTeamIncrementor > 2){
            //TODO: celebrate the win
            Debug.Log("player wins!");
            
            SendPostCombatStateMessage(PostCombatState.Victory);
            var message = new CurrencyRewardMessage();
            message.Currency = reward;
            Broker.InvokeSubscribers(typeof(CurrencyRewardMessage), message);
            
        }

        if (enemyTeamIncrementor > 2){
            //TODO: cry about defeat
            Debug.Log("enemy wins!");
            SendPostCombatStateMessage(PostCombatState.Defeat);
        }
        return Task.CompletedTask;
    }

    public void Undo(){
        throw new System.NotImplementedException();
    }

    void SendPostCombatStateMessage(PostCombatState state){
        var postCombatMessage = new PostCombatStateMessage();
        postCombatMessage.State = state;
        Broker.InvokeSubscribers(typeof(PostCombatStateMessage),postCombatMessage);
    }
}