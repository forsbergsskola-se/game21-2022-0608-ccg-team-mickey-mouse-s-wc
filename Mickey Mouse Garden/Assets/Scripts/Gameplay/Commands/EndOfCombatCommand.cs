using UnityEngine;

public class EndOfCombatCommand : ICommand{
    private int playerTeamIncrementor;
    private int enemyTeamIncrementor;
    public EndOfCombatCommand(int playerTeamIncrementor, int enemyTeamIncrementor){
        this.playerTeamIncrementor = playerTeamIncrementor;
        this.enemyTeamIncrementor = enemyTeamIncrementor;
    }

    public void Execute(){
        if (playerTeamIncrementor > 2){
            //TODO: celebrate the win
            Debug.Log("player wins!");
        }

        if (enemyTeamIncrementor > 2){
            //TODO: cry about defeat
            Debug.Log("enemy wins!");
        }
    }

    public void Undo(){
        throw new System.NotImplementedException();
    }
}