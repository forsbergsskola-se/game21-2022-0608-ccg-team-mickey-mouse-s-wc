using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Song Config", menuName = "Configs/Song")]
public class SongConfig : ScriptableObject{
    public string songID;
    string theme = "MetaMusic";
    public int parameter;
}
