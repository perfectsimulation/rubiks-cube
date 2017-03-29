using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Load : MonoBehaviour {

	#region globalVariables
	public GameObject save;
	public GameObject solver;
	public GameObject hint;

	public GameObject cube00;
	public GameObject cube01;
	public GameObject cube02;
	public GameObject cube03;
	public GameObject cube04;
	public GameObject cube05;
	public GameObject cube06;
	public GameObject cube07;
	public GameObject cube08;
	public GameObject cube09;
	public GameObject cube10;
	public GameObject cube11;
	public GameObject cube12;
	public GameObject cube13;
	public GameObject cube14;
	public GameObject cube15;
	public GameObject cube16;
	public GameObject cube17;
	public GameObject cube18;
	public GameObject cube19;
	public GameObject cube20;
	public GameObject cube21;
	public GameObject cube22;
	public GameObject cube23;
	public GameObject cube24;
	public GameObject cube25;
	public GameObject cube26;

	private string fileNumber;
	private List<GameObject> allCubes  = new List<GameObject> ();
	#endregion

	void Start () {
		fileNumber = this.name [4].ToString ();
		allCubes.Add (cube00);
		allCubes.Add (cube01);
		allCubes.Add (cube02);
		allCubes.Add (cube03);
		allCubes.Add (cube04);
		allCubes.Add (cube05);
		allCubes.Add (cube06);
		allCubes.Add (cube07);
		allCubes.Add (cube08);
		allCubes.Add (cube09);
		allCubes.Add (cube10);
		allCubes.Add (cube11);
		allCubes.Add (cube12);
		allCubes.Add (cube13);
		allCubes.Add (cube14);
		allCubes.Add (cube15);
		allCubes.Add (cube16);
		allCubes.Add (cube17);
		allCubes.Add (cube18);
		allCubes.Add (cube19);
		allCubes.Add (cube20);
		allCubes.Add (cube21);
		allCubes.Add (cube22);
		allCubes.Add (cube23);
		allCubes.Add (cube24);
		allCubes.Add (cube25);
		allCubes.Add (cube26);
	}

	public void LoadSignal () {
		StartCoroutine (LoadState ());
	}

	IEnumerator LoadState () {

		bool turning = solver.GetComponent<Solver> ().IsTurning ();
		bool solving = solver.GetComponent<Solver> ().IsSolving ();
		while (turning || solving) {
			yield return null;
		}
		bool hinting = hint.GetComponent<Hint> ().IsHinting ();
		if (hinting) {
			hint.GetComponent<Hint> ().ShowOrHide ();
		}
		List<Quaternion> load = save.GetComponent<Save> ().GetCubesRotations ();
		int index = 0;
		foreach (Quaternion rot in load) {
			GameObject cubeID = allCubes [index];
			cubeID.transform.rotation = rot;
			index++;
		}
		index = 0;
		print ("Loaded State " + fileNumber);
	}

}
