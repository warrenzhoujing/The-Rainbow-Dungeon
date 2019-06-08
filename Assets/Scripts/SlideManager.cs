using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlideManager : MonoBehaviour {

	public GameObject[] slides;
	int count;
	

	void Start () {
		count = 0;
	}
	
	void Update () {

		GameObject slide = slides[count % slides.Length];
		if (!slide.activeInHierarchy){
			slide.SetActive(true);

			foreach(GameObject aslide in slides) {
				if (aslide != slide) {
					aslide.SetActive(false);
				}
			}
		}
	}

	public void NextSlide () {
		count += 1;
	}

	public void SwitchToMainMenu () {
		SceneManager.LoadScene("Main Menu");
	}
}
