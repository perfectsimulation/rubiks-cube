using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
///  This class contains all the methods to solve a Rubik's Cube.
/// </summary>
/// 
/// <remarks>
/// The Rubik's Cube is solved in six phases:
/// 1. White Cross
/// 2. White Corners
/// 3. Middle Layer
/// 4. Yellow Cross
/// 5. Yellow Corners
/// 6. Top Layer
/// </remarks>

public class Solver : MonoBehaviour {

	#region Properties

	// The bool variable |solving| indicates whether or not this class is actively performing a solution.
	// The bool variable |turning| indicates whether or not any side of the Rubik's Cube is currently rotating.
	// The bool variable |algorithmDone| indicates whether or not a particular algorithm has been completed.
	private bool solving = false;
	private bool turning = false;
	private bool algorithmDone = true;

	// The following bool variables from |whiteRed| to |topLayerEdged| indicate whether or not the corresponding 
	// piece(s) has been solved.
	private bool whiteRed = false;
	private bool whiteBlue = false;
	private bool whiteOrange = false;
	private bool whiteGreen = false;
	private bool whiteCrossed = false;
	private bool whiteRedBlue = false;
	private bool whiteBlueOrange = false;
	private bool whiteOrangeGreen = false;
	private bool whiteGreenRed = false;
	private bool whiteCornered = false;
	private bool redBlue = false;
	private bool blueOrange = false;
	private bool orangeGreen = false;
	private bool greenRed = false;
	private bool middleLayered = false;
	private bool yellowCrossed = false;
	private bool yellowCornered = false;
	private bool topLayerCornered = false;
	private bool topLayerEdged = false;

	// The following bool variables beginning with "toggle" are used to toggle the desired level of completion
	// for a particular solution of a Rubik's Cube.
	private bool toggleWhiteCrossed;
	private bool toggleWhiteCornered;
	private bool toggleMiddleLayered;
	private bool toggleYellowCrossed;
	private bool toggleYellowCornered;
	private bool toggleTopLayerCornered;
	private bool toggleTopLayerEdged;

	// The following string variables from |white| to |yellow| are used when searching for the correct piece
	// to solve.
	private static string white = "w";
	private static string red = "r";
	private static string blue = "b";
	private static string orange = "o";
	private static string green = "g";
	private static string yellow = "y";

	// The GameObject variable |rubiksCube| is the entire Rubik's Cube as a whole.
	public GameObject rubiksCube;

	// The GameObject |speedSlider| is a Slider on the UI for the desired speed of the solution animation.
	public GameObject speedSlider;
	private float speed;

	// The float variable |turnWait| is the time in seconds to pause between single rotations. 
	private float turnWait;

	// THe GameObject variable |hint| is a Button to show/hide the next rotation the user should perform.
	// The bool variable |hinting| is true when |hint| is currently showing the next rotation.
	public GameObject hint;
	private bool hinting;

	// The following GameObject variables ending with "face" are used for their Bounds to make the correct rotation.
	public GameObject f_face;
	public GameObject d_face;
	public GameObject r_face;
	public GameObject u_face;
	public GameObject l_face;
	public GameObject b_face;

	// The following Bounds variables ending in "bounds" are used to determine which pieces to rotate for a
	// given rotation.
	private Bounds f_bounds;
	private Bounds d_bounds;
	private Bounds r_bounds;
	private Bounds u_bounds;
	private Bounds l_bounds;
	private Bounds b_bounds;

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

	// The bool variable |upSwap| is the bool associated with a GetButtonDown method to flip the view of
	// the Rubik's Cube upside down.
	// The bool variable |doUpSwap| becomes true when <upSwap> becomes true. It prevents multiple flips.
	// The int variable |sunnySideUp| is used as a reference to the current side of the Rubik's Cube that
	// is facing up. Its value will either be 1 for the White side up, and -1 for the Yellow side up.
	private bool upSwap;
	private bool doUpSwap = false;
	private int sunnySideUp = 1;

	// The List<GameObject> variable |allCubes| contains all the pieces of the Rubik's Cube.
	// The List<Vector3> variable |allFacesCenters| contains all the pieces' centers.
	private List<GameObject> allCubes  = new List<GameObject> ();
	private List<Vector3> allCubesCenters = new List<Vector3> ();

	// The List<GameObject> variable |allFaces| contains all the "face" GameObject variables.
	// The List<Bounds> variable |allFacesBounds| contains all the "bounds" Bounds variables.
	private List<GameObject> allFaces  = new List<GameObject> ();
	private List<Bounds> allFacesBounds = new List<Bounds> ();

	// The List<int> variable |algorithm| is a sequence of integers that represent rotations of the
	// Rubik's Cube. This variable is cleared and reset many times and holds the current sequence
	// of rotations to solve a particular step of the solution.
	private List<int> algorithm = new List<int> ();

	// The List<int> variable |moves| appends all the |algorithm|s used in the current solution.
	// It also stores any rotations the user applies if the solution is paused.
	private List<int> moves = new List<int> ();
	#endregion

	/// <summary>
	/// Start this instance by populating the List variables to be used later on. The speed of rotations
	/// is set.
	/// </summary>
	void Start () {

		allFaces.Add (f_face);
		allFaces.Add (d_face);
		allFaces.Add (r_face);
		allFaces.Add (u_face);
		allFaces.Add (l_face);
		allFaces.Add (b_face);

		f_bounds = f_face.GetComponent<MeshCollider> ().bounds;
		d_bounds = d_face.GetComponent<MeshCollider> ().bounds;
		r_bounds = r_face.GetComponent<MeshCollider> ().bounds;
		u_bounds = u_face.GetComponent<MeshCollider> ().bounds;
		l_bounds = l_face.GetComponent<MeshCollider> ().bounds;
		b_bounds = b_face.GetComponent<MeshCollider> ().bounds;

		allFacesBounds.Add (f_bounds);
		allFacesBounds.Add (d_bounds);
		allFacesBounds.Add (r_bounds);
		allFacesBounds.Add (u_bounds);
		allFacesBounds.Add (l_bounds);
		allFacesBounds.Add (b_bounds);

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

		SetSpeed ();
	}

	/// <summary>
	/// Update this instance by checking for two things:
	/// 1. Whether or not hint is actively showing the next rotation.
	/// 2. Whether or not the user has pressed the Button to flip the Rubik's Cube.
	/// </summary>
	void Update () {
		hinting = hint.GetComponent<Hint> ().IsHinting ();
		upSwap = Input.GetButtonDown ("Jump");
		if (upSwap) {
			doUpSwap = true;
		}
		if (doUpSwap) {
			StartCoroutine (SwapTopView ());
		}
	}

	/// <summary>
	/// Sets the speed of rotations for the solution animation.
	/// </summary>
	public void SetSpeed () {
		speed = speedSlider.GetComponent<Slider> ().value;
		LimitSpeed ();
	}

	/// <summary>
	/// Reduces the set speed if it is too fast to allow a single rotation.
	/// Sets the time between rotations according to the set speed.
	/// </summary>
	void LimitSpeed () {
		while ((speed * Time.deltaTime) > 90f) {
			speed *= 0.9f;
		}
		if (speed <= 500) {
			turnWait = 0.4f;
		} else if (speed >= 500) {
			turnWait = 0.25f;
		}
	}


	#region Toggles
	/// <summary>
	/// Toggles the White Cross.
	/// </summary>
	/// <param name="check">If set to <c>true</c> solve the White Cross.</param>
	public void ToggleWhiteCross (bool check) {
		whiteCrossed = !check;
		toggleWhiteCrossed = !check;
	}

	/// <summary>
	/// Toggles the White Corners.
	/// </summary>
	/// <param name="check">If set to <c>true</c> solve the White Corners.</param>
	public void ToggleWhiteCorners (bool check) {
		whiteCornered = !check;
		toggleWhiteCornered = !check;
	}

	/// <summary>
	/// Toggles the Middle Layer.
	/// </summary>
	/// <param name="check">If set to <c>true</c> solve the Middle Layer.</param>
	public void ToggleMiddleLayer (bool check) {
		middleLayered = !check;
		toggleMiddleLayered = !check;
	}

	/// <summary>
	/// Toggles the Yellow Cross.
	/// </summary>
	/// <param name="check">If set to <c>true</c> solve the Yellow Cross.</param>
	public void ToggleYellowCross (bool check) {
		yellowCrossed = !check;
		toggleYellowCrossed = !check;
	}

	/// <summary>
	/// Toggles the Yellow Corners.
	/// </summary>
	/// <param name="check">If set to <c>true</c> solve the Yellow Corners.</param>
	public void ToggleYellowCorners (bool check) {
		yellowCornered = !check;
		toggleYellowCornered = !check;
	}

	/// <summary>
	/// Toggles the Top Layer.
	/// </summary>
	/// <param name="check">If set to <c>true</c> solve the Top Layer.</param>
	public void ToggleTopLayer (bool check) {
		topLayerCornered = !check;
		toggleTopLayerCornered = !check;
		topLayerEdged = !check;
		toggleTopLayerEdged = !check;
	}
	#endregion

	/// <summary>
	/// Solve this instance by calling the method SolveSteps ().
	/// </summary>
	public void Solve () {
		if (!solving) {
			moves.Clear ();
			algorithm.Clear ();
			// reset Solver if prior solutions completed
			whiteCrossed = toggleWhiteCrossed;
			whiteCornered = toggleWhiteCornered;
			middleLayered = toggleMiddleLayered;
			yellowCrossed = toggleYellowCrossed;
			yellowCornered = toggleYellowCornered;
			topLayerCornered = toggleTopLayerCornered;
			topLayerEdged = toggleTopLayerEdged;
			StartCoroutine (SolveSteps ());
		}
	}

	/// <summary>
	/// Solves this instance step by step.
	/// </summary>
	/// <returns>The steps.</returns>
	IEnumerator SolveSteps () {
		// Prevent calling this method again if it is already active.
		while (solving) {
			yield return null;
		}
		// Hides |hint| before solving.
		if (hinting) {
			hint.GetComponent<Hint> ().ShowOrHide ();
		}
		solving = true;
		if (!whiteCrossed) {
			StartCoroutine (SolveWhiteCross ());
		}
		while (!whiteCrossed) {
			yield return null;
		}
		if (!whiteCornered) {
			StartCoroutine (SolveWhiteCorners ());
		}
		while (!whiteCornered) {
			yield return null;
		}
		if (!middleLayered) {
			StartCoroutine (SolveMiddleLayer ());
		}
		while (!middleLayered) {
			yield return null;
		}
		if (!yellowCrossed) {
			StartCoroutine (SolveYellowCross ());
		}
		while (!yellowCrossed) {
			yield return null;
		}
		if (!yellowCornered) {
			StartCoroutine (SolveYellowCorners ());
		}
		while (!yellowCornered) {
			yield return null;
		}
		if (!topLayerCornered) {
			StartCoroutine (SolveTopLayerCorners ());
		}
		while (!topLayerCornered) {
			yield return null;
		}
		if (!topLayerEdged) {
			StartCoroutine (SolveTopLayerEdges ());
		}
		while (!topLayerEdged) {
			yield return null;
		}
		solving = false;
		yield return null;
	}

	#region Layer 1

	/// <summary>
	/// Solves the White Cross.
	/// </summary>
	IEnumerator SolveWhiteCross () {
		int count = 0;
		if (!whiteRed) {
			string wr = GetPieceIndex (cube20, white);
			StartCoroutine (WhiteXRed (wr.ToString ()));
			count++;
			print (wr);
		}
		while (!whiteRed) {
			yield return null;
		}
		if (whiteRed && !whiteBlue) {
			string wb = GetPieceIndex (cube24, white);
			StartCoroutine (WhiteXBlue (wb.ToString()));
			count++;
			print (wb);
		}
		while (!whiteBlue) {
			yield return null;
		}
		if (whiteRed && whiteBlue && !whiteOrange) {
			string wo = GetPieceIndex (cube26, white);
			StartCoroutine (WhiteXPurple (wo.ToString()));
			count++;
			print (wo);
		}
		while (!whiteOrange) {
			yield return null;
		}
		if (whiteRed && whiteBlue && whiteOrange && !whiteGreen) {
			string wg = GetPieceIndex (cube22, white);
			StartCoroutine (WhiteXGreen (wg.ToString()));
			count++;
			print (wg);
		}
		while (!whiteGreen) {
			yield return null;
		}
		if (count == 4) {		// reset bool values so cube can be resolved if scrambled again
			whiteRed = false;
			whiteBlue = false;
			whiteOrange = false;
			whiteGreen = false;
			whiteCrossed = true;
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Red-White Edge piece of the White Cross.
	/// Populates |algorithm| and passes it to the method PerformAlgorithm.
	/// </summary>
	/// <param name="indexKey">Index key of the Red-White Edge.</param>
	/// 
	IEnumerator WhiteXRed (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				algorithm.Add (0);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (0);
					algorithm.Add (0);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (1);
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				algorithm.Add (4);
				algorithm.Add (6);
				algorithm.Add (0);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (3);
					algorithm.Add (1);
				}
				if (colIndex == 2) {
					algorithm.Add (6);
					algorithm.Add (0);
				}
				break;
			case 2:
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (0);
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				algorithm.Add (7);
				algorithm.Add (5);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (5);
				}
				if (colIndex == 2) {
					algorithm.Add (6);
					algorithm.Add (6);
					algorithm.Add (5);
				}
				break;
			case 2:
				algorithm.Add (6);
				algorithm.Add (5);
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				algorithm.Add (8);
				algorithm.Add (2);
				algorithm.Add (1);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (7);
					algorithm.Add (0);
				}
				if (colIndex == 2) {
					algorithm.Add (2);
					algorithm.Add (1);
				}
				break;
			case 2:
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (1);
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				algorithm.Add (2);
				algorithm.Add (4);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (2);
					algorithm.Add (2);
					algorithm.Add (4);
				}
				if (colIndex == 2) {
					algorithm.Add (4);
				}
				break;
			case 2:
				algorithm.Add (3);
				algorithm.Add (4);
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (4);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (8);
					algorithm.Add (0);
					algorithm.Add (0);
				}
				if (colIndex == 2) {
					algorithm.Add (4);
					algorithm.Add (4);
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (4);
				algorithm.Add (4);
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			whiteRed = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Blue-White Edge piece of the White Cross.
	/// Populates |algorithm| and passes it to the method PerformAlgorithm.
	/// </summary>
	/// <param name="indexKey">Index key of the Blue-White Edge.</param>
	IEnumerator WhiteXBlue (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (4);
					algorithm.Add (4);
					algorithm.Add (0);
					algorithm.Add (4);
					algorithm.Add (4);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (2);
				algorithm.Add (2);
				algorithm.Add (10);
				algorithm.Add (10);
				algorithm.Add (6);
				algorithm.Add (6);
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (2);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (6);
				}
				break;
			case 2:
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (4);
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				algorithm.Add (6);
				algorithm.Add (9);
				algorithm.Add (10);
				algorithm.Add (6);
				algorithm.Add (6);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (1);
					algorithm.Add (4);
				}
				if (colIndex == 2) {
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (6);
				}
				break;
			case 2:
				algorithm.Add (7);
				algorithm.Add (9);
				algorithm.Add (10);
				algorithm.Add (6);
				algorithm.Add (6);
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				algorithm.Add (9);
				algorithm.Add (7);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (7);
				}
				if (colIndex == 2) {
					algorithm.Add (8);
					algorithm.Add (8);
					algorithm.Add (7);
				}
				break;
			case 2:
				algorithm.Add (8);
				algorithm.Add (7);
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				algorithm.Add (4);
				algorithm.Add (4);
				algorithm.Add (1);
				algorithm.Add (4);
				algorithm.Add (6);
				algorithm.Add (4);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (2);
					algorithm.Add (2);
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (6);
				}
				break;
			case 2:
				algorithm.Add (11);
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (4);
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				algorithm.Add (10);
				algorithm.Add (10);
				algorithm.Add (6);
				algorithm.Add (6);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (6);
				}
				break;
			case 2:
				algorithm.Add (6);
				algorithm.Add (6);
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			whiteBlue = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Purple-White Edge piece of the White Cross.
	/// Populates |algorithm| and passes it to the method PerformAlgorithm.
	/// </summary>
	/// <param name="indexKey">Index key of the Purple-White Edge.</param>
	IEnumerator WhiteXPurple (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (2);
				algorithm.Add (2);
				algorithm.Add (10);
				algorithm.Add (8);
				algorithm.Add (8);
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (2);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (8);
				}
				if (colIndex == 2) {
					algorithm.Add (6);
					algorithm.Add (4);
					algorithm.Add (4);
					algorithm.Add (1);
					algorithm.Add (7);
					algorithm.Add (4);
					algorithm.Add (4);
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (2);
				algorithm.Add (9);
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (8);
					algorithm.Add (5);
				}
				if (colIndex == 2) {
					algorithm.Add (8);
				}
				break;
			case 2:
				algorithm.Add (11);
				algorithm.Add (9);
				algorithm.Add (1);
				algorithm.Add (2);
				algorithm.Add (0);
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				algorithm.Add (8);
				algorithm.Add (1);
				algorithm.Add (2);
				algorithm.Add (0);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (9);
				}
				if (colIndex == 2) {
					algorithm.Add (1);
					algorithm.Add (2);
					algorithm.Add (0);
				}
				break;
			case 2:
				algorithm.Add (9);
				algorithm.Add (1);
				algorithm.Add (2);
				algorithm.Add (0);
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				algorithm.Add (3);
				algorithm.Add (9);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (9);
				}
				if (colIndex == 2) {
					algorithm.Add (2);
					algorithm.Add (2);
					algorithm.Add (9);
				}
				break;
			case 2:
				algorithm.Add (2);
				algorithm.Add (9);
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				algorithm.Add (10);
				algorithm.Add (8);
				algorithm.Add (8);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (8);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (8);
				}
				break;
			case 2:
				algorithm.Add (11);
				algorithm.Add (8);
				algorithm.Add (8);
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			whiteOrange = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Green-White Edge piece of the White Cross.
	/// Populates |algorithm| and passes it to the method PerformAlgorithm.
	/// </summary>
	/// <param name="indexKey">Index key of the Green-White Edge.</param>
	IEnumerator WhiteXGreen (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());
		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (3);
				}
				if (colIndex == 2) {
					algorithm.Add (4);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (4);
				}
				break;
			case 2:
				algorithm.Add (4);
				algorithm.Add (3);
				algorithm.Add (5);
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (5);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (2);
					algorithm.Add (8);
				}
				break;
			case 2:
				algorithm.Add (11);
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (8);
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (8);
					algorithm.Add (2);
					algorithm.Add (8);
					algorithm.Add (8);
				}
				if (colIndex == 2) {
					algorithm.Add (2);
				}
				break;
			case 2:
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (8);
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				algorithm.Add (2);
				algorithm.Add (1);
				algorithm.Add (4);
				algorithm.Add (0);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (0);
					algorithm.Add (9);
					algorithm.Add (1);
				}
				if (colIndex == 2) {
					algorithm.Add (1);
					algorithm.Add (4);
					algorithm.Add (0);
				}
				break;
			case 2:
				algorithm.Add (2);
				algorithm.Add (0);
				algorithm.Add (9);
				algorithm.Add (1);
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				algorithm.Add (2);
				algorithm.Add (2);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (2);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (2);
					algorithm.Add (2);
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (10);
				algorithm.Add (2);
				algorithm.Add (2);
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			whiteGreen = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the White Corners.
	/// </summary>
	IEnumerator SolveWhiteCorners () {
		int count = 0;
		if (!whiteRedBlue) {
			string wrb = GetPieceIndex (cube21, red);
			StartCoroutine (WhiteXRedXBlue (wrb.ToString ()));
			count++;
			print (wrb);
		}
		while (!whiteRedBlue) {
			yield return null;
		}
		if (whiteRedBlue && !whiteBlueOrange) {
			string wbo = GetPieceIndex (cube00, blue);
			StartCoroutine (WhiteXBlueXPurple (wbo.ToString ()));
			count++;
			print (wbo);
		}
		while (!whiteBlueOrange) {
			yield return null;
		}
		if (whiteRedBlue && whiteBlueOrange && !whiteOrangeGreen) {
			string wog = GetPieceIndex (cube25, orange);
			StartCoroutine (WhiteXPurpleXGreen (wog.ToString ()));
			count++;
			print (wog);
		}
		while (!whiteOrangeGreen) {
			yield return null;
		}
		if (whiteRedBlue && whiteBlueOrange && whiteOrangeGreen && !whiteGreenRed) {
			string wgr = GetPieceIndex (cube19, green);
			StartCoroutine (WhiteXGreenXRed (wgr.ToString ()));
			count++;
			print (wgr);
		}
		while (!whiteGreenRed) {
			yield return null;
		}
		if (count == 4) {		// reset bool values so cube can be resolved if scrambled again
			whiteRedBlue = false;
			whiteBlueOrange = false;
			whiteOrangeGreen = false;
			whiteGreenRed = false;
			whiteCornered = true;
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Red-Blue-White Corner piece of the White Corners.
	/// Populates |algorithm| and passes it to the method PerformAlgorithm.
	/// </summary>
	/// <param name="indexKey">Index key of the Red-Blue-White Corner.</param>
	IEnumerator WhiteXRedXBlue (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (6);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (11);
					algorithm.Add (5);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (11);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (11);
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (11);
					algorithm.Add (7);
					algorithm.Add (10);
					algorithm.Add (6);
				}
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (11);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
				}
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			whiteRedBlue = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Blue-Purple-White Corner piece of the White Corners.
	/// Populates |algorithm| and passes it to the method PerformAlgorithm.
	/// </summary>
	/// <param name="indexKey">Index key of the Blue-Purple-White Corner.</param>
	IEnumerator WhiteXBlueXPurple (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				if (colIndex == 2) {
					algorithm.Add (11);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (11);
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				if (colIndex == 2) {
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (8);
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
				}
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (11);
					algorithm.Add (7);
				}
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			whiteBlueOrange = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Purple-Green-White Corner piece of the White Corners.
	/// Populates |algorithm| and passes it to the method PerformAlgorithm.
	/// </summary>
	/// <param name="indexKey">Index key of the Purple-Green-White Corner.</param>
	IEnumerator WhiteXPurpleXGreen (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (2);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (2);
				}
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (2);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (2);
				}
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (2);
				}
				if (colIndex == 2) {
					algorithm.Add (11);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (2);
				}
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (11);
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (2);
				}
				if (colIndex == 2) {
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (2);
				}
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (11);
					algorithm.Add (9);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (2);
				}
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
				}
				if (colIndex == 2) {
					algorithm.Add (11);
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
				}
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			whiteOrangeGreen = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Green-Red-White Corner piece of the White Corners.
	/// Populates |algorithm| and passes it to the method PerformAlgorithm.
	/// </summary>
	/// <param name="indexKey">Index key of the Green-Red-White Corner.</param>
	IEnumerator WhiteXGreenXRed (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (11);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
				}
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (2);
					algorithm.Add (11);
					algorithm.Add (3);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (11);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
				}
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (11);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
				}
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (11);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
				}
				if (colIndex == 2) {
					algorithm.Add (11);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
				}
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (11);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (11);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (4);
				}
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				if (colIndex == 0) {
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (11);
					algorithm.Add (3);
				}
				if (colIndex == 2) {
					algorithm.Add (2);
					algorithm.Add (11);
					algorithm.Add (3);
				}
				break;
			case 2:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (2);
					algorithm.Add (11);
					algorithm.Add (3);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (2);
					algorithm.Add (11);
					algorithm.Add (3);
				}
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			whiteGreenRed = true;
			algorithm.Clear ();
		}
		yield return null;
	}
	#endregion

	#region Layer 2
	/// <summary>
	/// Solves the Middle Layer.
	/// </summary>
	IEnumerator SolveMiddleLayer () {
		int count = 0;
		if (!redBlue) {
			string rb = GetPieceIndex (cube12, red);
			StartCoroutine (RedXBlue (rb.ToString ()));
			count++;
		}
		while (!redBlue) {
			yield return null;
		}
		if (redBlue && !blueOrange) {
			string bo = GetPieceIndex (cube18, blue);
			StartCoroutine (BlueXPurple (bo.ToString ()));
			count++;
		}
		while (!blueOrange) {
			yield return null;
		}
		if (redBlue && blueOrange && !orangeGreen) {
			string og = GetPieceIndex (cube16, orange);
			StartCoroutine (PurpleXGreen (og.ToString ()));
			count++;
		}
		while (!orangeGreen) {
			yield return null;
		}
		if (redBlue && blueOrange && orangeGreen && !greenRed) {
			string gr = GetPieceIndex (cube10, green);
			StartCoroutine (GreenXRed (gr.ToString ()));
			count++;
		}
		while (!greenRed) {
			yield return null;
		}
		if (count == 4) {		// reset bool values so cube can be resolved if scrambled again
			redBlue = false;
			blueOrange = false;
			orangeGreen = false;
			greenRed = false;
			middleLayered = true;
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Red-Blue Edge piece of the Middle Layer.
	/// </summary>
	/// <param name="indexKey">Index key of the Red-Blue Edge.</param>
	IEnumerator RedXBlue (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (2);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (4);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (7);
				algorithm.Add (11);
				algorithm.Add (6);
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (4);
				algorithm.Add (7);
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (4);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (4);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (6);
					algorithm.Add (9);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (7);
					algorithm.Add (4);
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (10);
				algorithm.Add (7);
				algorithm.Add (11);
				algorithm.Add (6);
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (4);
				algorithm.Add (7);
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (6);
					algorithm.Add (9);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (4);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (8);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (7);
					algorithm.Add (4);
				}
				break;
			case 2:
				algorithm.Add (11);
				algorithm.Add (7);
				algorithm.Add (11);
				algorithm.Add (6);
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (4);
				algorithm.Add (7);
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (8);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (4);
					algorithm.Add (7);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (2);
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (7);
					algorithm.Add (4);
				}
				break;
			case 2:
				algorithm.Add (7);
				algorithm.Add (11);
				algorithm.Add (6);
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (4);
				algorithm.Add (7);
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				algorithm.Add (10);
				algorithm.Add (4);
				algorithm.Add (10);
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (5);
				algorithm.Add (7);
				algorithm.Add (4);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (7);
					algorithm.Add (4);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (4);
					algorithm.Add (10);
					algorithm.Add (5);
					algorithm.Add (6);
					algorithm.Add (5);
					algorithm.Add (7);
					algorithm.Add (4);
				}
				break;
			case 2:
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (10);
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (5);
				algorithm.Add (7);
				algorithm.Add (4);
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			redBlue = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Blue-Purple Edge piece of the Middle Layer.
	/// </summary>
	/// <param name="indexKey">Index key of the Blue-Purple Edge.</param>
	IEnumerator BlueXPurple (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (2);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (6);
					algorithm.Add (9);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (9);
				algorithm.Add (11);
				algorithm.Add (8);
				algorithm.Add (7);
				algorithm.Add (8);
				algorithm.Add (6);
				algorithm.Add (9);
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (9);
				algorithm.Add (11);
				algorithm.Add (8);
				algorithm.Add (7);
				algorithm.Add (8);
				algorithm.Add (6);
				algorithm.Add (9);
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (6);
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (6);
					algorithm.Add (9);
				}
				if (colIndex == 2) {
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (8);
					algorithm.Add (3);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (9);
					algorithm.Add (6);
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (10);
				algorithm.Add (9);
				algorithm.Add (11);
				algorithm.Add (8);
				algorithm.Add (7);
				algorithm.Add (8);
				algorithm.Add (6);
				algorithm.Add (9);
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (8);
					algorithm.Add (3);
					algorithm.Add (9);
					algorithm.Add (11);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (6);
					algorithm.Add (9);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (2);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (9);
					algorithm.Add (6);
				}
				break;
			case 2:
				algorithm.Add (11);
				algorithm.Add (9);
				algorithm.Add (11);
				algorithm.Add (8);
				algorithm.Add (7);
				algorithm.Add (8);
				algorithm.Add (6);
				algorithm.Add (9);
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				algorithm.Add (6);
				algorithm.Add (10);
				algorithm.Add (7);
				algorithm.Add (8);
				algorithm.Add (7);
				algorithm.Add (9);
				algorithm.Add (6);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (11);
					algorithm.Add (6);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (9);
					algorithm.Add (6);
				}
				if (colIndex == 2) {
					algorithm.Add (10);
					algorithm.Add (6);
					algorithm.Add (10);
					algorithm.Add (7);
					algorithm.Add (8);
					algorithm.Add (7);
					algorithm.Add (9);
					algorithm.Add (6);
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (10);
				algorithm.Add (6);
				algorithm.Add (10);
				algorithm.Add (7);
				algorithm.Add (8);
				algorithm.Add (7);
				algorithm.Add (9);
				algorithm.Add (6);
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			blueOrange = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Purple-Green Edge piece of the Middle Layer.
	/// </summary>
	/// <param name="indexKey">Index key of the Purple-Green Edge.</param>
	IEnumerator PurpleXGreen (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (2);
					algorithm.Add (5);
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (8);
					algorithm.Add (3);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (11);
				algorithm.Add (3);
				algorithm.Add (11);
				algorithm.Add (2);
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (8);
				algorithm.Add (3);
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (3);
				algorithm.Add (11);
				algorithm.Add (2);
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (8);
				algorithm.Add (3);
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (3);
				algorithm.Add (11);
				algorithm.Add (2);
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (8);
				algorithm.Add (3);
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (8);
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (3);
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (8);
					algorithm.Add (3);
				}
				if (colIndex == 2) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (2);
					algorithm.Add (5);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (3);
					algorithm.Add (8);
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (10);
				algorithm.Add (3);
				algorithm.Add (11);
				algorithm.Add (2);
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (8);
				algorithm.Add (3);
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				algorithm.Add (11);
				algorithm.Add (8);
				algorithm.Add (10);
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (9);
				algorithm.Add (3);
				algorithm.Add (8);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (10);
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (3);
					algorithm.Add (8);
				}
				if (colIndex == 2) {
					algorithm.Add (8);
					algorithm.Add (10);
					algorithm.Add (9);
					algorithm.Add (2);
					algorithm.Add (9);
					algorithm.Add (3);
					algorithm.Add (8);
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (8);
				algorithm.Add (10);
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (9);
				algorithm.Add (3);
				algorithm.Add (8);
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			orangeGreen = true;
			algorithm.Clear ();
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Green-Red Edge piece of the Middle Layer.
	/// </summary>
	/// <param name="indexKey">Index key of the Green-Red Edge.</param>
	IEnumerator GreenXRed (string indexKey) {
		int faceIndex = IntParseFast (indexKey [0].ToString ());
		int rowIndex = IntParseFast (indexKey [1].ToString ());
		int colIndex = IntParseFast (indexKey [2].ToString ());

		switch (faceIndex) {
		case 0:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				break;
			}
			break;

		case 1:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (2);
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (5);
					algorithm.Add (11);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (2);
					algorithm.Add (5);
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (10);
				algorithm.Add (5);
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (3);
				algorithm.Add (4);
				algorithm.Add (2);
				algorithm.Add (5);
				break;
			}
			break;

		case 2:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (11);
				algorithm.Add (5);
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (3);
				algorithm.Add (4);
				algorithm.Add (2);
				algorithm.Add (5);
				break;
			}
			break;

		case 3:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (5);
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (3);
				algorithm.Add (4);
				algorithm.Add (2);
				algorithm.Add (5);
				break;
			}
			break;

		case 4:
			switch (rowIndex) {
			case 0:
				break;
			case 1:
				if (colIndex == 0) {
				}
				if (colIndex == 2) {
				}
				break;
			case 2:
				algorithm.Add (10);
				algorithm.Add (5);
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (3);
				algorithm.Add (4);
				algorithm.Add (2);
				algorithm.Add (5);
				break;
			}
			break;

		case 5:
			switch (rowIndex) {
			case 0:
				algorithm.Add (10);
				algorithm.Add (10);
				algorithm.Add (2);
				algorithm.Add (10);
				algorithm.Add (3);
				algorithm.Add (4);
				algorithm.Add (3);
				algorithm.Add (5);
				algorithm.Add (2);
				break;
			case 1:
				if (colIndex == 0) {
					algorithm.Add (10);
					algorithm.Add (2);
					algorithm.Add (10);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (5);
					algorithm.Add (2);
				}
				if (colIndex == 2) {
					algorithm.Add (11);
					algorithm.Add (2);
					algorithm.Add (10);
					algorithm.Add (3);
					algorithm.Add (4);
					algorithm.Add (3);
					algorithm.Add (5);
					algorithm.Add (2);
				}
				break;
			case 2:
				algorithm.Add (2);
				algorithm.Add (10);
				algorithm.Add (3);
				algorithm.Add (4);
				algorithm.Add (3);
				algorithm.Add (5);
				algorithm.Add (2);
				break;
			}
			break;
		}
		if (solving) {
			StartCoroutine (PerformAlgorithm (algorithm));
			while (!algorithmDone) {
				yield return null;
			}
			greenRed = true;
			algorithm.Clear ();
		}
		yield return null;
	}
	#endregion

	#region Layer 3
	/// <summary>
	/// Solves the Yellow Cross.
	/// </summary>
	IEnumerator SolveYellowCross () {
		while (!yellowCrossed) {
			SetAlgorithmForYellowStep (13);
			if (solving) {
				StartCoroutine (PerformAlgorithm (algorithm));
				while (!algorithmDone) {
					yield return null;
				}
				algorithm.Clear ();
			}
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Yellow Corners.
	/// </summary>
	IEnumerator SolveYellowCorners () {
		while (!yellowCornered) {
			SetAlgorithmForYellowStep (14);
			if (solving) {
				StartCoroutine (PerformAlgorithm (algorithm));
				while (!algorithmDone) {
					yield return null;
				}
				algorithm.Clear ();
			}
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Top Layer Corners.
	/// </summary>
	IEnumerator SolveTopLayerCorners () {
		while (!topLayerCornered) {
			SetAlgorithmForYellowStep (15);
			if (solving) {
				StartCoroutine (PerformAlgorithm (algorithm));
				while (!algorithmDone) {
					yield return null;
				}
				algorithm.Clear ();
			}
		}
		yield return null;
	}

	/// <summary>
	/// Solves the Top Layer Edges.
	/// </summary>
	IEnumerator SolveTopLayerEdges () {
		while (!topLayerEdged) {
			SetAlgorithmForYellowStep (16);
			if (solving) {
				StartCoroutine (PerformAlgorithm (algorithm));
				while (!algorithmDone) {
					yield return null;
				}
				algorithm.Clear ();
			}
		}
		yield return null;
	}

	/// <summary>
	/// Sets the |algorithm| for a yellow step (Yellow Cross, Yellow Corners, Top Layer).
	/// </summary>
	void SetAlgorithmForYellowStep (int step) {
		int n;
		switch (step) {
		case 13:
			n = GetYellowCrossConfiguration ();
			switch (n) {
			case 1:
				algorithm.Add (6);
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (10);
				algorithm.Add (5);
				algorithm.Add (7);
				break;
			case 2:
				algorithm.Add (6);
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (10);
				algorithm.Add (5);
				algorithm.Add (7);
				break;
			case 3:
				algorithm.Add (6);
				algorithm.Add (4);
				algorithm.Add (11);
				algorithm.Add (5);
				algorithm.Add (10);
				algorithm.Add (7);
				break;
			}
			break;
		case 14:
			GetYellowCornersConfiguration ();
			if (!yellowCornered) {
				algorithm.Add (4);
				algorithm.Add (11);
				algorithm.Add (5);
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (11);
				algorithm.Add (11);
				algorithm.Add (5);
			}
			break;
		case 15:
			n = GetYellowCornersConfiguration ();
			switch (n) {
			case 6:
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (5);
				algorithm.Add (2);
				algorithm.Add (2);
				algorithm.Add (4);
				algorithm.Add (7);
				algorithm.Add (5);
				algorithm.Add (2);
				algorithm.Add (2);
				algorithm.Add (4);
				algorithm.Add (4);
				algorithm.Add (10);
				break;
			case 7:
				algorithm.Add (7);
				algorithm.Add (8);
				algorithm.Add (7);
				algorithm.Add (4);
				algorithm.Add (4);
				algorithm.Add (6);
				algorithm.Add (9);
				algorithm.Add (7);
				algorithm.Add (4);
				algorithm.Add (4);
				algorithm.Add (6);
				algorithm.Add (6);
				algorithm.Add (10);
				break;
			case 8:
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (9);
				algorithm.Add (6);
				algorithm.Add (6);
				algorithm.Add (8);
				algorithm.Add (3);
				algorithm.Add (9);
				algorithm.Add (6);
				algorithm.Add (6);
				algorithm.Add (8);
				algorithm.Add (8);
				algorithm.Add (10);
				break;
			case 9:
				algorithm.Add (3);
				algorithm.Add (4);
				algorithm.Add (3);
				algorithm.Add (8);
				algorithm.Add (8);
				algorithm.Add (2);
				algorithm.Add (5);
				algorithm.Add (3);
				algorithm.Add (8);
				algorithm.Add (8);
				algorithm.Add (2);
				algorithm.Add (2);
				algorithm.Add (10);
				break;
			case 10:
				algorithm.Add (10);
				break;
			}
			break;
		case 16:
			n = GetYellowEdgesConfiguration ();
			switch (n) {
			case 1:
				algorithm.Add (6);
				algorithm.Add (6);
				algorithm.Add (10);
				algorithm.Add (8);
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (6);
				algorithm.Add (9);
				algorithm.Add (4);
				algorithm.Add (10);
				algorithm.Add (6);
				algorithm.Add (6);
				break;
			case 2:
				algorithm.Add (6);
				algorithm.Add (6);
				algorithm.Add (11);
				algorithm.Add (8);
				algorithm.Add (5);
				algorithm.Add (6);
				algorithm.Add (6);
				algorithm.Add (9);
				algorithm.Add (4);
				algorithm.Add (11);
				algorithm.Add (6);
				algorithm.Add (6);
				break;
			case 3:
				algorithm.Add (4);
				algorithm.Add (4);
				algorithm.Add (10);
				algorithm.Add (6);
				algorithm.Add (3);
				algorithm.Add (4);
				algorithm.Add (4);
				algorithm.Add (7);
				algorithm.Add (2);
				algorithm.Add (10);
				algorithm.Add (4);
				algorithm.Add (4);
				break;
			case 4:
				algorithm.Add (4);
				algorithm.Add (4);
				algorithm.Add (11);
				algorithm.Add (6);
				algorithm.Add (3);
				algorithm.Add (4);
				algorithm.Add (4);
				algorithm.Add (7);
				algorithm.Add (2);
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (4);
				break;
			case 5:
				algorithm.Add (8);
				algorithm.Add (8);
				algorithm.Add (10);
				algorithm.Add (2);
				algorithm.Add (7);
				algorithm.Add (8);
				algorithm.Add (8);
				algorithm.Add (3);
				algorithm.Add (6);
				algorithm.Add (10);
				algorithm.Add (8);
				algorithm.Add (8);
				break;
			case 6:
				algorithm.Add (8);
				algorithm.Add (8);
				algorithm.Add (11);
				algorithm.Add (2);
				algorithm.Add (7);
				algorithm.Add (8);
				algorithm.Add (8);
				algorithm.Add (3);
				algorithm.Add (6);
				algorithm.Add (11);
				algorithm.Add (8);
				algorithm.Add (8);
				break;
			case 7:
				algorithm.Add (2);
				algorithm.Add (2);
				algorithm.Add (10);
				algorithm.Add (4);
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (2);
				algorithm.Add (5);
				algorithm.Add (8);
				algorithm.Add (10);
				algorithm.Add (2);
				algorithm.Add (2);
				break;
			case 8:
				algorithm.Add (2);
				algorithm.Add (2);
				algorithm.Add (11);
				algorithm.Add (4);
				algorithm.Add (9);
				algorithm.Add (2);
				algorithm.Add (2);
				algorithm.Add (5);
				algorithm.Add (8);
				algorithm.Add (11);
				algorithm.Add (2);
				algorithm.Add (2);
				break;
			}
			break;
		}
	}

	/// <summary>
	/// Gets the configuration of the Yellow Cross.
	/// </summary>
	/// <returns>The Yellow Cross configuration.</returns>
	/// <remarks>
	/// This method determines which algorithm to perform according to the current configuration of the
	/// Yellow Cross.
	/// </remarks>
	int GetYellowCrossConfiguration () {
		// get n - number of yellow cubes on face.
		// if n == 1, config 1
		// if n == 3, config 2 OR 3
		// if it's not either 2 or 3, treat it like config 1
		// if n == 5, config 4
		// if n >= 6, config 5
		// once n is found, if the config is in the wrong orientation,
		// rotate the yellow side using turn mech B until the right orientation obtained.

		algorithm.Clear ();
		List<string> yellowFaceColors = GetYellowFaceColors ();

		string y01 = yellowFaceColors [1];
		string y10 = yellowFaceColors [3];
		string y11 = yellowFaceColors [4];
		string y12 = yellowFaceColors [5];
		string y21 = yellowFaceColors [7];

		if ((y01 == y10) && (y12 == y21) && (y21 == y11)) {
			yellowCrossed = true;
			return 4;
		} else if ((y01 == y10) && (y10 == y11)) {
			return 2;
		} else if ((y01 == y12) && (y12 == y11)) {
			algorithm.Add (10);
			return 2;
		} else if ((y12 == y21) && (y21 == y11)) {
			algorithm.Add (10);
			algorithm.Add (10);
			return 2;
		} else if ((y10 == y21) && (y21 == y11)) {
			algorithm.Add (11);
			return 2;
		} else if ((y10 == y12) && (y12 == y11)) {
			return 3;
		} else if ((y01 == y21) && (y21 == y11)) {
			algorithm.Add (10);
			return 3;
		} else {
			return 1;
		}
	}

	/// <summary>
	/// Gets the configuration of the Yellow Corners.
	/// </summary>
	/// <returns>The Yellow Corners configuration.</returns>
	/// <remarks>
	/// This method determines which algorithm to perform according to the current configuration of the
	/// Yellow Corners and the orientation of the colors of the mismatched Yellow Corners.
	/// </remarks>
	int GetYellowCornersConfiguration () {
		algorithm.Clear ();
		List<string> yellowFaceColors = GetYellowFaceColors ();
		List<string> yellowCornersColors = GetYellowCornersColors ();

		string y00 = yellowFaceColors [0];
		string y02 = yellowFaceColors [2];
		string y20 = yellowFaceColors [6];
		string y22 = yellowFaceColors [8];

		string y00_o = yellowCornersColors [0];
		string y00_g = yellowCornersColors [1];
		string y02_g = yellowCornersColors [2];
		string y02_r = yellowCornersColors [3];
		string y20_o = yellowCornersColors [4];
		string y20_b = yellowCornersColors [5];
		string y22_b = yellowCornersColors [6];
		string y22_r = yellowCornersColors [7];

		if ((y00_o == orange) && (y00_g == green) &&
			(y02_g == green) && (y02_r == red) &&
			(y20_o == orange) && (y20_b == blue) &&
			(y22_b == blue) && (y22_r == red)) {
			yellowCornered = true;
			topLayerCornered = true;
			return 0;
		}

		if ((y00_o == orange) && (y00_g == green) &&
			(y02_g == green) && (y02_r == red)) {
			return 6;
		} else if ((y02_g == green) && (y02_r == red)
			&& (y22_b == blue) && (y22_r == red)) {
			return 7;
		} else if ((y20_o == orange) && (y20_b == blue)
			&& (y22_b == blue) && (y22_r == red)) {
			return 8;
		} else if ((y00_o == orange) && (y00_g == green)
			&& (y20_o == orange) && (y20_b == blue)) {
			return 9;
		} else if ((y00_o == orange) && (y00_g == green)
			&& (y22_b == blue) && (y22_r == red)) {
			return 6;
		} else if ((y02_g == green) && (y02_r == red)
			&& (y20_o == orange) && (y20_b == blue)) {
			return 6;
		} else if (yellowCornered) {
			return 10;
		}

		int corners = 0;
		foreach (string color in yellowCornersColors) {
			if (color == yellow) {
				corners++;
			}
		}

		if (corners == 0) {
			yellowCornered = true;
		}

		if (!yellowCornered) {
			if (corners == 4) {

				if (y00_g == yellow) {
					algorithm.Add (10);
					return 5;
				} else if (y02_r == yellow) {
					algorithm.Add (10);
					algorithm.Add (10);
					return 5;
				} else if (y20_o == yellow) {
				} else if (y22_b == yellow) {
					algorithm.Add (11);
					return 5;
				}

			} else if (corners == 3) {

				if (y00 == yellow) {
					algorithm.Add (10);
					return 5;
				} else if (y02 == yellow) {
					algorithm.Add (10);
					algorithm.Add (10);
					return 5;
				} else if (y20 == yellow) {
				} else if (y22 == yellow) {
					algorithm.Add (11);
					return 5;
				}

			} else if (corners <= 2) {

				if (y00_o == yellow) {
					algorithm.Add (10);
					return 5;
				} else if (y02_g == yellow) {
					algorithm.Add (10);
					algorithm.Add (10);
					return 5;
				} else if (y20_b == yellow) {
				} else if (y22_r == yellow) {
					algorithm.Add (11);
					return 5;
				}
			}
		}
		return 0;
	}

	/// <summary>
	/// Gets the configuration of the Yellow Edges.
	/// </summary>
	/// <returns>The Yellow Edges configuration.</returns>
	/// <remarks>
	/// This method determines which algorithm to perform according to the current configuration of the
	/// Yellow Edges and the orientation of the colors of the mismatched Yellow Edges.
	int GetYellowEdgesConfiguration () {
		algorithm.Clear ();
		List<string> yellowEdgeColors = GetYellowEdgesColors ();

		string yg = yellowEdgeColors [0];
		string yo = yellowEdgeColors [1];
		string yr = yellowEdgeColors [2];
		string yb = yellowEdgeColors [3];

		if ((yg == green) && (yo == orange) &&
		    (yr == red) && (yb == blue)) {
			topLayerEdged = true;
			return 0;
		}
			
		if (yg == green) {
			if (yo == blue) {
				return 1;
			} else if (yo == red) {
				return 2;
			}
		} else if (yo == orange) {
			if (yb == red) {
				return 3;
			} else if (yb == green) {
				return 4;
			}
		} else if (yr == red) {
			if (yg == orange) {
				return 5;
			} else if (yg == blue) {
				return 6;
			}
		} else if (yb == blue) {
			if (yr == green) {
				return 7;
			} else if (yr == orange) {
				return 8;
			}
		}
		return 1;
	}
				
	/// <summary>
	/// Gets the colors of the Yellow Edge pieces shared on the Red, Blue, Purple, and Green sides.
	/// </summary>
	/// <returns>A List of the colors of each Yellow Edge pieces.</returns>
	/// <remarks>
	/// In the List return variable:
	/// The index 0 corresponds to the edge color of the cube at index 501.
	/// The index 1 corresponds to the edge color of the cube at index 510.
	/// The index 2 corresponds to the edge color of the cube at index 512.
	/// The index 3 corresponds to the edge color of the cube at index 521.
	/// </remarks>
	List<string> GetYellowEdgesColors () {
		List<GameObject> edgeCubes = SortYellowFace ();

		//remove non-edge cubes
		edgeCubes.RemoveAt (8);
		edgeCubes.RemoveAt (6);
		edgeCubes.RemoveAt (4);
		edgeCubes.RemoveAt (2);
		edgeCubes.RemoveAt (0);

		List<string> yellowEdgesColors = new List<string> ();

		// For each of the Yellow Edges, with the name of the Edge, create a List of string
		// variables with the names of potential colors the Edge has.
		foreach (GameObject cube in edgeCubes) {
			List<string> stickerIDs = new List<string> ();
			string rStickerID = red + cube.name.Substring (4);
			string bStickerID = blue + cube.name.Substring (4);
			string oStickerID = orange + cube.name.Substring (4);
			string gStickerID = green + cube.name.Substring (4);

			stickerIDs.Add (rStickerID);
			stickerIDs.Add (bStickerID);
			stickerIDs.Add (oStickerID);
			stickerIDs.Add (gStickerID);

			// For each potential color of the Edge piece, check if the Edge has a child by the same name.
			// If it does, that Edge has that color.
			foreach (string id in stickerIDs) {
				Transform sticker = cube.transform.Find (id.ToString ());
				if (sticker != null) {
					Vector3 p = sticker.transform.position;
					if (b_bounds.Contains (p)) {
						string color = sticker.name [0].ToString ();
						yellowEdgesColors.Add (color);
					}
				}
			}
		}
		return yellowEdgesColors;
	}
		
	/// <summary>
	/// Gets the colors of the Yellow Corner pieces shared on the Red, Blue, Purple, and Green sides.
	/// </summary>
	/// <returns>A List of the colors of each Yellow Corner pieces.</returns>
	/// <remarks>
	/// In the List return variable:
	/// The indices 0 and 1 correspond to the corner colors of the cube at index 500.
	/// The indices 2 and 3 correspond to the corner colors of the cube at index 502.
	/// The indices 4 and 5 correspond to the corner colors of the cube at index 520.
	/// The indices 6 and 7 correspond to the corner colors of the cube at index 522.
	/// </remarks>
	List<string> GetYellowCornersColors () {
		List<GameObject> cornerCubes = SortYellowFace ();

		//remove non-corner cubes
		cornerCubes.RemoveAt (7);
		cornerCubes.RemoveAt (5);
		cornerCubes.RemoveAt (4);
		cornerCubes.RemoveAt (3);
		cornerCubes.RemoveAt (1);

		List<string> yellowCornersColors = new List<string> ();
		for (int s = 0; s < 8; s++) {
			yellowCornersColors.Add ("");
		}

		int cubeIndex = 0;

		// For each of the Yellow Corners, with the name of the Corner, create a List of string
		// variables with the names of potential colors the Corner has.
		foreach (GameObject cube in cornerCubes) {
			List<string> stickerIDs = new List<string> ();
			string yStickerID = yellow + cube.name.Substring (4);
			string rStickerID = red + cube.name.Substring (4);
			string bStickerID = blue + cube.name.Substring (4);
			string oStickerID = orange + cube.name.Substring (4);
			string gStickerID = green + cube.name.Substring (4);

			stickerIDs.Add (yStickerID);
			stickerIDs.Add (rStickerID);
			stickerIDs.Add (bStickerID);
			stickerIDs.Add (oStickerID);
			stickerIDs.Add (gStickerID);

			// For each potential color of the Corner piece, check if the Corner has a child by the same name.
			// If it does, that Corner has that color.
			foreach (string id in stickerIDs) {
				Transform sticker = cube.transform.Find (id.ToString ());
				if (sticker != null) {
					Vector3 p = sticker.transform.position;
					if ((b_bounds.Contains (p)) && (d_bounds.Contains (p))) {
						if (cubeIndex == 0) {
							yellowCornersColors [0] = id[0].ToString ();
						} else if (cubeIndex == 1) {
							yellowCornersColors [3] = id[0].ToString ();
						}
					}

					if ((b_bounds.Contains (p)) && (l_bounds.Contains (p))) {
						if (cubeIndex == 0) {
							yellowCornersColors [1] = id[0].ToString ();
						} else if (cubeIndex == 2) {
							yellowCornersColors [5] = id[0].ToString ();
						}
					}

					if ((b_bounds.Contains (p)) && (r_bounds.Contains (p))) {
						if (cubeIndex == 1) {
							yellowCornersColors [2] = id[0].ToString ();
						} else if (cubeIndex == 3) {
							yellowCornersColors [6] = id[0].ToString ();
						}
					}

					if ((b_bounds.Contains (p)) && (u_bounds.Contains (p))) {
						if (cubeIndex == 2) {
							yellowCornersColors [4] = id[0].ToString ();
						} else if (cubeIndex == 3) {
							yellowCornersColors [7] = id[0].ToString ();
						}
					}
				}
			}
			cubeIndex++;
		}
		return yellowCornersColors;
	}
		
	/// <summary>
	/// Gets the colors of the pieces on the Yellow side that are not shared by another side.
	/// </summary>
	/// <returns>The colors of the pieces on the Yellow side that are not shared by another side.</returns>
	List<string> GetYellowFaceColors () {
		List<GameObject> sortedYellowFace = SortYellowFace ();
		List<string> yellowFaceColors = new List<string> ();
		for (int s = 0; s < 9; s++) {
			yellowFaceColors.Add ("");
		}

		// Check if the color is Yellow.
		int cubeIndex = 0;
		foreach (GameObject cube in sortedYellowFace) {
			string stickerID = yellow + cube.name.Substring (4);
			Transform sticker = cube.transform.Find (stickerID.ToString ());
			if (!b_bounds.Contains (sticker.transform.position)) {
				yellowFaceColors [cubeIndex] = yellow;
			}
			cubeIndex++;
		}

		// Check if the color is Red.
		cubeIndex = 0;
		foreach (GameObject cube in sortedYellowFace) {
			string stickerID = red + cube.name.Substring (4);
			Transform sticker = cube.transform.Find (stickerID.ToString ());
			if (sticker != null) {
				if (!b_bounds.Contains (sticker.transform.position)) {
					yellowFaceColors [cubeIndex] = red;
				}
			}
			cubeIndex++;
		}

		// Check if the color is Blue.
		cubeIndex = 0;
		foreach (GameObject cube in sortedYellowFace) {
			string stickerID = blue + cube.name.Substring (4);
			Transform sticker = cube.transform.Find (stickerID.ToString ());
			if (sticker != null) {
				if (!b_bounds.Contains (sticker.transform.position)) {
					yellowFaceColors [cubeIndex] = blue;
				}
			}
			cubeIndex++;
		}

		// Check if the color is Purple.
		cubeIndex = 0;
		foreach (GameObject cube in sortedYellowFace) {
			string stickerID = orange + cube.name.Substring (4);
			Transform sticker = cube.transform.Find (stickerID.ToString ());
			if (sticker != null) {
				if (!b_bounds.Contains (sticker.transform.position)) {
					yellowFaceColors [cubeIndex] = orange;
				}
			}
			cubeIndex++;
		}

		// Check if the color is Green.
		cubeIndex = 0;
		foreach (GameObject cube in sortedYellowFace) {
			string stickerID = green + cube.name.Substring (4);
			Transform sticker = cube.transform.Find (stickerID.ToString ());
			if (sticker != null) {
				if (!b_bounds.Contains (sticker.transform.position)) {
					yellowFaceColors [cubeIndex] = green;
				}
			}
			cubeIndex++;
		}
		return yellowFaceColors;
	}
		
	/// <summary>
	/// Sorts the Yellow Face.
	/// </summary>
	/// <returns>An indexed List of the pieces on the Yellow side.</returns>
	List<GameObject> SortYellowFace () {
		List<GameObject> yellowFaceCubes = GetFaceCubes (b_bounds);
		turning = false;
		List<GameObject> sortedYellowFace = new List<GameObject> ();
		for (int s = 0; s < 9; s++) {
			sortedYellowFace.Add (allCubes [s]);
		}

		// Match the cube with the correct index according to its Center.
		foreach (GameObject cube in yellowFaceCubes) {
			string indexKey = GetPieceIndex (cube, yellow);
			int faceIndex = IntParseFast (indexKey [0].ToString ());
			int rowIndex = IntParseFast (indexKey [1].ToString ());
			int colIndex = IntParseFast (indexKey [2].ToString ());
			if (faceIndex == 1) {
				if (colIndex == 0) {
					sortedYellowFace [2] = cube;
				} else if (colIndex == 1) {
					sortedYellowFace [5] = cube;
				} else if (colIndex == 2) {
					sortedYellowFace [8] = cube;
				}
			}
			if (faceIndex == 2) {
				if (colIndex == 0) {
					sortedYellowFace [8] = cube;
				} else if (colIndex == 1) {
					sortedYellowFace [7] = cube;
				} else if (colIndex == 2) {
					sortedYellowFace [6] = cube;
				}
			}
			if (faceIndex == 3) {
				if (colIndex == 0) {
					sortedYellowFace [6] = cube;
				} else if (colIndex == 1) {
					sortedYellowFace [3] = cube;
				} else if (colIndex == 2) {
					sortedYellowFace [0] = cube;
				}
			}
			if (faceIndex == 4) {
				if (colIndex == 0) {
					sortedYellowFace [0] = cube;
				} else if (colIndex == 1) {
					sortedYellowFace [1] = cube;
				} else if (colIndex == 2) {
					sortedYellowFace [2] = cube;
				}
			}
			if (faceIndex == 5) {
				if (rowIndex == 0) {
					if (colIndex == 0) {
						sortedYellowFace [0] = cube;
					} else if (colIndex == 1) {
						sortedYellowFace [1] = cube;
					} else if (colIndex == 2) {
						sortedYellowFace [2] = cube;
					}
				} else if (rowIndex == 1) {
					if (colIndex == 0) {
						sortedYellowFace [3] = cube;
					} else if (colIndex == 1) {
						sortedYellowFace [4] = cube;
					} else if (colIndex == 2) {
						sortedYellowFace [5] = cube;
					}
				} else if (rowIndex == 2) {
					if (colIndex == 0) {
						sortedYellowFace [6] = cube;
					} else if (colIndex == 1) {
						sortedYellowFace [7] = cube;
					} else if (colIndex == 2) {
						sortedYellowFace [8] = cube;
					}
				}
			}
		}
		return sortedYellowFace;
	}
	#endregion

	// Templates for algorithm population.
	#region Index Templates
	// EDGES
	//	IEnumerator WhiteXred (string indexKey) {
	//
	//		int faceIndex = IntParseFast (indexKey [0].ToString ());
	//		int rowIndex = IntParseFast (indexKey [1].ToString ());
	//		int colIndex = IntParseFast (indexKey [2].ToString ());
	//		switch (faceIndex) {
	//		case 0:
	//			switch (rowIndex) {
	//			case 0:
	//				break;
	//			case 1:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				break;
	//			}
	//			break;
	//
	//		case 1:
	//			switch (rowIndex) {
	//			case 0:
	//				break;
	//			case 1:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				break;
	//			}
	//			break;
	//
	//		case 2:
	//			switch (rowIndex) {
	//			case 0:
	//				break;
	//			case 1:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				break;
	//			}
	//			break;
	//
	//		case 3:
	//			switch (rowIndex) {
	//			case 0:
	//				break;
	//			case 1:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				break;
	//			}
	//			break;
	//
	//		case 4:
	//			switch (rowIndex) {
	//			case 0:
	//				break;
	//			case 1:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				break;
	//			}
	//			break;
	//
	//		case 5:
	//			switch (rowIndex) {
	//			case 0:
	//				break;
	//			case 1:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				break;
	//			}
	//			break;
	//		}
	//		yield return null;
	//	}
	//
	//
	//
	// CORNERS
	//	IEnumerator WhiteRedBlueCorner (string indexKey) {
	//
	//		int faceIndex = IntParseFast (indexKey [0].ToString ());
	//		int rowIndex = IntParseFast (indexKey [1].ToString ());
	//		int colIndex = IntParseFast (indexKey [2].ToString ());
	//		switch (faceIndex) {
	//		case 0:
	//			switch (rowIndex) {
	//			case 0:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			}
	//			break;
	//
	//		case 1:
	//			switch (rowIndex) {
	//			case 0:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			}
	//			break;
	//
	//		case 2:
	//			switch (rowIndex) {
	//			case 0:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			}
	//			break;
	//
	//		case 3:
	//			switch (rowIndex) {
	//			case 0:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			}
	//			break;
	//
	//		case 4:
	//			switch (rowIndex) {
	//			case 0:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			}
	//			break;
	//
	//		case 5:
	//			switch (rowIndex) {
	//			case 0:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			case 2:
	//				if (colIndex == 0) {
	//				}
	//				if (colIndex == 2) {
	//				}
	//				break;
	//			}
	//			break;
	//		}
	//		yield return null;
	//	}
	#endregion

	#region Turn Mechanisms

	/// <summary>
	/// Rotates the F side clockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator F__cw () {
		float angle = 0;
		Vector3 dir;
		Vector3 dir2;
		if (sunnySideUp < 0) {
			dir = Vector3.down;
			dir2 = Vector3.up;
		} else {
			dir = Vector3.up;
			dir2 = Vector3.down;
		}
		List<GameObject> faceCubes = GetFaceCubes (f_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (dir * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (dir2 * error, Space.World);
				}
			}
		}
		moves.Add (0);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the F side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator F_ccw () {
		float angle = 0;
		Vector3 dir;
		Vector3 dir2;
		if (sunnySideUp < 0) {
			dir = Vector3.up;
			dir2 = Vector3.down;
		} else {
			dir = Vector3.down;
			dir2 = Vector3.up;
		}
		List<GameObject> faceCubes = GetFaceCubes (f_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (dir * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (dir2 * error, Space.World);
				}
			}
		}
		moves.Add (1);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the D side clockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator D__cw () {
		float angle = 0;
		List<GameObject> faceCubes = GetFaceCubes (d_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (Vector3.right * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (Vector3.left * error, Space.World);
				}
			}
		}
		moves.Add (2);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the D side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator D_ccw () {
		float angle = 0;
		List<GameObject> faceCubes = GetFaceCubes (d_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (Vector3.left * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (Vector3.right * error, Space.World);
				}
			}
		}
		moves.Add (3);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the R side clockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator R__cw () {
		float angle = 0;
		Vector3 dir;
		Vector3 dir2;
		if (sunnySideUp < 0) {
			dir = Vector3.back;
			dir2 = Vector3.forward;
		} else {
			dir = Vector3.forward;
			dir2 = Vector3.back;
		}
		List<GameObject> faceCubes = GetFaceCubes (r_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (dir * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (dir2 * error, Space.World);
				}
			}
		}
		moves.Add (4);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the R side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator R_ccw () {
		float angle = 0;
		Vector3 dir;
		Vector3 dir2;
		if (sunnySideUp < 0) {
			dir = Vector3.forward;
			dir2 = Vector3.back;
		} else {
			dir = Vector3.back;
			dir2 = Vector3.forward;
		}
		List<GameObject> faceCubes = GetFaceCubes (r_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (dir * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (dir2 * error, Space.World);
				}
			}
		}
		moves.Add (5);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the U side clockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator U__cw () {
		float angle = 0;
		List<GameObject> faceCubes = GetFaceCubes (u_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (Vector3.left * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (Vector3.right * error, Space.World);
				}
			}
		}
		moves.Add (6);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the U side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator U_ccw () {
		float angle = 0;
		List<GameObject> faceCubes = GetFaceCubes (u_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (Vector3.right * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (Vector3.left * error, Space.World);
				}
			}
		}
		moves.Add (7);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the L side clockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator L__cw () {
		float angle = 0;
		Vector3 dir;
		Vector3 dir2;
		if (sunnySideUp < 0) {
			dir = Vector3.forward;
			dir2 = Vector3.back;
		} else {
			dir = Vector3.back;
			dir2 = Vector3.forward;
		}
		List<GameObject> faceCubes = GetFaceCubes (l_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (dir * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (dir2 * error, Space.World);
				}
			}
		}
		moves.Add (8);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the L side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator L_ccw () {
		float angle = 0;
		Vector3 dir;
		Vector3 dir2;
		if (sunnySideUp < 0) {
			dir = Vector3.back;
			dir2 = Vector3.forward;
		} else {
			dir = Vector3.forward;
			dir2 = Vector3.back;
		}
		List<GameObject> faceCubes = GetFaceCubes (l_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (dir * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (dir2 * error, Space.World);
				}
			}
		}
		moves.Add (9);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the B side clockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator B__cw () {
		float angle = 0;
		Vector3 dir;
		Vector3 dir2;
		if (sunnySideUp < 0) {
			dir = Vector3.down;
			dir2 = Vector3.up;
		} else {
			dir = Vector3.up;
			dir2 = Vector3.down;
		}
		List<GameObject> faceCubes = GetFaceCubes (b_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (dir * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (dir2 * error, Space.World);
				}
			}
		}
		moves.Add (10);
		turning = false;
		yield return null;
	}

	/// <summary>
	/// Rotates the B side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is an iterator in order to "animate" the rotation.
	/// </remarks>
	IEnumerator B_ccw () {
		float angle = 0;
		Vector3 dir;
		Vector3 dir2;
		if (sunnySideUp < 0) {
			dir = Vector3.up;
			dir2 = Vector3.down;
		} else {
			dir = Vector3.down;
			dir2 = Vector3.up;
		}
		List<GameObject> faceCubes = GetFaceCubes (b_bounds);
		while (angle < 90) {
			foreach (GameObject cube in faceCubes) {
				cube.transform.Rotate (dir * speed * Time.deltaTime, Space.World);
			}
			angle += speed * Time.deltaTime;
			if (angle < 90) {
				yield return new WaitForSeconds (0.01f);
			} else if (angle > 90) {
				float error = angle - 90;
				foreach (GameObject cube in faceCubes) {
					cube.transform.Rotate (dir2 * error, Space.World);
				}
			}
		}
		moves.Add (11);
		turning = false;
		yield return null;
	}
	#endregion

	/// <summary>
	/// Performs the algorithm.
	/// </summary>
	/// <param name="algorithm">Algorithm.</param>
	public IEnumerator PerformAlgorithm (List<int> algorithm) {
		algorithmDone = false;
		foreach (int move in algorithm) {
			turning = true;
			switch (move) {
			case 0:
				StartCoroutine (F__cw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 1:
				StartCoroutine (F_ccw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 2:
				StartCoroutine (D__cw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 3:
				StartCoroutine (D_ccw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 4:
				StartCoroutine (R__cw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 5:
				StartCoroutine (R_ccw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 6:
				StartCoroutine (U__cw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 7:
				StartCoroutine (U_ccw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 8:
				StartCoroutine (L__cw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 9:
				StartCoroutine (L_ccw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 10:
				StartCoroutine (B__cw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			case 11:
				StartCoroutine (B_ccw ());
				yield return new WaitForSeconds (turnWait);
				while (turning) {
					yield return null;
				}
				break;
			}
		}
		algorithmDone = true;
	}
		
	/// <summary>
	/// Gets the algorithm. Used by hint.
	/// </summary>
	/// <returns>The algorithm of the next step of the solution.</returns>
	public List<int> GetAlgorithm () {
		algorithm.Clear ();
		int step = GetStep ();
		switch (step) {
		// step 0 corresponds to a completely solved Rubik's Cube.
		case 0:
			List<int> solvedFlag = new List<int> ();
			solvedFlag.Add (12);
			return solvedFlag;
		case 1:
			string wr = GetPieceIndex (cube20, white);
			StartCoroutine (WhiteXRed (wr));
			break;
		case 2:
			string wb = GetPieceIndex (cube24, white);
			StartCoroutine (WhiteXBlue (wb));
			break;
		case 3:
			string wo = GetPieceIndex (cube26, white);
			StartCoroutine (WhiteXPurple (wo));
			break;
		case 4:
			string wg = GetPieceIndex (cube22, white);
			StartCoroutine (WhiteXGreen (wg));
			break;
		case 5:
			string wrb = GetPieceIndex (cube21, red);
			StartCoroutine (WhiteXRedXBlue (wrb));
			break;
		case 6:
			string wbo = GetPieceIndex (cube00, blue);
			StartCoroutine (WhiteXBlueXPurple (wbo));
			break;
		case 7:
			string wog = GetPieceIndex (cube25, orange);
			StartCoroutine (WhiteXPurpleXGreen (wog));
			break;
		case 8:
			string wgr = GetPieceIndex (cube19, green);
			StartCoroutine (WhiteXGreenXRed (wgr));
			break;
		case 9:
			string rb = GetPieceIndex (cube12, red);
			StartCoroutine (RedXBlue (rb));
			break;
		case 10:
			string bo = GetPieceIndex (cube18, blue);
			StartCoroutine (BlueXPurple (bo));
			break;
		case 11:
			string og = GetPieceIndex (cube16, orange);
			StartCoroutine (PurpleXGreen (og));
			break;
		case 12:
			string gr = GetPieceIndex (cube10, green);
			StartCoroutine (GreenXRed (gr));
			break;
		case 13:
			SetAlgorithmForYellowStep (13);
			break;
		case 14:
			yellowCornered = false;
			SetAlgorithmForYellowStep (14);
			break;
		case 15:
			SetAlgorithmForYellowStep (15);
			break;
		case 16:
			SetAlgorithmForYellowStep (16);
			break;
		}
		return algorithm;
	}

	/// <summary>
	/// Gets the next step of the solution.
	/// </summary>
	/// <returns>The next step of the algorithm.</returns>
	/// <remarks>
	/// Returns 0 if the Rubik's Cube is completely solved.
	/// </remarks>
	int GetStep () {
		string solved_wr = "012";
		string solved_wb = "001";
		string solved_wo = "010";
		string solved_wg = "021";

		string solved_wrb = "102";
		string solved_wbo = "202";
		string solved_wog = "302";
		string solved_wgr = "402";

		string solved_rb = "112";
		string solved_bo = "212";
		string solved_og = "312"; 
		string solved_gr = "412";

		string solved_yx1 = "510";
		string solved_yx2 = "521";
		string solved_yx3 = "501"; 
		string solved_yx4 = "512";

		string solved_yc1 = "520";
		string solved_yc2 = "500";
		string solved_yc3 = "522"; 
		string solved_yc4 = "502";

		string solved_yog = "322";
		string solved_ygr = "422";
		string solved_ybo = "320"; 
		string solved_yrb = "220";

		string solved_yg = "421";
		string solved_yo = "321";
		string solved_yr = "121"; 
		string solved_yb = "221";

		string wr = GetPieceIndex (cube20, white);
		string wb = GetPieceIndex (cube24, white);
		string wo = GetPieceIndex (cube26, white);
		string wg = GetPieceIndex (cube22, white);

		string wrb = GetPieceIndex (cube21, red);
		string wbo = GetPieceIndex (cube00, blue);
		string wog = GetPieceIndex (cube25, orange);
		string wgr = GetPieceIndex (cube19, green);

		string rb = GetPieceIndex (cube12, red);
		string bo = GetPieceIndex (cube18, blue);
		string og = GetPieceIndex (cube16, orange);
		string gr = GetPieceIndex (cube10, green);

		string yx1 = GetPieceIndex (cube04, yellow);
		string yx2 = GetPieceIndex (cube08, yellow);
		string yx3 = GetPieceIndex (cube02, yellow);
		string yx4 = GetPieceIndex (cube06, yellow);

		string yc1 = GetPieceIndex (cube07, yellow);
		string yc2 = GetPieceIndex (cube01, yellow);
		string yc3 = GetPieceIndex (cube09, yellow);
		string yc4 = GetPieceIndex (cube03, yellow);

		string yog = GetPieceIndex (cube07, orange);
		string ygr = GetPieceIndex (cube01, green);
		string ybo = GetPieceIndex (cube09, orange);
		string yrb = GetPieceIndex (cube03, blue);

		string yg = GetPieceIndex (cube04, green);
		string yo = GetPieceIndex (cube08, orange);
		string yr = GetPieceIndex (cube02, red);
		string yb = GetPieceIndex (cube06, blue);


		if (solved_wr != wr) {
			return 1;
		}
		if (solved_wb != wb) {
			return 2;
		}
		if (solved_wo != wo) {
			return 3;
		}
		if (solved_wg != wg) {
			return 4;
		}
		if (solved_wrb != wrb) {
			return 5;
		}
		if (solved_wbo != wbo) {
			return 6;
		}
		if (solved_wog != wog) {
			return 7;
		}
		if (solved_wgr != wgr) {
			return 8;
		}
		if (solved_rb != rb) {
			return 9;
		}
		if (solved_bo != bo) {
			return 10;
		}
		if (solved_og != og) {
			return 11;
		}
		if (solved_gr != gr) {
			return 12;
		}

		if ((solved_yx1 != yx1) && (solved_yx1 != yx2) &&
			(solved_yx1 != yx3) && (solved_yx1 != yx4)) {
			return 13;
		}
		if ((solved_yx2 != yx1) && (solved_yx2 != yx2) &&
			(solved_yx2 != yx3) && (solved_yx2 != yx4)) {
			return 13;
		}
		if ((solved_yx3 != yx1) && (solved_yx3 != yx2) &&
			(solved_yx3 != yx3) && (solved_yx3 != yx4)) {
			return 13;
		}
		if ((solved_yx4 != yx1) && (solved_yx4 != yx2) &&
			(solved_yx4 != yx3) && (solved_yx4 != yx4)) {
			return 13;
		}

		if ((solved_yc1 != yc1) && (solved_yc1 != yc2) &&
			(solved_yc1 != yc3) && (solved_yc1 != yc4)) {
			return 14;
		}
		if ((solved_yc2 != yc1) && (solved_yc2 != yc2) &&
			(solved_yc2 != yc3) && (solved_yc2 != yc4)) {
			return 14;
		}
		if ((solved_yc3 != yc1) && (solved_yc3 != yc2) &&
			(solved_yc3 != yc3) && (solved_yc3 != yc4)) {
			return 14;
		}
		if ((solved_yc4 != yc1) && (solved_yc4 != yc2) &&
			(solved_yc4 != yc3) && (solved_yc4 != yc4)) {
			return 14;
		}

		if (solved_yog != yog) {
			return 15;
		}
		if (solved_ygr != ygr) {
			return 15;
		}
		if (solved_ybo != ybo) {
			return 15;
		}
		if (solved_yrb != yrb) {
			return 15;
		}

		if (solved_yg != yg) {
			return 16;
		}
		if (solved_yo != yo) {
			return 16;
		}
		if (solved_yr != yr) {
			return 16;
		}
		if (solved_yb != yb) {
			return 16;
		}
		return 0;
	}

	/// <summary>
	/// Gets the index of the piece.
	/// </summary>
	/// <returns>The piece index.</returns>
	/// <param name="cube">The piece.</param>
	/// <param name="stickerColor">The reference color of the piece.</param>
	/// <remarks>
	/// For a return variable named pieceIndex:
	/// pieceIndex [0] is the side of the Rubik's Cube this piece is on.
	/// pieceIndex [1] is the row of the side the piece is on.
	/// pieceIndex [2] is the column of the side the piece is on.
	/// </remarks>
	string GetPieceIndex (GameObject cube, string stickerColor) {
		Vector3 cubeCenter = cube.GetComponent<BoxCollider> ().bounds.center;
		int x = Mathf.RoundToInt (cubeCenter.x);
		int y = Mathf.RoundToInt (cubeCenter.y);
		int z = Mathf.RoundToInt (cubeCenter.z);

		// Determine which sides the piece is on.
		List<GameObject> cubeFacets = new List<GameObject> ();
		foreach (GameObject face in allFaces) {
			if (face.GetComponent<MeshCollider> ().bounds.Contains(cubeCenter)) {
				cubeFacets.Add (face);
			}
		}

		string stickerID = stickerColor + cube.name.Substring (4);
		Transform sticker = cube.transform.Find (stickerID.ToString());
		string stickerFace = null;

		if (sticker == null) {
			print (cube.name);
			print (stickerID);
		}



		foreach (GameObject face in cubeFacets) {
			//print (face);
			if (!face.GetComponent<MeshCollider> ().bounds.Contains (sticker.transform.position)) {
				stickerFace = face.GetComponent<MeshCollider> ().name [0].ToString();
				//print (sticker);
				//print (stickerFace);
			}
		}
		//print (cubeCenter);
		string indexKey = ConvertPositionToIndex (stickerFace, x, y, z);

		//print (indexKey);
		return indexKey;
	}
		
	/// <summary>
	/// Converts the position of the piece to the corresponding index.
	/// </summary>
	/// <returns>The position to index.</returns>
	/// <param name="face">Face.</param>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	/// <param name="z">The z coordinate.</param>
	string ConvertPositionToIndex (string face, int x, int y, int z) {
		// TODO: CREATE EXCEPTION HANDLER

		// If the Yellow side is currently the top side, the y and z coordinates must be multiplied
		// by negative one to obtain the correct index.
		if (sunnySideUp < 0) {
			y *= -1;
			z *= -1;
		}

		// SIDE F
		if (face == "F") {
			if (x == -1 && y == 1 && z == -1) {
				return "000";
			}
			if (x == -1 && y == 1 && z == 0) {
				return "001";
			}
			if (x == -1 && y == 1 && z == 1) {
				return "002";
			}
			if (x == 0 && y == 1 && z == -1) {
				return "010";
			}
			if (x == 0 && y == 1 && z == 0) {
				return "011";
			}
			if (x == 0 && y == 1 && z == 1) {
				return "012";
			}
			if (x == 1 && y == 1 && z == -1) {
				return "020";
			}
			if (x == 1 && y == 1 && z == 0) {
				return "021";
			}
			if (x == 1 && y == 1 && z == 1) {
				return "022";
			}
		}
		// SIDE R
		if (face == "R") {
			if (x == 1 && y == 1 && z == 1) {
				return "100";
			}
			if (x == 0 && y == 1 && z == 1) {
				return "101";
			}
			if (x == -1 && y == 1 && z == 1) {
				return "102";
			}
			if (x == 1 && y == 0 && z == 1) {
				return "110";
			}
			if (x == 0 && y == 0 && z == 1) {
				return "111";
			}
			if (x == -1 && y == 0 && z == 1) {
				return "112";
			}
			if (x == 1 && y == -1 && z == 1) {
				return "120";
			}
			if (x == 0 && y == -1 && z == 1) {
				return "121";
			}
			if (x == -1 && y == -1 && z == 1) {
				return "122";
			}
		}
		// SIDE U
		if (face == "U") {
			if (x == -1 && y == 1 && z == 1) {
				return "200";
			}
			if (x == -1 && y == 1 && z == 0) {
				return "201";
			}
			if (x == -1 && y == 1 && z == -1) {
				return "202";
			}
			if (x == -1 && y == 0 && z == 1) {
				return "210";
			}
			if (x == -1 && y == 0 && z == 0) {
				return "211";
			}
			if (x == -1 && y == 0 && z == -1) {
				return "212";
			}
			if (x == -1 && y == -1 && z == 1) {
				return "220";
			}
			if (x == -1 && y == -1 && z == 0) {
				return "221";
			}
			if (x == -1 && y == -1 && z == -1) {
				return "222";
			}
		}
		// SIDE L
		if (face == "L") {
			if (x == -1 && y == 1 && z == -1) {
				return "300";
			}
			if (x == 0 && y == 1 && z == -1) {
				return "301";
			}
			if (x == 1 && y == 1 && z == -1) {
				return "302";
			}
			if (x == -1 && y == 0 && z == -1) {
				return "310";
			}
			if (x == 0 && y == 0 && z == -1) {
				return "311";
			}
			if (x == 1 && y == 0 && z == -1) {
				return "312";
			}
			if (x == -1 && y == -1 && z == -1) {
				return "320";
			}
			if (x == -0 && y == -1 && z == -1) {
				return "321";
			}
			if (x == 1 && y == -1 && z == -1) {
				return "322";
			}
		}
		// SIDE D
		if (face == "D") {
			if (x == 1 && y == 1 && z == -1) {
				return "400";
			}
			if (x == 1 && y == 1 && z == 0) {
				return "401";
			}
			if (x == 1 && y == 1 && z == 1) {
				return "402";
			}
			if (x == 1 && y == 0 && z == -1) {
				return "410";
			}
			if (x == 1 && y == 0 && z == 0) {
				return "411";
			}
			if (x == 1 && y == 0 && z == 1) {
				return "412";
			}
			if (x == 1 && y == -1 && z == -1) {
				return "420";
			}
			if (x == 1 && y == -1 && z == 0) {
				return "421";
			}
			if (x == 1 && y == -1 && z == 1) {
				return "422";
			}
		}
		// SIDE B
		if (face == "B") {
			if (x == 1 && y == -1 && z == -1) {
				return "500";
			}
			if (x == 1 && y == -1 && z == 0) {
				return "501";
			}
			if (x == 1 && y == -1 && z == 1) {
				return "502";
			}
			if (x == 0 && y == -1 && z == -1) {
				return "510";
			}
			if (x == 0 && y == -1 && z == 0) {
				return "511";
			}
			if (x == 0 && y == -1 && z == 1) {
				return "512";
			}
			if (x == -1 && y == -1 && z == -1) {
				return "520";
			}
			if (x == -1 && y == -1 && z == 0) {
				return "521";
			}
			if (x == -1 && y == -1 && z == 1) {
				return "522";
			}
		}
		return "";
	}

	/// <summary>
	/// Gets the pieces on a given side.
	/// </summary>
	/// <returns>The pieces on a given side.</returns>
	/// <param name="bound">The side.</param>
	List<GameObject> GetFaceCubes (Bounds bound) {
		List<GameObject> faceCubes = new List<GameObject> ();
		allCubesCenters = GetCubesCenters ();
		foreach (Vector3 center in allCubesCenters) {
			if (bound.Contains (center)) {
				int i = allCubesCenters.IndexOf (center);
				faceCubes.Add (allCubes [i]);
			}
		}
		turning = true;
		return faceCubes;
	}

	/// <summary>
	/// Gets the centers of the pieces.
	/// </summary>
	/// <returns>The centers of the pieces.</returns>
	List<Vector3> GetCubesCenters () {
		allCubesCenters.Clear ();
		foreach (GameObject cube in allCubes) {
			Vector3 cubeCenter = cube.GetComponent<BoxCollider> ().bounds.center;
			allCubesCenters.Add (cubeCenter);
		}
		return allCubesCenters;
	}

	/// <summary>
	/// Swaps the top view of the Rubik's Cube between Yellow and White.
	/// </summary>
	IEnumerator SwapTopView () {
		while (turning) {
			yield return null;
		}
		while (!algorithmDone) {
			yield return null;
		}
		if (hinting) {
			// TODO: FIX HINT FOR INVERTED CUBE
		}
		doUpSwap = false;
		sunnySideUp *= -1;
		Vector3 sun = new Vector3 (180, 0, 0);
		rubiksCube.transform.rotation *= Quaternion.Euler (sun);
		SetFaceTransforms ();
	}

	/// <summary>
	/// Sets the transforms of the sides whenever the top side of the Rubik's Cube is swapped.
	/// </summary>
	void SetFaceTransforms () {
		Vector3 oldFpos = allFaces [0].transform.position;
		allFaces [0].transform.position = allFaces [5].transform.position;
		allFaces [5].transform.position = oldFpos;

		Vector3 oldRpos = allFaces [2].transform.position;
		allFaces [2].transform.position = allFaces [4].transform.position;
		allFaces [4].transform.position = oldRpos;

		for (int i = 0; i < allFaces.Count; i++) {
			allFacesBounds [i] = allFaces [i].GetComponent<MeshCollider> ().bounds;
		}

		f_bounds = allFacesBounds [0];
		d_bounds = allFacesBounds [1];
		r_bounds = allFacesBounds [2];
		u_bounds = allFacesBounds [3];
		l_bounds = allFacesBounds [4];
		b_bounds = allFacesBounds [5];
	}

	/// <summary>
	/// Prints the rotations done during this solution.
	/// </summary>
	public void PrintMoves () {
		foreach (int move in moves) {
			switch (move) {
			case 0:
				print ("F");
				break;
			case 1:
				print ("F'");
				break;
			case 2:
				print ("D");
				break;
			case 3:
				print ("D'");
				break;
			case 4:
				print ("R");
				break;
			case 5:
				print ("R'");
				break;
			case 6:
				print ("U");
				break;
			case 7:
				print ("U'");
				break;
			case 8:
				print ("L");
				break;
			case 9:
				print ("L'");
				break;
			case 10:
				print ("B");
				break;
			case 11:
				print ("B'");
				break;
			}
		}
	}

	/// <summary>
	/// Calls a coroutine to undo the last rotation in the List |moves|.
	/// </summary>
	public void Undo () {
		StartCoroutine (UndoMove ());
	}

	/// <summary>
	/// Undoes the last rotation in the List |moves|.
	/// </summary>
	IEnumerator UndoMove () {
		if (!solving) {
			if (turning) {
				yield break;
			}
			if (moves.Count > 0) {
				turning = true;
				int move = moves [moves.Count - 1];
				switch (move) {
				case 0:
					StartCoroutine (F_ccw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 1:
					StartCoroutine (F__cw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 2:
					StartCoroutine (D_ccw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 3:
					StartCoroutine (D__cw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 4:
					StartCoroutine (R_ccw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 5:
					StartCoroutine (R__cw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 6:
					StartCoroutine (U_ccw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 7:
					StartCoroutine (U__cw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 8:
					StartCoroutine (L_ccw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 9:
					StartCoroutine (L__cw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 10:
					StartCoroutine (B_ccw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				case 11:
					StartCoroutine (B__cw ());
					yield return new WaitForSeconds (turnWait);
					while (turning) {
						yield return null;
					}
					break;
				}
				moves.RemoveAt (moves.Count - 1);	//remove the "undo" correction move
				moves.RemoveAt (moves.Count - 1);	//remove the original "undo" move
			} else {
				print ("No moves left to undo.");
			}
		}
		yield return null;
	}

	/// <summary>
	/// Calls a coroutine to stop the solution.
	/// </summary>
	public void StopSolve () {
		StartCoroutine (Stop ());
	}

	/// <summary>
	/// Stops the current solution.
	/// </summary>
	IEnumerator Stop () {
		while (turning) {
			yield return null;
		}
		StopAllCoroutines ();

		solving = false;
		turning = false;
		algorithmDone = false;

		whiteRed = false;
		whiteBlue = false;
		whiteOrange = false;
		whiteGreen = false;

		whiteCrossed = toggleWhiteCrossed;

		whiteRedBlue = false;
		whiteBlueOrange = false;
		whiteOrangeGreen = false;
		whiteGreenRed = false;

		whiteCornered = toggleWhiteCornered;

		redBlue = false;
		blueOrange = false;
		orangeGreen = false;
		greenRed = false;

		middleLayered = toggleMiddleLayered;

		yellowCrossed = false;
		yellowCornered = false;
		topLayerCornered = false;
		topLayerEdged = false;

		yellowCrossed = toggleYellowCrossed;
		yellowCornered = toggleYellowCornered;
		topLayerCornered = toggleTopLayerCornered;
		topLayerEdged = toggleTopLayerEdged;
		yield return null;
	}

	/// <summary>
	/// Changes the current scene to the Tutorial scene.
	/// </summary>
	public void GoToTutorial () {
		SceneManager.LoadScene ("_tutorial");
	}

	/// <summary>
	/// Gets the side on top.
	/// </summary>
	/// <returns>The side on top.</returns>
	public int GetUpFace () {
		return sunnySideUp;
	}

	/// <summary>
	/// Determines whether this instance is turning.
	/// </summary>
	/// <returns><c>true</c> if this instance is turning; otherwise, <c>false</c>.</returns>
	public bool IsTurning () {
		return turning;
	}

	/// <summary>
	/// Determines whether this instance is solving.
	/// </summary>
	/// <returns><c>true</c> if this instance is solving; otherwise, <c>false</c>.</returns>
	public bool IsSolving () {
		return solving;
	}

	/// <summary>
	/// Converts a string to an int.
	/// This method was taken from http://cc.davelozinski.com/c-sharp/fastest-way-to-convert-a-string-to-an-int
	/// I did not write this method.
	/// </summary>
	/// <returns>The converted int.</returns>
	/// <param name="value">The string to convert.</param>
	static int IntParseFast (string value) {
		int result = 0;
		for (int i = 0; i < value.Length; i++) {
			char letter = value [i];
			result = 10 * result + (letter - 48);
		}
		return result;
	}

}