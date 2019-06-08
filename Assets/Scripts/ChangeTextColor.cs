using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour {

	public Color[] colors;
	public Text text;
	public float changeColorDelay;

	int colorCount = 0;
	float delayCount;

	void Start () {
		colorCount = 0;
		delayCount = changeColorDelay;
		text.color = colors[0];
	}

	void Update () {
		if (delayCount < 0) {
			if (colorCount > colors.Length - 1) {
				colorCount = 0;
			}

			text.color = colors[colorCount];

			colorCount ++;
			delayCount = changeColorDelay;
		}
		
		delayCount -= 0.1f;
	}

}
