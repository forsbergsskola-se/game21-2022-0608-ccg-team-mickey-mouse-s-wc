using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class)]
public class CustomComponentAttribute : Attribute
{
    public string Name{ get; private set; }
    public string Description{ get; private set; }
    /// <summary>
    /// "Used to communicate with the designers about the state of the Script, example is In Progress"
    /// </summary>
    public CustomComponentAttributeType State;
    public CustomComponentAttribute(string name){
        Name = name;
    }
    public CustomComponentAttribute(string name, string description) : this(name){
        Description = description;
    }
    public CustomComponentAttribute(string name, string description, CustomComponentAttributeType state) : this(name,description){
        State = state;
        
    }
   
}
