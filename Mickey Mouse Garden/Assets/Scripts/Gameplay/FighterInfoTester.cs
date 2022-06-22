using UnityEngine;

public class FighterInfoTester : MonoBehaviour{
    private FighterMessage fighterMessage;
    public Sprite sprite;
    private int autoid = 0; //TODO: remove this, only for testing purpose
    private void Start(){
        CreateFighter();
    }

    private void CreateFighter(){
        fighterMessage = new FighterMessage();
        var fighter = gameObject.AddComponent<FighterInfo>();
        fighter.ID = autoid++;
        fighter.MaxHealth = 10;
        fighter.Attack = 5;
        fighter.Speed = 10;
        fighter.Rarity = Rarity.Epic;
        fighter.Name = "Feona";
        fighter.Level = 2;
        fighter.Alignment = Alignment.Scissors;
        fighter.Sprite = sprite;
        fighterMessage.fighterInfo = fighter;
    }

    [ContextMenu("Send Fighter Message")]
    public void SendFighterMessage(){
        Broker.InvokeSubscribers(typeof(FighterMessage),fighterMessage);
        CreateFighter2();
    }

    private void CreateFighter2(){
        fighterMessage = new FighterMessage();
        var fighter = gameObject.AddComponent<FighterInfo>();
        fighter.ID = autoid++;
        fighter.MaxHealth = 10;
        fighter.Attack = 5;
        fighter.Speed = 5;
        fighter.Rarity = Rarity.Legendary;
        fighter.Name = "Foo";
        fighter.Level = 3;
        fighter.Alignment = Alignment.Rock;
        fighter.Sprite = sprite;
        fighterMessage.fighterInfo = fighter;
    }
}
