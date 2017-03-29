using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hint : MonoBehaviour {

	#region Properties
	public Button hint;
	private bool hide = true;

	public GameObject solver;
	private bool solving;
	private int sunnySideUp;

	public Camera cam;
	private int faceConfig;

	private bool stepDone = false;
	private bool userTurn = false;
	private bool wrongTurn = false;
	private bool solved = false;

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

	private bool invert;
	private bool press_F;
	private bool press_D;
	private bool press_R;
	private bool press_U;
	private bool press_L;
	private bool press_B;

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


	private List<int> progress = new List<int> ();

	#endregion

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

	void HideHint () {
		StopAllCoroutines ();
		GuideOff ();
	}

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

	void ShowHint () {
		stepDone = false;
		userTurn = false;
		wrongTurn = false;
		solved = false;
		solving = solver.GetComponent<Solver> ().IsSolving ();
		if (!solving) {
			StartCoroutine (Guide ());
		}
	}

	IEnumerator Guide () {
		while (!solved) {
			GuideOff ();
			stepDone = false;
			List<int> algorithm = solver.GetComponent<Solver> ().GetAlgorithm ();
			StartCoroutine (GuideSteps (algorithm));
			while (!stepDone) {
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
		ShowOrHide ();	// turn off hint once the cube has been solved
	}

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

		stepDone = true;
		progress.Clear ();
		yield return null;
	}
		
	void CheckProgress (List<int> algorithm) {
		int len = progress.Count;
		for (int k = 0; k < len; k++) {
			if (progress [k] != algorithm [k]) {
				wrongTurn = true;
				break;
			}
		}
	}

	#region Guide Ons
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

	bool ButtonPressed () {
		solving = solver.GetComponent<Solver> ().IsSolving ();
		if (solving) {
			ShowOrHide ();
		}
		return (press_F || press_D
		|| press_R || press_U
		|| press_L || press_B);
	}

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

	// changes all turn signals to false if more than one are true.
	// this prevents errors from the user pressing buttons too fast, or at the same time.
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

	//changes all turn signals to false.
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

	public bool IsHinting () {
		return (!hide);
	}

	public bool IsStepping () {
		return stepDone;
	}

}
