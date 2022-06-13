using UnityEngine;

public class FighterSelectionInstantiator : MonoBehaviour{
	private int id, health, damage, speed, level;
	private string rarity, name, alignment;
	private Sprite sprite;
	private void Awake(){
		Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
	}

	private void OnFighterMessageReceived(FighterMessage fighterMessage){
		id = fighterMessage.ID;
		health = fighterMessage.Health;
		damage = fighterMessage.Damage;
		speed = fighterMessage.Speed;
		level = fighterMessage.Level;
		rarity = fighterMessage.Rarity;
		name = fighterMessage.Name;
		alignment = fighterMessage.Alignment;
		sprite = fighterMessage.Sprite;
	}
}
