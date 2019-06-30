using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableLevel : MonoBehaviour {

	public Text CoinText;

	void Start () {
		Dictionary<string, int> accquiredCoinsForLevel = StringToDict(PlayerPrefs.GetString("accquiredCoinsForLevel"));
		Dictionary<string, int> totalCoinsForLevel = StringToDict(PlayerPrefs.GetString("totalCoinsForLevel"));

		foreach (KeyValuePair<string, int> kvp in accquiredCoinsForLevel) {
			Debug.Log(kvp.Key + " " + kvp.Value.ToString());
		}

		CoinText.text = "Coins: " + accquiredCoinsForLevel[gameObject.name].ToString() + "/" + totalCoinsForLevel[gameObject.name].ToString();
		
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
