using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUIMessage<T>: IMessage
{
    public List<T> Content{ get; }
    public UpdateUIMessage(List<T> content)
    {
        Content = content;
    }
}
