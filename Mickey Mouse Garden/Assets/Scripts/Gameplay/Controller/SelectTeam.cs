using UnityEngine;

public class SelectTeam : MonoBehaviour{
   private FighterInfo hoveredFighter;
   private FighterInfo[] fighters = new FighterInfo[3];
   private int incrementor;

   private void Start(){
      Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
   }

   private void OnFighterMessageReceived(FighterMessage obj){ //everytime you hover a card this is called
      hoveredFighter = obj.fighterInfo;
   }

   public void SelectFighter(){
      fighters[incrementor++] = hoveredFighter;
   }

   public void ClearFighters(){
      fighters = new FighterInfo[3];
   }
}