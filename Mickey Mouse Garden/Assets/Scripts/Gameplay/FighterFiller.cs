using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FighterFiller : MonoBehaviour{
    public TextMeshProUGUI dmgText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI speedText;
    void Start() {
        Broker.Subscribe<FighterMessage>(OnFighterReceived);
    }

    private void OnFighterReceived(FighterMessage obj){
        dmgText.text = obj.fighterInfo.Attack.ToString();
        healthText.text = obj.fighterInfo.MaxHealth.ToString();
        speedText.text = obj.fighterInfo.Speed.ToString();
    }
}
