using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInfoSet : CoinInfo {

	public string[] levels;
	public int[] numberOfCoinsInLevel;
	public bool resetCoinInfo;
	CoinManager cm;

	void Start () {
		if (resetCoinInfo && !(PlayerPrefs.GetInt("resetCoinInfoAlready", 0) == 1)) {
			PlayerPrefs.DeleteAll();
			resetAllCoins();
			PlayerPrefs.SetInt("resetCoinInfoAlready", 1);
		}
	}

	public void resetAllCoins() {
		for (int index = 0; index < levels.Length; index++) {
    		totalCoinsForLevel.Add(levels[index], numberOfCoinsInLevel[index]);
		}

		Debug.Log("g");

		for (int g = 0; g < levels.Length; g++) {
			Debug.Log(levels[g]);
			accquiredCoinsForLevel.Add(levels[g], 0);
		}
		
		PlayerPrefs.SetString("totalCoinsForLevel", DictToString(totalCoinsForLevel));
		PlayerPrefs.SetString("accquiredCoinsForLevel", DictToString(accquiredCoinsForLevel));
	}

	public void setAcquiredCoins(string levelcoins) {
		if (levelcoins.Split('-')[1] == "CoinManager.coins"){
			accquiredCoinsForLevel[levelcoins.Split('-')[0]] = GameObject.Find("GameManager").GetComponent<CoinManager>().coins;
		} else {
			accquiredCoinsForLevel[levelcoins.Split('-')[0]] = int.Parse(levelcoins.Split('-')[1]);
		}

		PlayerPrefs.SetString("accquiredCoinsForLevel", DictToString(accquiredCoinsForLevel));
	}

	string DictToString (Dictionary<string, int> d) {
		string str = "";

		foreach (KeyValuePair<string, int> kvp in d) {
			str += kvp.Key + "-" + kvp.Value.ToString() + "+";
		}

		return str;
	}

	Dictionary<string, int> StringToDict (string str) {
		Dictionary<string, int> d = new Dictionary<string, int>(){};

		string[] new_str = str.Split('+');

		foreach (string s in new_str) {
			if (s.Length > 0) {
				d.Add(s.Split('-')[0], int.Parse(s.Split('-')[1]));
			}	
		}

		return d;
	}

}
