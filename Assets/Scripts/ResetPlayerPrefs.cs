using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResetPlayerPrefs : MonoBehaviour{

	public CoinInfoSet coinInfoSet;
	public void ResetAll () {
		PlayerPrefs.DeleteAll();
		coinInfoSet.resetAllCoins();
		PlayerPrefs.SetInt("resetCoinInfoAlready", 1);
	}


}	

