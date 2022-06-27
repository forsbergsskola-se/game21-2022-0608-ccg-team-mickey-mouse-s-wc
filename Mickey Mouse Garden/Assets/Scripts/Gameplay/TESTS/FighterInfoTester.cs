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
        fighterMessage.fighterInfo = new FighterInfo();
        fighterMessage.fighterInfo.ID = autoid++;
        fighterMessage.fighterInfo.MaxHealth = 10;
        fighterMessage.fighterInfo.Attack = 5;
        fighterMessage.fighterInfo.Speed = 10;
        fighterMessage.fighterInfo.Rarity = Rarity.Epic;
        fighterMessage.fighterInfo.Name = "Foo";
        fighterMessage.fighterInfo.Level = 2;
        fighterMessage.fighterInfo.Alignment = Alignment.Scissors;
        fighterMessage.fighterInfo.Sprite = sprite;
    }

    [ContextMenu("Send Fighter Message")]
    public void SendFighterMessage(){
        Broker.InvokeSubscribers(typeof(FighterMessage),fighterMessage);
        CreateFighter2();
    }

    private void CreateFighter2(){
        fighterMessage.fighterInfo.ID = autoid++;
        fighterMessage.fighterInfo.MaxHealth = 15;
        fighterMessage.fighterInfo.Attack = 3;
        fighterMessage.fighterInfo.Speed = 5;
        fighterMessage.fighterInfo.Rarity = Rarity.Legendary;
        fighterMessage.fighterInfo.Name = "Bar";
        fighterMessage.fighterInfo.Level = 3;
        fighterMessage.fighterInfo.Alignment = Alignment.Rock;
        fighterMessage.fighterInfo.Sprite = sprite;
    }
}
