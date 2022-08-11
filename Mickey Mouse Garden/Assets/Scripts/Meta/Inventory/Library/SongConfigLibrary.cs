using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Song Library", menuName = "Library/Songs")]
public class SongConfigLibrary : ConfigLibrary<SongConfig>{
    public override List<SongConfig>  itemConfigs{ get; set; } = new List<SongConfig> ();
}
