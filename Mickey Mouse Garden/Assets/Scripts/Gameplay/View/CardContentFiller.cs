using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardContentFiller : MonoBehaviour{
	private int id, level;
	private float health, attack, speed;
	private string rarity, name;
	private Alignment alignment;
	private Sprite fighterSprite;
	
	public TextMeshProUGUI nameText, rarityText, alignmentText, levelText, attackText, healthText, speedText;
	public Image fighterImage;
	
	public void AssignTextFields(FighterInfo fighter){
		nameText.text = fighter.Name;
		rarityText.text = fighter.Rarity.ToString();
		alignmentText.text = fighter.Alignment.ToString();
		levelText.text = fighter.Level.ToString();
		attackText.text = fighter.Attack.ToString();
		healthText.text = fighter.MaxHealth.ToString();
		speedText.text = fighter.Speed.ToString();
		fighterImage.sprite = fighter.Sprite;
	}

	
}
