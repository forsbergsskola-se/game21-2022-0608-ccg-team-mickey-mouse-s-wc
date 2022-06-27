using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Seeds;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SeedStoreList : MonoBehaviour{ 
    public ScriptableObject commonSeed;
    public ScriptableObject rareSeed;
    public ScriptableObject epicSeed;
    public ScriptableObject legendarySeed;
    [SerializeField] 
    private TextMeshProUGUI commonSeedPriceText;
    [SerializeField] 
    private TextMeshProUGUI rareSeedPriceText;
    [SerializeField] 
    private TextMeshProUGUI epicSeedPriceText;
    [SerializeField] 
    private TextMeshProUGUI legendarySeedPriceText;

    
}
