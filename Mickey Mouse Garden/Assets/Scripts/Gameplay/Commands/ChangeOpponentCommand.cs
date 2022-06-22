using System;
using System.Threading.Tasks;

public class ChangeOpponentCommand : ICommand{
    private CombatController combatController;

    public ChangeOpponentCommand(CombatController combatController){
        this.combatController = combatController;
    }
    public Task ExecuteAsync(){
        combatController.NextFighter();
        return Task.CompletedTask;
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}