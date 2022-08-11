using System.Collections;
using System.Collections.Generic;
using Meta.ShoppingSystem;
using UnityEngine;
[CreateAssetMenu(fileName = "New Seed Library", menuName = "Library/Seeds")]
public class SeedConfigLibrary :  ConfigLibrary<SeedConfig>
{ public override List<SeedConfig> itemConfigs{ get; set; } = new List<SeedConfig> ();
}
