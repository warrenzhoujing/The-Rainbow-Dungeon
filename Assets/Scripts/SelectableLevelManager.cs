using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableLevelManager : MonoBehaviour {

	public GameObject[] SelectableLevels;

	int count;

	void Start () {
		count = 0;
	}

	void Update () {
		if (count < 0) {
			count = SelectableLevels.Length + count;
		}

		if (count == SelectableLevels.Length) {
			count = 0;
		}

		foreach (GameObject sl in SelectableLevels) {
			sl.SetActive(false);
		}

		SelectableLevels[count].SetActive(true);
	}

	public void NextSelectableLevel() {
		count += 1;
	}

	public void PreviousSelectableLevel() {
		count -= 1;
	}
}
