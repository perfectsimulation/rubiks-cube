using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmsSummary : MonoBehaviour {

	public GameObject[] algorithmPanel;
	public GameObject[] panelMain;
	public GameObject[] algorithm1;
	public GameObject[] algorithm2;
	public GameObject[] algorithm3;
	public GameObject[] algorithm4;
	public GameObject[] algorithm5;
	public GameObject[] algorithm6;

	void Start () {
		HideAlgoPanel ();
	}

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

	public void HideAlgoPanel () {
		foreach (GameObject g in algorithmPanel) {
			g.SetActive (false);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}

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

	public void Algorithm1 () {
		foreach (GameObject g in algorithm1) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}
	public void Algorithm2 () {
		foreach (GameObject g in algorithm2) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}
	public void Algorithm3 () {
		foreach (GameObject g in algorithm3) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}
	public void Algorithm4 () {
		foreach (GameObject g in algorithm4) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}
	public void Algorithm5 () {
		foreach (GameObject g in algorithm5) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}
	public void Algorithm6 () {
		foreach (GameObject g in algorithm6) {
			g.SetActive (true);
		}
		foreach (GameObject g in panelMain) {
			g.SetActive (false);
		}
	}

}
