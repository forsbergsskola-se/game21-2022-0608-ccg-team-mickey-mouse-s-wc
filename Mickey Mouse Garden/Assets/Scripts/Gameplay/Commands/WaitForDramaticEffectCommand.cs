using System;
using System.Threading.Tasks;
using UnityEngine;

public class WaitForDramaticEffectCommand : ICommand{
    private int duration = 5;
    
    //TODO: WIP, currently waiting in the task not for the task, command pattern needs to be async for that.

    public void Execute(){
        Wait();
    }

    private void Wait(){
    var t = Task.Run(async delegate{
        await Task.Delay(10000);
        Task.Yield();
        Debug.Log("waited");
    });
    }
    
    
    public void Undo(){
        throw new NotImplementedException();
    }
}