using System.Threading.Tasks;
using UnityEngine;

public class EndOfCombatCommand : ICommand{

    private bool playerWinner;
    private  Money reward;
    public EndOfCombatCommand(bool playerWinner, Money reward){
        this.playerWinner = playerWinner;
        this.reward = reward;
    }
    public Task ExecuteAsync(){
        Broker.InvokeSubscribers(typeof(CreatePostCombatUIMessage), new CreatePostCombatUIMessage());
        if (playerWinner){
            //TODO: celebrate the win
            Debug.Log("player wins!");
            
            SendPostCombatStateMessage(PostCombatState.Victory);
            var message = new CurrencyRewardMessage();
            message.money = reward;
            Broker.InvokeSubscribers(typeof(CurrencyRewardMessage), message);
            
        }

        if (!playerWinner){
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