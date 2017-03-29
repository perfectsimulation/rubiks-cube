using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject solver;

	public void Freeze () {
		solver.GetComponent<Solver> ().StopSolve ();
	}
}
