using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortInventoryButton : MonoBehaviour
{
    public void SortInventoryByRarity(){
        new SortCardInventoryByRarityMessage().Invoke();
    }
    public void SortInventoryByAlignment(){
        new SortCardInventoryByAlignmentMessage().Invoke();
    }
}
