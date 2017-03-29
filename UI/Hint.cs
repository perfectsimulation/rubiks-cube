using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// This class contains all the methods used to show/hide animations of the next rotation the user
/// should make to solve the Rubik's Cube.
/// </summary>
/// 
/// <remarks>
/// This script is incomplete. It does not work if the user has flipped the Rubik's Cube to view the
/// Yellow side up. To fix this script, the transforms of the guide GameObjects must be changed with each
/// flip of the Rubik's Cube.
/// <remarks>
public class Hint : MonoBehaviour {

	#region Properties

	// The Button variable |hint| is the Button this MonoBehavior is attached to.
	public Button hint;

	// The bool variable |hide| is true when all hint animations are hidden.
	private bool hide = true;

	// The GameObject variable |solver| contains the script to solve the Rubik's Cube.
	// The bool variable |solving| indicates whether or not this class is actively performing a solution.
	// The int variable |sunnySideUp| is used as a reference to the current side of the Rubik's Cube that
	// is facing up. Its value will either be 1 for the White side up, and -1 for the Yellow side up.
	public GameObject solver;
	private bool solving;
	private int sunnySideUp;

	public Camera cam;

	// The int variable |faceConfig| represents the current F side of the Rubik's Cube according to
	// the camera view.
	private int faceConfig;

	// The bool variable |stepDone| is true when the user has completed an algorithm and successfully
	// completed one step of the solution.
	private bool stepDone = false;

	// The bool variable |userTurn| is true when the user presses a button to rotate the Rubik's Cube.
	private bool userTurn = false;

	// The bool variable |wrongTurn| is true when the user makes any rotation other than the correct one,
	// as given by the algorithm obtained from |solver|.
	private bool wrongTurn = false;

	// The bool variable |solved| is true when the Rubik's Cube is completely solved.
	private bool solved = false;

	// The following GameObject variables beginning with "guide" are the "animations" for each hint rotation.
	public GameObject guide_Fcw;
	public GameObject guide_Fccw;
	public GameObject guide_Dcw;
	public GameObject guide_Dccw;
	public GameObject guide_Rcw;
	public GameObject guide_Rccw;
	public GameObject guide_Ucw;
	public GameObject guide_Uccw;
	public GameObject guide_Lcw;
	public GameObject guide_Lccw;
	public GameObject guide_Bcw;
	public GameObject guide_Bccw;

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

	// The List<int> variable |progress| tracks the rotations the user has made. It is used to
	// compare the user's inputted rotations with the algorithm obtained from |solver|.
	private List<int> progress = new List<int> ();

	#endregion

	/// <summary>
	/// Start this instance by adding all rotation signal bool variables to a List<bool> variable.
	/// </summary>
	void Start () {
//		do_All.Add (do_F);
//		do_All.Add (do_Fi);
//		do_All.Add (do_D);
//		do_All.Add (do_Di);
//		do_All.Add (do_R);
//		do_All.Add (do_Ri);
//		do_All.Add (do_U);
//		do_All.Add (do_Ui);
//		do_All.Add (do_L);
//		do_All.Add (do_Li);
//		do_All.Add (do_B);
//		do_All.Add (do_Bi);
	}

	/// <summary>
	/// Update this instance by checking which side of the Rubik's Cube is facing up, updating the rotation
	/// int variables to reflect the current F side selection, and checking if the user has made any button
	/// presses to rotate the Rubik's Cube.
	/// </summary>
	void Update () {
		sunnySideUp = solver.GetComponent<Solver> ().GetUpFace ();
		faceConfig = cam.GetComponent<CameraController> ().GetFaceConfig ();
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
			} else {
				do_F = true;
			}
		} else if (press_D) {
			if (sunnySideUp > 0) {
				if (invert) {
					do_Di = true;
				} else {
					do_D = true;
				}
			} else if (sunnySideUp < 0) {
				if (invert) {
					do_Ui = true;
				} else {
					do_U = true;
				}
			}
		} else if (press_R) {
			if (invert) {
				do_Ri = true;
			} else {
				do_R = true;
			}
		} else if (press_U) {
			if (sunnySideUp > 0) {
				if (invert) {
					do_Ui = true;
				} else {
					do_U = true;
				}
			} else if (sunnySideUp < 0) {
				if (invert) {
					do_Di = true;
				} else {
					do_D = true;
				}
			}
		} else if (press_L) {
			if (invert) {
				do_Li = true;
			} else {
				do_L = true;
			}
		} else if (press_B) {
			if (invert) {
				do_Bi = true;
			} else {
				do_B = true;
			}
		}
		#endregion
	}
		
	public void ShowOrHide () {
		if (hide) {
			hint.GetComponentInChildren<Text> ().text = "Hide Hint";
			hide = false;
			ShowHint ();
		} else if (!hide) {
			hint.GetComponentInChildren<Text> ().text = "Show Hint";
			hide = true;
			HideHint ();
		}
	}

	/// <summary>
	/// Hides the hint animations.
	/// </summary>
	void HideHint () {
		StopAllCoroutines ();
		GuideOff ();
	}

	/// <summary>
	/// Turns off all guide animations.
	/// </summary>
	void GuideOff () {
		guide_Fcw.SetActive (false);
		guide_Fccw.SetActive (false);
		guide_Dcw.SetActive (false);
		guide_Dccw.SetActive (false);
		guide_Rcw.SetActive (false);
		guide_Rccw.SetActive (false);
		guide_Ucw.SetActive (false);
		guide_Uccw.SetActive (false);
		guide_Lcw.SetActive (false);
		guide_Lccw.SetActive (false);
		guide_Bcw.SetActive (false);
		guide_Bccw.SetActive (false);
	}

	/// <summary>
	/// Shows the hint animations.
	/// </summary>
	void ShowHint () {
		stepDone = false;
		userTurn = false;
		wrongTurn = false;
		solved = false;
		// No hint animations will show if there is an active solution proceeding.
		solving = solver.GetComponent<Solver> ().IsSolving ();
		if (!solving) {
			StartCoroutine (Guide ());
		}
	}

	/// <summary>
	/// Shows hint animations until the Rubik's Cube is fully solved.
	/// </summary>
	IEnumerator Guide () {
		while (!solved) {
			GuideOff ();
			stepDone = false;
			// Obtain the algorithm for this current step.
			List<int> algorithm = solver.GetComponent<Solver> ().GetAlgorithm ();
			StartCoroutine (GuideSteps (algorithm));
			while (!stepDone) {
				// If the user makes an incorrect rotation, the hint animations are disabled.
				if (wrongTurn) {
					print ("wrong");
					wrongTurn = false;
					progress.Clear ();
					ShowOrHide ();
					yield break;
				}
				yield return null;
			}
		}
		// Turns off the hint animations when the Rubik's Cube has been fully solved.
		ShowOrHide ();
	}

	/// <summary>
	/// Shows the hint animations for each step of the current algorithm.
	/// </summary>
	/// <param name="algorithm">Algorithm.</param>
	IEnumerator GuideSteps (List<int> algorithm) {
		foreach (int move in algorithm) {
			switch (move) {
			case 0:
				StartCoroutine (GuideOn__Fcw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 1:
				StartCoroutine (GuideOn_Fccw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 2:
				StartCoroutine (GuideOn__Dcw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 3:
				StartCoroutine (GuideOn_Dccw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 4:
				StartCoroutine (GuideOn__Rcw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 5:
				StartCoroutine (GuideOn_Rccw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 6:
				StartCoroutine (GuideOn__Ucw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 7:
				StartCoroutine (GuideOn_Uccw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 8:
				StartCoroutine (GuideOn__Lcw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 9:
				StartCoroutine (GuideOn_Lccw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 10:
				StartCoroutine (GuideOn__Bcw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 11:
				StartCoroutine (GuideOn_Bccw ());
				while (!userTurn) {
					yield return null;
				}
				userTurn = false;
				yield return new WaitForSeconds (0.2f);
				break;
			case 12:
				solved = true;
				yield return new WaitForSeconds (0.2f);
				break;
    			}
			//GuideOff ();
			CheckProgress (algorithm);
			if (wrongTurn) {
				yield break;
			}
		}

		// When |progress| matches |algorithm|, this section of code is reached.
		stepDone = true;
		progress.Clear ();
		yield return null;
	}
		
	/// <summary>
	/// Checks the progress of the user by matching each rotation in |progress| with |algorithm|.
	/// </summary>
	/// <param name="algorithm">Algorithm.</param>
	void CheckProgress (List<int> algorithm) {
		// If |progress| is shorter than algorithm and the current step is not finished, only compare
		// the number of rotations the user has made to |algorithm|.
		int len = progress.Count;
		for (int k = 0; k < len; k++) {
			if (progress [k] != algorithm [k]) {
				wrongTurn = true;
				break;
			}
		}
	}

	#region Guide Ons

	/// <summary>
	/// Turns on the guide for the White clockwise animation.
	/// </summary>
	IEnumerator GuideOn__Fcw () {
		GuideOff ();
		guide_Fcw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("f"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the White counterclockwise animation.
	/// </summary>
	IEnumerator GuideOn_Fccw () {
		GuideOff ();
		guide_Fccw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("fi"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Green clockwise animation.
	/// </summary>
	IEnumerator GuideOn__Dcw () {
		GuideOff ();
		guide_Dcw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("d"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Green counterclockwise animation.
	/// </summary>
	IEnumerator GuideOn_Dccw () {
		GuideOff ();
		guide_Dccw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("di"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Red clockwise animation.
	/// </summary>
	IEnumerator GuideOn__Rcw () {
		GuideOff ();
		guide_Rcw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("r"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Red counterclockwise animation.
	/// </summary>
	IEnumerator GuideOn_Rccw () {
		GuideOff ();
		guide_Rccw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("ri"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Blue clockwise animation.
	/// </summary>
	IEnumerator GuideOn__Ucw () {
		GuideOff ();
		guide_Ucw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("u"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Blue counterclockwise animation.
	/// </summary>
	IEnumerator GuideOn_Uccw () {
		GuideOff ();
		guide_Uccw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("ui"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Purple clockwise animation.
	/// </summary>
	IEnumerator GuideOn__Lcw () {
		GuideOff ();
		guide_Lcw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("l"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Purple counterclockwise animation.
	/// </summary>
	IEnumerator GuideOn_Lccw () {
		GuideOff ();
		guide_Lccw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("li"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Yellow clockwise animation.
	/// </summary>
	IEnumerator GuideOn__Bcw () {
		GuideOff ();
		guide_Bcw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("b"));
		yield return null;
	}

	/// <summary>
	/// Turns on the guide for the Yellow counterclockwise animation.
	/// </summary>
	IEnumerator GuideOn_Bccw () {
		GuideOff ();
		guide_Bccw.SetActive (true);

		while (!ButtonPressed ()) {
			yield return null;
		}
		
		userTurn = true;
		

		StartCoroutine (WaitForTurn ("bi"));
		yield return null;
	}
	#endregion

	/// <summary>
	/// Configures the rotation int variables to the current selection of the F side, determined by the
	/// camera view.
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
	/// Waits for the user to apply a rotation to the Rubik's Cube. Once a rotation has been made,
	/// adds the associated rotation int variable to |progress|.
	/// </summary>
	/// <returns>The for turn.</returns>
	/// <param name="turnString">Turn string.</param>
	IEnumerator WaitForTurn (string turnString) {
		// Waits for the user to apply a free turn.
		// Checks if the turn was correct.
		// Resets the algorithm if the turn was incorrect.
//		while (!ButtonPressed ()) {
//			yield return null;
//		}
		int move = WhichTurnDone ();
		progress.Add (move);
		PressManager ();

//		int match = WhichTurnDone ();
//		int turn = 12;
//
//		switch (turnString) {
//		case "f":
//			turn = 0;
//			break;
//		case "fi":
//			turn = 1;
//			break;
//		case "d":
//			turn = 2;
//			break;
//		case "di":
//			turn = 3;
//			break;
//		case "r":
//			turn = 4;
//			break;
//		case "ri":
//			turn = 5;
//			break;
//		case "u":
//			turn = 6;
//			break;
//		case "ui":
//			turn = 7;
//			break;
//		case "l":
//			turn = 8;
//			break;
//		case "li":
//			turn = 9;
//			break;
//		case "b":
//			turn = 10;
//			break;
//		case "bi":
//			turn = 11;
//			break;
//		}
//
//		if (match != turn) {
//			print (match);
//			print (turn);
//			wrongTurn = true;
//			CancelTurns ();
//			GuideOff ();
//			ShowOrHide ();
//		}

		CancelTurns ();

//		switch (turn) {
//		case 0:
//			//userTurn = true;
//			if (!do_F) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 1:
//			//userTurn = true;
//			if (!do_Fi) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 2:
//			//userTurn = true;
//			if (!do_D) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 3:
//			//userTurn = true;
//			if (!do_Di) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 4:
//			//userTurn = true;
//			if (!do_R) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 5:
//			//userTurn = true;
//			if (!do_Ri) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 6:
//			//userTurn = true;
//			if (!do_U) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 7:
//			//userTurn = true;
//			if (!do_Ui) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 8:
//			//userTurn = true;
//			if (!do_L) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 9:
//			//userTurn = true;
//			if (!do_Li) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 10:
//			//userTurn = true;
//			if (!do_B) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		case 11:
//			//userTurn = true;
//			if (!do_Bi) {
//				wrongTurn = true;
//			}
//			CancelTurns ();
//			break;
//		}
		yield return null;
	}

	/// <summary>
	/// Checks if the user has pressed a button.
	/// </summary>
	/// <returns><c>true</c>, if a button was pressed, <c>false</c> otherwise.</returns>
	bool ButtonPressed () {
		solving = solver.GetComponent<Solver> ().IsSolving ();
		if (solving) {
			ShowOrHide ();
		}
		return (press_F || press_D
		|| press_R || press_U
		|| press_L || press_B);
	}

	/// <summary>
	/// Returns which rotation the user inputted.
	/// </summary>
	/// <returns>The inputted rotation.</returns>
	int WhichTurnDone () {
		if (do_F) {
			return f;
		}
		if (do_Fi) {

			return fi;
		}
		if (do_D) {
			
			return d;
		}
		if (do_Di) {
			
			return di;
		}
		if (do_R) {
			
			return r;
		}
		if (do_Ri) {
			
			return ri;
		}
		if (do_U) {
			
			return u;
		}
		if (do_Ui) {
			
			return ui;
		}
		if (do_L) {
			
			return l;
		}
		if (do_Li) {
			
			return li;
		}
		if (do_B) {
			
			return b;
		}
		if (do_Bi) {
			
			return bi;
		}
		return 12;
	}

	/// <summary>
	/// Changes all rotation signals to false if more than one are true. This prevents errors from
	/// attempting to perform multiple rotations simultaneously.
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
	/// Changes all rotation signals to false.
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

		press_F = false;
		press_D = false;
		press_R = false;
		press_U = false;
		press_L = false;
		press_B = false;

	}

	/// <summary>
	/// Determines whether this instance is hinting.
	/// </summary>
	/// <returns><c>true</c> if this instance is hinting; otherwise, <c>false</c>.</returns>
	public bool IsHinting () {
		return (!hide);
	}

	/// <summary>
	/// Determines whether this instance is in the middle of a step.
	/// </summary>
	/// <returns><c>true</c> if this instance is in the middle of a step; otherwise, <c>false</c>.</returns>
	public bool IsStepping () {
		return stepDone;
	}

}
