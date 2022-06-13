using UnityEngine;

public class SelectTeam : MonoBehaviour{
   private FighterSO selectedFighter;
   private FighterSO[] fighters = new FighterSO[3];
   private int incrementor;

   private void Start(){
      Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
   }

   private void OnFighterMessageReceived(FighterMessage obj){
      selectedFighter.Attack = obj.fighterInfo.Attack;
      selectedFighter.MaxHealth = obj.fighterInfo.MaxHealth;
      selectedFighter.Speed = obj.fighterInfo.Speed;
      selectedFighter.Alignment = obj.fighterInfo.Alignment;
   }

   public void SelectFighter(){
      fighters[incrementor++] = selectedFighter;
   }

   public void UnselectFighter(){
      fighters[incrementor--] = null;
   }
}