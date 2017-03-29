using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	public void StartGame () {
		SceneManager.LoadScene ("_main");
	}

	public void StartTutorial () {
		SceneManager.LoadScene ("_tutorial");
	}
}
