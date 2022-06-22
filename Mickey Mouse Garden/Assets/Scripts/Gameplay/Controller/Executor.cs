using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ICommand{
    //public void Execute();
    public Task ExecuteAsync();
    public void Undo();
}
public class Executor : MonoBehaviour{
    private Queue<ICommand> queue = new Queue<ICommand>();
    private Stack<ICommand> undo = new Stack<ICommand>();

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
            undo.Push(command);
        }
    }
}
