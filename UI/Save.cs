using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class contains methods to save a configuration of the Rubik's Cube.
/// </summary>
public class Save : MonoBehaviour {

	#region Properties

	// The GameObject variable |solver| contains the script to solve the Rubik's Cube. It is used in
	// this script to check if an animated solution is active. The solution must be paused for successful
	// loading.
	public GameObject solver;

	// The GameObject variable |hint| contains the script to display an animated hint of the rotation
	// the user should perform. The hint will be deactivated prior to loading.
	public GameObject hint;

	// The following GameObject variables beginning with "cube" are the pieces of the Rubik's Cube.
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

	// The string variable |fileNumber| is a reference to the load file.
	private string fileNumber;

	// The List<GameObject> variable |allCubes| contains all the pieces of the Rubik's CUbe.
	private List<GameObject> allCubes  = new List<GameObject> ();

	// The List<Quaternion> variable |allCubesRotations| contains the rotations of each piece.
	private List<Quaternion> allCubesRotations = new List<Quaternion> ();
	#endregion

	/// <summary>
	/// Start this instance by populating |allCubes| and setting the name of the save file.
	/// </summary>
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

	/// <summary>
	/// Gets all the pieces of the Rubik's Cube.
	/// </summary>
	/// <returns>The cubes.</returns>
	List<GameObject> GetCubes () {
		return allCubes;
	}

	/// <summary>
	/// Starts the coroutine to save the current configuration of the Rubik's Cube.
	/// </summary>
	public void SaveSignal () {
		StartCoroutine (SaveState ());
	}

	/// <summary>
	/// Saves the current configuration of the Rubik's Cube.
	/// </summary>
	IEnumerator SaveState () {
		bool turning = solver.GetComponent<Solver> ().IsTurning ();
		bool solving = solver.GetComponent<Solver> ().IsSolving ();

		// There can be no active rotation or solution for the configuration to save.
		while (turning || solving) {
			yield return null;
		}

		// If there is an active hint animation, turn it off before loading.
		bool hinting = hint.GetComponent<Hint> ().IsHinting ();
		if (hinting) {
			hint.GetComponent<Hint> ().ShowOrHide ();
		}
		allCubesRotations.Clear ();
		allCubes = GetCubes ();

		// Populates |allCubesRotations|.
		foreach (GameObject cube in allCubes) {
			Quaternion rot = cube.transform.rotation;
			allCubesRotations.Add (rot);
		}
		print ("Saved State " + fileNumber);
	}

	/// <summary>
	/// Gets the rotations for each piece of the saved configuration.
	/// </summary>
	/// <returns>The rotations for each piece of the saved configuration.</returns>
	public List<Quaternion> GetCubesRotations () {
		return allCubesRotations;
	}

}
