using UnityEngine;
using System.Collections;

/// <summary>
/// This script stops the the animated solution.
/// </summary>
public class Pause : MonoBehaviour {

	// The GameObject variable |solver| contains the script to solve the Rubik's Cube.
	public GameObject solver;

	/// <summary>
	/// Calls a method in the solver script attached to |solver| to stop the current animated solution.
	/// </summary>
	public void Freeze () {
		solver.GetComponent<Solver> ().StopSolve ();
	}
}
