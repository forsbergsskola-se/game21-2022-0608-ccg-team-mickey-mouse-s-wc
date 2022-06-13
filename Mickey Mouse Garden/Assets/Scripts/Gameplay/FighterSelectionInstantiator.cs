using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FighterSelectionInstantiator : MonoBehaviour{
	private int id, level;
	private float health, attack, speed;
	private string rarity, name;
	private Alignment alignment;
	private Sprite fighterSprite;

	public TextMeshProUGUI nameText, rarityText, alignmentText, levelText, attackText, healthText, speedText;
	public Image fighterImage;
	private void Awake() {
		Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
	}

	private void OnFighterMessageReceived(FighterMessage fighterMessage) {
		id = fighterMessage.ID;
		health = fighterMessage.Health;
		attack = fighterMessage.Attack;
		speed = fighterMessage.Speed;
		level = fighterMessage.Level;
		rarity = fighterMessage.Rarity;
		name = fighterMessage.Name;
		alignment = fighterMessage.Alignment;
		fighterSprite = fighterMessage.Sprite;
		AssignProperties();
	}

	private void AssignProperties() {
		nameText.text = name;
		rarityText.text = rarity;
		alignmentText.text = alignment.ToString(); //TODO: this is an enum..
		levelText.text = level.ToString();
		attackText.text = attack.ToString();
		healthText.text = health.ToString();
		speedText.text = speed.ToString();
		fighterImage.sprite = fighterSprite;
	}

	private void OnDestroy(){
		Broker.Unsubscribe<FighterMessage>(OnFighterMessageReceived);
	}
}
