using System;
using Meta.Interfaces;
using Meta.Seeds;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UDP;
[JsonObject]
public interface IItem{
    public string Name{ get; set; }
}