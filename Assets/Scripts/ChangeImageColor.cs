using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageColor : MonoBehaviour {

	public Color[] colors;
	public Image image;
	public float changeColorDelay;

	int colorCount = 0;
	float delayCount;

	void Start () {
		colorCount = 0;
		delayCount = changeColorDelay;
		image.color = colors[0];
	}

	void Update () {
		if (delayCount < 0) {
			if (colorCount > colors.Length - 1) {
				colorCount = 0;
			}

			image.color = colors[colorCount];

			colorCount ++;
			delayCount = changeColorDelay;
		}
		
		delayCount -= 0.1f;
	}

}
