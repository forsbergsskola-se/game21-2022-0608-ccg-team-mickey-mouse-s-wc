using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Seeds;
using TMPro;
using UnityEngine;

public class ItemPriceList : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI commonSeedPriceText;
    [SerializeField] 
    private TextMeshProUGUI rareSeedPriceText;
    [SerializeField] 
    private TextMeshProUGUI epicSeedPriceText;
    [SerializeField] 
    private TextMeshProUGUI legendarySeedPriceText;
    

    [SerializeField] private float commonSeedPriceValue;
    [SerializeField] private float rareSeedPriceValue;
    [SerializeField] private float epicSeedPriceValue;
    [SerializeField] private float legendarySeedPriceValue;

    //public Seed seed;

    private void SetPrice(float price)
    {
        this.commonSeedPriceValue = price;
        this.commonSeedPriceText.text = price.ToString();
        
        this.rareSeedPriceValue = price;
        this.rareSeedPriceText.text = price.ToString();
        
        this.epicSeedPriceValue = price;
        this.epicSeedPriceText.text = price.ToString();
        
        this.legendarySeedPriceValue = price;
        this.legendarySeedPriceText.text = price.ToString();
    }

    private void Awake(){
        // if (seed.rarity == Rarity.Common){
        //     
        // }
        // if (seed.rarity == Rarity.Rare){
        //     
        // }
        // if (seed.rarity == Rarity.Legendary){
        //     
        // }else{}
        //SetPrice(commonSeedPriceValue);
        //SetPrice(rareSeedPriceValue);
        //SetPrice(epicSeedPriceValue);
        //SetPrice(legendarySeedPriceValue);
        commonSeedPriceText.text = commonSeedPriceValue.ToString();
        rareSeedPriceText.text = rareSeedPriceValue.ToString();
        epicSeedPriceText.text = epicSeedPriceValue.ToString();
        legendarySeedPriceText.text = legendarySeedPriceValue.ToString();

    }
}


