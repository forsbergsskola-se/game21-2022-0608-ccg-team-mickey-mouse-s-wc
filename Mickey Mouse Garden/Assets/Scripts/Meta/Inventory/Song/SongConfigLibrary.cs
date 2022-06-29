using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Song Library", menuName = "Library/Songs")]
public class SongConfigLibrary : ScriptableObject{
    public Dictionary<string,SongConfig> songConfigs;

    public SongConfig GetSong(string songName){
        return songConfigs[songName];
    }
}
