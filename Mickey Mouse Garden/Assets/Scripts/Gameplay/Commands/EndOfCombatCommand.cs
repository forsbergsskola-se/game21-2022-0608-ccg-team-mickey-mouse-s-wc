using System.Threading.Tasks;

public class EndOfCombatCommand : ICommand{

    private bool playerWinner;
    private  Money reward;
    public EndOfCombatCommand(bool playerWinner){
        this.playerWinner = playerWinner;
    }
    public Task ExecuteAsync(){
        Broker.InvokeSubscribers(typeof(CreatePostCombatUIMessage), new CreatePostCombatUIMessage());
        if (playerWinner){
            SendPostCombatStateMessage(PostCombatState.Victory);
            var message = new CurrencyRewardMessage();
            message.money = reward;
            Broker.InvokeSubscribers(typeof(CurrencyRewardMessage), message);
        }
        if (!playerWinner){
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