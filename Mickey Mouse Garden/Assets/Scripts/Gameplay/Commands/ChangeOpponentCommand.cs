using System;

public class ChangeOpponentCommand : ICommand{
    private CombatController combatController;

    public ChangeOpponentCommand(CombatController combatController){
        this.combatController = combatController;
    }

    public void Execute(){
        combatController.NextFighter();
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}