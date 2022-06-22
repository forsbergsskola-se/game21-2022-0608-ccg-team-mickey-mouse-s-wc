using System.Collections.Generic;
using UnityEngine;

public interface ICommand{
    public void Execute();
    public void Undo();
}
public class Executor : MonoBehaviour{
    private Queue<ICommand> queue = new Queue<ICommand>();
    private Stack<ICommand> undo = new Stack<ICommand>();

    public void Enqueue(ICommand command){
        queue.Enqueue(command);
    }

    private void Update(){
        while (queue.Count > 0){
            var command = queue.Dequeue();
            command.Execute();
            undo.Push(command);
        }
    }
}
