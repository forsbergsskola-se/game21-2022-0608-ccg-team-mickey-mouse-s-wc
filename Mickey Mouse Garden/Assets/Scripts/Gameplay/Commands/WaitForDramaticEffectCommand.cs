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
    }

    public void Undo(){
        throw new NotImplementedException();
    }
}