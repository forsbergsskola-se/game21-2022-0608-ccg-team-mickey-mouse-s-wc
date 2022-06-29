using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Player Wallet", menuName = "Inventory/PlayerWallet")]
public class PlayerWalletSO : ScriptableObject
{
   public PlayerWallet playerWallet{ get; set; }
}
