using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShop : MonoBehaviour{
    private Transform container;
    private Transform shopItemTemplate;

    private void Awake(){
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start(){
        CreateItemButton("Seed", Item.GetCost(Item.ItemType.Seed), 0);
    }

    private void CreateItemButton(string itemName, int itemCost, int positionIndex){
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        
        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
        
        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        
    }
}
