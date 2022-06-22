using System;
using System.Threading.Tasks;
using UnityEngine;

public class WaitForDramaticEffectCommand : ICommand{
    private int duration;

    public WaitForDramaticEffectCommand(int duration){
        this.duration = duration;
    }

    public async Task ExecuteAsync(){
        await WaitForSecondsAsync();
    }

    private async Task WaitForSecondsAsync(){
        var startTime = Time.time;
        var desiredTime = startTime + duration;
        await Task.CompletedTask; //TODO: implement actual timer without freesing..?
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}