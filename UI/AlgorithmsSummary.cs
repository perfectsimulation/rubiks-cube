using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class contains methods to show/hide a panel in the UI with a summary of all the algorithms
/// necessary to solve a Rubik's Cube.
/// </summary>
public class AlgorithmsSummary : MonoBehaviour {

	// The GameObject[] variable |algorithmPanel| contains all background UI elements in the panel. These
	// UI elements should always be visible when the panel is active. It also contains the parent
	// GameObject holding all the elements of every page of the panel.
	public GameObject[] algorithmPanel;

	// The GameObject[] variable |panelMain| contains the UI elements for the main menu of the algorithm panel.
	// It contains the buttons to show the algorithms for the six phases of the solution, as well as sprites
	// representing the various phases.
	public GameObject[] panelMain;

	// The following GameObject[] variables contain the UI elements for the algorithm summary of their
	// respective phases. Each contains Sprite objects and Text objects to show the key configurations
	// to look out for during that phase, as well as the algorithms to solve them.
	public GameObject[] algorithm1;
	public GameObject[] algorithm2;
	public GameObject[] algorithm3;
	public GameObject[] algorithm4;
	public GameObject[] algorithm5;
	public GameObject[] algorithm6;

	/// <summary>
	/// Start this instance by calling a method to turn off all algorithm panel GameObjects.
	/// </summary>
	void Start () {
		HideAlgoPanel ();
	}

	/// <summary>
	/// Shows the algorithm panel. Called when the user presses a button in the UI.
	/// </summary>
	public void ShowAlgoPanel () {
		foreach (GameObject g in algorithmPanel) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (true);
		}
		foreach (GameObject g in algorithm1) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm2) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm3) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm4) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm5) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm6) {
			g.SetActive (false);
		}
	}

	/// <summary>
	/// Hides the algorithm panel.
	/// </summary>
	public void HideAlgoPanel () {
		foreach (GameObject g in algorithmPanel) {
			g.SetActive (false);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}

	/// <summary>
	/// Go back to panel main menu.
	/// </summary>
	public void BackToPanelMain () {
		foreach (GameObject g in panelMain) {
			g.SetActive (true);
		}
		foreach (GameObject g in algorithm1) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm2) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm3) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm4) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm5) {
			g.SetActive (false);
		}
		foreach (GameObject g in algorithm6) {
			g.SetActive (false);
		}
	}

	/// <summary>
	/// Shows the algorithms of the first phase.
	/// </summary>
	public void Algorithm1 () {
		foreach (GameObject g in algorithm1) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}

	/// <summary>
	/// Shows the algorithms of the second phase.
	/// </summary>
	public void Algorithm2 () {
		foreach (GameObject g in algorithm2) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}

	/// <summary>
	/// Shows the algorithms of the third phase.
	/// </summary>
	public void Algorithm3 () {
		foreach (GameObject g in algorithm3) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}

	/// <summary>
	/// Shows the algorithms of the fourth phase.
	/// </summary>
	public void Algorithm4 () {
		foreach (GameObject g in algorithm4) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}

	/// <summary>
	/// Shows the algorithms of the fifth phase.
	/// </summary>
	public void Algorithm5 () {
		foreach (GameObject g in algorithm5) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}

	/// <summary>
	/// Shows the algorithms of the sixth phase.
	/// </summary>
	public void Algorithm6 () {
		foreach (GameObject g in algorithm6) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}

}
