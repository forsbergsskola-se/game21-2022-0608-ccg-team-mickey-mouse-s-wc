using System;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

public class WaitForDramaticEffectCommand : ICommand{
    private int duration;
    Timer timer = new();


    public WaitForDramaticEffectCommand(int duration){
        this.duration = duration;
    }
    
    //TODO: WIP, currently waiting in the task not for the task, command pattern needs to be async for that.

    public async void Execute(){
        await Wait();
    }

    private async Task Wait(){
        timer.Elapsed += CountDown;
        timer.Interval = 1000;
        timer.Start();
    }

    private void CountDown(object sender, EventArgs e){
        if (duration == 0)
        {
            timer.Stop();

        }
        else if(duration > 0)
        {
            duration--;
            Debug.Log(duration);
        }
    }


    public void Undo(){
        throw new NotImplementedException();
    }
}