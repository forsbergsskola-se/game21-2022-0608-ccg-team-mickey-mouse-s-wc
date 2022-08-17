using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class StrikeCommand : ICommand{
    private FighterInfo target, striker;

    private float multiplier = 1f;
    

    public StrikeCommand(FighterInfo target, FighterInfo striker){
        this.target = target;
        this.striker = striker;
    }

    public Task ExecuteAsync(){
        Strike();
        return Task.CompletedTask;
    }

    private void Strike(){
        var damageDealt = Math.Clamp(striker.Attack * CheckAlignment(striker, target), 0f, target.MaxHealth);
        target.MaxHealth -= damageDealt;
        FighterStrikeMessage strikeMessage = new(){
            DamageDealt = damageDealt,
            StrikerAlignment = striker.Alignment,
            StrikerRarity = striker.Rarity,
            TargetID = target.ID, 
            SelfID = striker.ID, 
            TargetHealth = target.MaxHealth
        };
        Broker.InvokeSubscribers(typeof(FighterStrikeMessage), strikeMessage);
    }

    private float CheckAlignment(FighterInfo striker, FighterInfo target){
        multiplier = 1;
        var strengths = new Dictionary<Alignment, Alignment>{
            [Alignment.Scissors] = Alignment.Paper,
            [Alignment.Rock] = Alignment.Scissors,
            [Alignment.Paper] = Alignment.Rock
        };
        if(strengths[striker.Alignment] == target.Alignment)
            return multiplier += .5f;
        if(strengths[target.Alignment] == striker.Alignment)
            return multiplier -= .5f;
        return multiplier;
    }
}