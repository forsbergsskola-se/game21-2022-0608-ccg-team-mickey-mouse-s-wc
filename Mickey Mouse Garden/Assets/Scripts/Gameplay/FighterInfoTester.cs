using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FighterInfoTester : MonoBehaviour{
    private FighterMessage fighterMessage = new FighterMessage();
    public Sprite sprite;
    private void start()   {
        var fighter = fighterMessage.fighterInfo;
        fighter.ID = 1;
        fighter.MaxHealth = 10;
        fighter.Attack = 5;
        fighter.Speed = 7;
        fighter.Rarity = "epic";
        fighter.Name = "Feona";
        fighter.Level = 2;
        fighter.Alignment = Alignment.Flora;
        fighter.Sprite = sprite;
    }
    [ContextMenu("Send Fighter Message")]
    public void SendFighterMessage(){
        Broker.InvokeSubscribers(typeof(FighterMessage),fighterMessage);
    }
}
