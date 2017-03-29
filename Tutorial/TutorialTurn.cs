using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class provides methods for the user to apply rotations to the Rubik's Cube.
/// </summary>
public class TutorialTurn : MonoBehaviour {
	
	#region Properties

	// The GameObject variable |solver| contains the script to scramble and solve the Rubik's Cube.
	public GameObject solver;

	// The int variable |faceConfig| represents the current F side of the Rubik's Cube according to
	// the camera view.
	private int faceConfig;

	// The int variable |sunnySideUp| is used as a reference to the current side of the Rubik's Cube that
	// is facing up. Its value will either be 1 for the White side up, and -1 for the Yellow side up.
	private int sunnySideUp;

	// The following bool variables are used with GetButtonDown methods to determine which rotation
	// the user inputted.
	private bool invert;
	private bool press_F;
	private bool press_D;
	private bool press_R;
	private bool press_U;
	private bool press_L;
	private bool press_B;

	// The following bool variables are used to signal that a rotation should be made.
	private bool do_F  = false;
	private bool do_Fi = false;
	private bool do_D  = false;
	private bool do_Di = false;
	private bool do_R  = false;
	private bool do_Ri = false;
	private bool do_U  = false;
	private bool do_Ui = false;
	private bool do_L  = false;
	private bool do_Li = false;
	private bool do_B  = false;
	private bool do_Bi = false;

	// The following int variables represent the rotations of the Rubik's Cube.
	private int f;
	private int fi;
	private int d;
	private int di;
	private int r;
	private int ri;
	private int u;
	private int ui;
	private int l;
	private int li;
	private int b;
	private int bi;

	#endregion

	/// <summary>
	/// Update this instance by checking for pressed buttons and reconfiguring the rotation int variables
	/// when the camera view changes.
	/// </summary>
	void Update () {
		sunnySideUp = solver.GetComponent<TutorialSolver> ().GetUpFace ();
		faceConfig = this.GetComponent<Tutorial> ().GetFaceConfig ();
		ConfigureMoves (faceConfig);
		#region getButtonDown
		invert = Input.GetButton ("ccw");
		press_F  = Input.GetButtonDown ("F");
		press_D  = Input.GetButtonDown ("D");
		press_R  = Input.GetButtonDown ("R");
		press_U  = Input.GetButtonDown ("U");
		press_L  = Input.GetButtonDown ("L");
		press_B  = Input.GetButtonDown ("B");
		#endregion

		// only one turn occurs if multiple buttons are pressed simultaneously
		#region ifButtonPressed
		if (press_F) {
			if (invert) {
				do_Fi = true;
				StartCoroutine (Turn ());
			} else {
				do_F = true;
				StartCoroutine (Turn ());
			}
		} else if (press_D) {
			if (sunnySideUp > 0) {
				if (invert) {
					do_Di = true;
					StartCoroutine (Turn ());
				} else {
					do_D = true;
					StartCoroutine (Turn ());
				}
			} else if (sunnySideUp < 0) {
				if (invert) {
					do_Ui = true;
					StartCoroutine (Turn ());
				} else {
					do_U = true;
					StartCoroutine (Turn ());
				}
			}
		} else if (press_R) {
			if (invert) {
				do_Ri = true;
				StartCoroutine (Turn ());
			} else {
				do_R = true;
				StartCoroutine (Turn ());
			}
		} else if (press_U) {
			if (sunnySideUp > 0) {
				if (invert) {
					do_Ui = true;
					StartCoroutine (Turn ());
				} else {
					do_U = true;
					StartCoroutine (Turn ());
				}
			} else if (sunnySideUp < 0) {
				if (invert) {
					do_Di = true;
					StartCoroutine (Turn ());
				} else {
					do_D = true;
					StartCoroutine (Turn ());
				}
			}
		} else if (press_L) {
			if (invert) {
				do_Li = true;
				StartCoroutine (Turn ());
			} else {
				do_L = true;
				StartCoroutine (Turn ());
			}
		} else if (press_B) {
			if (invert) {
				do_Bi = true;
				StartCoroutine (Turn ());
			} else {
				do_B = true;
				StartCoroutine (Turn ());
			}
		}
		#endregion
	}

	/// <summary>
	/// Performs a rotation of the Rubik's Cube.
	/// </summary>
	IEnumerator Turn () {
		while (solver.GetComponent<TutorialSolver> ().IsTurning ()) {
			CancelTurns ();
			yield return null;
		}
		PressManager ();

		if (do_F) {
			List<int> turn = new List<int> ();
			turn.Add (f);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_F = false;
		}
		if (do_Fi) {
			List<int> turn = new List<int> ();
			turn.Add (fi);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_Fi = false;
		}
		if (do_D) {
			List<int> turn = new List<int> ();
			turn.Add (d);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_D = false;
		}
		if (do_Di) {
			List<int> turn = new List<int> ();
			turn.Add (di);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_Di = false;
		}
		if (do_R) {
			List<int> turn = new List<int> ();
			turn.Add (r);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_R = false;
		}
		if (do_Ri) {
			List<int> turn = new List<int> ();
			turn.Add (ri);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_Ri = false;
		}
		if (do_U) {
			List<int> turn = new List<int> ();
			turn.Add (u);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_U = false;
		}
		if (do_Ui) {
			List<int> turn = new List<int> ();
			turn.Add (ui);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_Ui = false;
		}
		if (do_L) {
			List<int> turn = new List<int> ();
			turn.Add (l);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_L = false;
		}
		if (do_Li) {
			List<int> turn = new List<int> ();
			turn.Add (li);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_Li = false;
		}
		if (do_B) {
			List<int> turn = new List<int> ();
			turn.Add (b);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_B = false;
		}
		if (do_Bi) {
			List<int> turn = new List<int> ();
			turn.Add (bi);
			StartCoroutine (solver.GetComponent<TutorialSolver> ().PerformAlgorithm (turn));
			do_Bi = false;
		}
	}

	/// <summary>
	/// Configures the rotation int variables according to the camera view.
	/// </summary>
	/// <param name="faceConfig">Face config.</param>
	void ConfigureMoves (int faceConfig) {
		switch (faceConfig) {
		case 0:
			f  = 6;
			fi = 7;
			d  = 11;
			di = 10;
			r  = 8;
			ri = 9;
			u  = 0;
			ui = 1;
			l  = 4;
			li = 5;
			b  = 2;
			bi = 3;
			break;
		case 1:
			f  = 6;
			fi = 7;
			d  = 11;
			di = 10;
			r  = 4;
			ri = 5;
			u  = 0;
			ui = 1;
			l  = 8;
			li = 9;
			b  = 2;
			bi = 3;
			break;
		case 2:
			f  = 8;
			fi = 9;
			d  = 11;
			di = 10;
			r  = 2;
			ri = 3;
			u  = 0;
			ui = 1;
			l  = 6;
			li = 7;
			b  = 4;
			bi = 5;
			break;
		case 3:
			f  = 4;
			fi = 5;
			d  = 11;
			di = 10;
			r  = 2;
			ri = 3;
			u  = 0;
			ui = 1;
			l  = 6;
			li = 7;
			b  = 8;
			bi = 9;
			break;
		case 4:
			f  = 2;
			fi = 3;
			d  = 11;
			di = 10;
			r  = 4;
			ri = 5;
			u  = 0;
			ui = 1;
			l  = 8;
			li = 9;
			b  = 6;
			bi = 7;
			break;
		case 5:
			f  = 2;
			fi = 3;
			d  = 11;
			di = 10;
			r  = 8;
			ri = 9;
			u  = 0;
			ui = 1;
			l  = 4;
			li = 5;
			b  = 6;
			bi = 7;
			break;
		case 6:
			f  = 4;
			fi = 5;
			d  = 11;
			di = 10;
			r  = 6;
			ri = 7;
			u  = 0;
			ui = 1;
			l  = 2;
			li = 3;
			b  = 8;
			bi = 9;
			break;
		case 7:
			f  = 8;
			fi = 9;
			d  = 11;
			di = 10;
			r  = 6;
			ri = 7;
			u  = 0;
			ui = 1;
			l  = 2;
			li = 3;
			b  = 4;
			bi = 5;
			break;
		}
	}





	/// <summary>
	/// Manages button presses by the user to negate simultaneous button presses.
	/// </summary>
	void PressManager () {
		
		int a = do_F ? 1 : 0;
		int b = do_Fi ? 1 : 0;
		int c = do_D ? 1 : 0;
		int d = do_Di ? 1 : 0;
		int e = do_R ? 1 : 0;
		int f = do_Ri ? 1 : 0;
		int g = do_U ? 1 : 0;
		int h = do_Ui ? 1 : 0;
		int i = do_L ? 1 : 0;
		int j = do_Li ? 1 : 0;
		int k = do_B ? 1 : 0;
		int l = do_Bi ? 1 : 0;

		int sum = a + b + c + d + e + f + g + h + i + j + k + l;
		if (sum > 1) {
			do_F  = false;
			do_Fi = false;
			do_D  = false;
			do_Di = false;
			do_R  = false;
			do_Ri = false;
			do_U  = false;
			do_Ui = false;
			do_L  = false;
			do_Li = false;
			do_B  = false;
			do_Bi = false;
		}
	}

	/// <summary>
	/// Cancels all rotations.
	/// </summary>
	void CancelTurns () {
		do_F  = false;
		do_Fi = false;
		do_D  = false;
		do_Di = false;
		do_R  = false;
		do_Ri = false;
		do_U  = false;
		do_Ui = false;
		do_L  = false;
		do_Li = false;
		do_B  = false;
		do_Bi = false;
	}

}
