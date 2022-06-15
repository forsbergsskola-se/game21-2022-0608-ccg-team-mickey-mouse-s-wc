using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FighterInfoTester : MonoBehaviour{
    private FighterMessage fighterMessage;
    public Sprite sprite;
    private void Start()   {
        fighterMessage = new FighterMessage();
        var fighter = new FighterInfo();
        fighter.ID = 1;
        fighter.MaxHealth = 10;
        fighter.Attack = 5;
        fighter.Speed = 7;
        fighter.Rarity = "epic";
        fighter.Name = "Feona";
        fighter.Level = 2;
        fighter.Alignment = Alignment.Rock;
        fighter.Sprite = sprite;
        fighterMessage.fighterInfo = fighter;
    }
    [ContextMenu("Send Fighter Message")]
    public void SendFighterMessage(){
        Broker.InvokeSubscribers(typeof(FighterMessage),fighterMessage);
    }
}
