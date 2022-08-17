using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ICommand{
    public Task ExecuteAsync();
}
public class Executor : MonoBehaviour{
    private Queue<ICommand> queue = new();
    public void Enqueue(ICommand command){
        queue.Enqueue(command);
    }

    private async void Update(){
        await ProcessCommandsAsync();
    }
    
    private async Task ProcessCommandsAsync(){
        while(queue.Count > 0){
            var command = queue.Dequeue();
            await command.ExecuteAsync();
        }
    }
}
