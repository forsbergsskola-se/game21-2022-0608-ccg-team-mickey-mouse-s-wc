using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Timer = System.Threading.Timer;

public class LevelController : MonoBehaviour{
	[SerializeField] private float opponentLevel, playerLevel, levelMultiplier;
	// [SerializeField] private Player player;
	private int  reward;
	private void Start() {
		reward = (int)(opponentLevel / playerLevel * levelMultiplier * opponentLevel);
		Debug.Log(reward);
	}

	private void Update(){


	}
}