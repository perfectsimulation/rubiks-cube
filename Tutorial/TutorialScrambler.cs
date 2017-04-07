using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class contains the methods used to obtain a random configuration of the Rubik's Cube.
/// It also contains methods to obtain known configurations during the tutorial. These known
/// configurations are used for illustrative purposes.
/// </summary>
public class TutorialScrambler : MonoBehaviour {

	#region Properties

	// The GameObject variable |solver| contains the script to solve the Rubik's Cube.
	// The bool variable |solving| is true when |solver| is actively performing a solution animation.
	public GameObject solver;
	private bool solving;

	// The following GameObject variables ending with "face" are used for their Bounds to make the correct rotation.
	// They represent the sides of the Rubik's Cube.
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

	// The following Vector3 variables beginning with "cubeCenter" are the positions of the center of
	// each piece.
	private Vector3 cubeCenter_00;
	private Vector3 cubeCenter_01;
	private Vector3 cubeCenter_02;
	private Vector3 cubeCenter_03;
	private Vector3 cubeCenter_04;
	private Vector3 cubeCenter_05;
	private Vector3 cubeCenter_06;
	private Vector3 cubeCenter_07;
	private Vector3 cubeCenter_08;
	private Vector3 cubeCenter_09;
	private Vector3 cubeCenter_10;
	private Vector3 cubeCenter_11;
	private Vector3 cubeCenter_12;
	private Vector3 cubeCenter_13;
	private Vector3 cubeCenter_14;
	private Vector3 cubeCenter_15;
	private Vector3 cubeCenter_16;
	private Vector3 cubeCenter_17;
	private Vector3 cubeCenter_18;
	private Vector3 cubeCenter_19;
	private Vector3 cubeCenter_20;
	private Vector3 cubeCenter_21;
	private Vector3 cubeCenter_22;
	private Vector3 cubeCenter_23;
	private Vector3 cubeCenter_24;
	private Vector3 cubeCenter_25;
	private Vector3 cubeCenter_26;

	// The List<GameObject> variable |allCubes| contains all pieces of the Rubik's Cube.
	// The List<GameObject> variable |faceCubes| is populated with the pieces on a given side.
	// The List<Vector3> variable |allCubesCenters| contains all the piece center positions.
	private List<GameObject> allCubes  = new List<GameObject> ();
	private List<GameObject> faceCubes = new List<GameObject> ();
	private List<Vector3> allCubesCenters = new List<Vector3> ();
	#endregion

	/// <summary>
	/// Start this instance by populating List properties.
	/// </summary>
	void Start () {

		f_bounds = f_face.GetComponent<MeshCollider> ().bounds;
		d_bounds = d_face.GetComponent<MeshCollider> ().bounds;
		r_bounds = r_face.GetComponent<MeshCollider> ().bounds;
		u_bounds = u_face.GetComponent<MeshCollider> ().bounds;
		l_bounds = l_face.GetComponent<MeshCollider> ().bounds;
		b_bounds = b_face.GetComponent<MeshCollider> ().bounds;

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
	/// Gets the centers of each piece.
	/// </summary>
	/// <returns>The centers of each piece.</returns>
	List<Vector3> GetCubesCenters () {
		allCubesCenters.Clear ();

		cubeCenter_00 = cube00.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_01 = cube01.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_02 = cube02.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_03 = cube03.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_04 = cube04.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_05 = cube05.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_06 = cube06.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_07 = cube07.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_08 = cube08.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_09 = cube09.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_10 = cube10.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_11 = cube11.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_12 = cube12.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_13 = cube13.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_14 = cube14.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_15 = cube15.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_16 = cube16.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_17 = cube17.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_18 = cube18.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_19 = cube19.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_20 = cube20.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_21 = cube21.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_22 = cube22.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_23 = cube23.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_24 = cube24.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_25 = cube25.GetComponent<BoxCollider> ().bounds.center;
		cubeCenter_26 = cube26.GetComponent<BoxCollider> ().bounds.center;

		allCubesCenters.Add (cubeCenter_00);
		allCubesCenters.Add (cubeCenter_01);
		allCubesCenters.Add (cubeCenter_02);
		allCubesCenters.Add (cubeCenter_03);
		allCubesCenters.Add (cubeCenter_04);
		allCubesCenters.Add (cubeCenter_05);
		allCubesCenters.Add (cubeCenter_06);
		allCubesCenters.Add (cubeCenter_07);
		allCubesCenters.Add (cubeCenter_08);
		allCubesCenters.Add (cubeCenter_09);
		allCubesCenters.Add (cubeCenter_10);
		allCubesCenters.Add (cubeCenter_11);
		allCubesCenters.Add (cubeCenter_12);
		allCubesCenters.Add (cubeCenter_13);
		allCubesCenters.Add (cubeCenter_14);
		allCubesCenters.Add (cubeCenter_15);
		allCubesCenters.Add (cubeCenter_16);
		allCubesCenters.Add (cubeCenter_17);
		allCubesCenters.Add (cubeCenter_18);
		allCubesCenters.Add (cubeCenter_19);
		allCubesCenters.Add (cubeCenter_20);
		allCubesCenters.Add (cubeCenter_21);
		allCubesCenters.Add (cubeCenter_22);
		allCubesCenters.Add (cubeCenter_23);
		allCubesCenters.Add (cubeCenter_24);
		allCubesCenters.Add (cubeCenter_25);
		allCubesCenters.Add (cubeCenter_26);

		return allCubesCenters;
	}

	/// <summary>
	/// Gets the pieces of s given side.
	/// </summary>
	/// <returns>The pieces of a given side.</returns>
	/// <param name="bound">The desired side.</param>
	List<GameObject> GetFaceCubes(Bounds bound) {
		faceCubes.Clear ();
		allCubesCenters = GetCubesCenters ();
		foreach (Vector3 center in allCubesCenters) {
			if (bound.Contains(center)) {
				int i = allCubesCenters.IndexOf(center);
				faceCubes.Add(allCubes[i]);
			}
		}
		return faceCubes;
	}

	/// <summary>
	/// Scramble the Rubik's Cube by performing twenty random rotations.
	/// </summary>
	public void Scramble () {
		for (int x = 0; x < 20; x++) {
			StartCoroutine(Turn ());
		}
	}

	/// <summary>
	/// Perform a rotation of the Rubik's Cube.
	/// </summary>
	IEnumerator Turn () {
		solving = solver.GetComponent<TutorialSolver> ().IsSolving ();
		while (solving) {
			yield return null;			// don't allow scramble if solve is active
		}
		int randTurn = Random.Range (0, 12);
		switch (randTurn) {
		case 0:
			yield return StartCoroutine (F__cw ());
			break;
		case 1:
			yield return StartCoroutine (F_ccw ());
			break;
		case 2:
			yield return StartCoroutine (R__cw ());
			break;
		case 3:
			yield return StartCoroutine (R_ccw ());
			break;
		case 4:
			yield return StartCoroutine (D__cw ());
			break;
		case 5:
			yield return StartCoroutine (D_ccw ());
			break;
		case 6:
			yield return StartCoroutine (U__cw ());
			break;
		case 7:
			yield return StartCoroutine (U_ccw ());
			break;
		case 8:
			yield return StartCoroutine (L__cw ());
			break;
		case 9:
			yield return StartCoroutine (L_ccw ());
			break;
		case 10:
			yield return StartCoroutine (B__cw ());
			break;
		case 11:
			yield return StartCoroutine (B_ccw ());
			break;
		}
	}

	#region Turn Mechanisms

	/// <summary>
	/// Rotates the White side clockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the White side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator F__cw () {
		List<GameObject> faceCubes = GetFaceCubes (f_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.up * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the White side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the White side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator F_ccw () {
		List<GameObject> faceCubes = GetFaceCubes (f_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.down * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Green side clockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Green side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator D__cw () {
		List<GameObject> faceCubes = GetFaceCubes (d_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.right * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Green side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Green side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator D_ccw () {
		List<GameObject> faceCubes = GetFaceCubes (d_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.left * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Red side clockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Red side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator R__cw () {
		List<GameObject> faceCubes = GetFaceCubes (r_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.forward * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Red side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Red side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator R_ccw () {
		List<GameObject> faceCubes = GetFaceCubes (r_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.back * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Blue side clockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Blue side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator U__cw () {
		List<GameObject> faceCubes = GetFaceCubes (u_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.left * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Blue side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Blue side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator U_ccw () {
		List<GameObject> faceCubes = GetFaceCubes (u_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.right * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Purple side clockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Purple side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator L__cw () {
		List<GameObject> faceCubes = GetFaceCubes (l_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.back * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Purple side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Purple side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator L_ccw () {
		List<GameObject> faceCubes = GetFaceCubes (l_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.forward * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Yellow side clockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Yellow side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator B__cw () {
		List<GameObject> faceCubes = GetFaceCubes (b_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.up * 90f, Space.World);
		}
		yield return null;
	}

	/// <summary>
	/// Rotates the Yellow side counterclockwise.
	/// </summary>
	/// <remarks>
	/// This is different from turn mechanisms of other scripts. Here, this will always rotate the Yellow side.
	/// Other scripts with similar methods configure which side to turn based on the camera view.
	/// </remarks>
	IEnumerator B_ccw () {
		List<GameObject> faceCubes = GetFaceCubes (b_bounds);
		foreach (GameObject cube in faceCubes) {
			cube.transform.Rotate (Vector3.down * 90f, Space.World);
		}
		yield return null;
	}
	#endregion

	#region White Cross Configurations

	// All of the Tutor_WhiteCross methods are used in Phase 1 of the tutorial.
	// They apply rotations to the Rubik's Cube to achieve particular configurations used as
	// examples during the tutorial.

	public void Tutor_WhiteCross1 () {
		StartCoroutine (U_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
	}
		
	public void Tutor_WhiteCross2 () {
		Tutor_WhiteCross1 ();
		StartCoroutine (U_ccw ());
	}

	public void Tutor_WhiteCross3 () {
		Tutor_WhiteCross2 ();
		StartCoroutine (B_ccw ());
	}

	public void Tutor_WhiteCross4 () {
		Tutor_WhiteCross3 ();
		StartCoroutine (L__cw ());
		StartCoroutine (L__cw ());
	}

	public void Tutor_WhiteCross5 () {
		Tutor_WhiteCross4 ();
		StartCoroutine (L_ccw ());
		StartCoroutine (F__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (F_ccw ());
	}

	public void Tutor_WhiteCross6 () {
		Tutor_WhiteCross5 ();
		StartCoroutine (D_ccw ());
	}

	public void Tutor_WhiteCross7 () {
		Tutor_WhiteCross6 ();
		StartCoroutine (D__cw ());
		StartCoroutine (D__cw ());
	}

	public void Tutor_WhiteCross8 () {
		Tutor_WhiteCross7 ();
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
	}

	public void Tutor_WhiteCross9 () {
		Tutor_WhiteCross8 ();
		StartCoroutine (B__cw ());
	}

	public void Tutor_WhiteCross10 () {
		Tutor_WhiteCross9 ();
		StartCoroutine (R__cw ());
		StartCoroutine (R__cw ());
	}

	public void Tutor_WhiteCross11 () {
		Tutor_WhiteCross10 ();
		StartCoroutine (R_ccw ());
		StartCoroutine (F__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (F_ccw ());
	}

	public void Tutor_WhiteCross12 () {
		Tutor_WhiteCross11 ();
		StartCoroutine (R_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
	}

	public void Tutor_WhiteCross13 () {
		Tutor_WhiteCross12 ();
		StartCoroutine (B__cw ());
	}

	public void Tutor_WhiteCross14 () {
		Tutor_WhiteCross13 ();
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
	}

	#endregion

	#region White Corners Configurations

	// All of the Tutor_WhiteCorners methods are used in Phase 2 of the tutorial.
	// They apply rotations to the Rubik's Cube to achieve particular configurations used as
	// examples during the tutorial.

	public void Tutor_WhiteCorners1 () {
		Tutor_WhiteCross5 ();

		StartCoroutine (D__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (F__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (F_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L__cw ());
	}

	public void Tutor_WhiteCorners2 () {
		Tutor_WhiteCorners1 ();
		StartCoroutine (B__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());

	}

	public void Tutor_WhiteCorners3 () {
		Tutor_WhiteCorners2 ();
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
	}

	public void Tutor_WhiteCorners4 () {
		Tutor_WhiteCorners3 ();
		StartCoroutine (B__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L__cw ());
	}

	public void Tutor_WhiteCorners5 () {
		Tutor_WhiteCorners4 ();
		StartCoroutine (B__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L__cw ());
	}

	public void Tutor_WhiteCorners6 () {
		Tutor_WhiteCorners5 ();
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R__cw ());
	}

	public void Tutor_WhiteCorners7 () {
		Tutor_WhiteCorners6 ();
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
	}

	public void Tutor_WhiteCorners8 () {
		Tutor_WhiteCorners7 ();
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U__cw ());
	}

	public void Tutor_WhiteCorners9 () {
		Tutor_WhiteCross5 ();

		StartCoroutine (D__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (F__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (F_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());

	}

	public void Tutor_WhiteCorners10 () {
		Tutor_WhiteCross5 ();
		StartCoroutine (D__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (F__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (F_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D__cw ());

		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());

		StartCoroutine (U_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U__cw ());
	}

	#endregion

	#region Middle Layer Configurations

	// All of the Tutor_MiddleLayer methods are used in Phase 3 of the tutorial.
	// They apply rotations to the Rubik's Cube to achieve particular configurations used as
	// examples during the tutorial.

	public void Tutor_MiddleLayer1 () {
		Tutor_WhiteCorners10 ();
		StartCoroutine (B_ccw ());
	}

	public void Tutor_MiddleLayer2 () {
		Tutor_MiddleLayer1 ();
		StartCoroutine (B_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L__cw ());
	}

	public void Tutor_MiddleLayer3 () {
		Tutor_MiddleLayer2 ();
		StartCoroutine (B_ccw ());
	}

	public void Tutor_MiddleLayer4 () {
		Tutor_MiddleLayer3 ();
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U__cw ());
	}

	public void Tutor_MiddleLayer5 () {
		Tutor_MiddleLayer4 ();
		StartCoroutine (B__cw ());
	}

	public void Tutor_MiddleLayer6 () {
		Tutor_MiddleLayer5 ();
		StartCoroutine (B_ccw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());
	}

	public void Tutor_MiddleLayer7 () {
		Tutor_MiddleLayer6 ();
		StartCoroutine (B__cw ());
		StartCoroutine (B__cw ());
	}

	public void Tutor_MiddleLayer8 () {
		Tutor_MiddleLayer7 ();
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D_ccw ());
	}

	public void Tutor_MiddleLayer9 () {
		Tutor_WhiteCorners10 ();
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
	}

	public void Tutor_MiddleLayer10 () {
		Tutor_MiddleLayer9 ();
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U__cw ());
	}

	#endregion

	#region Yellow Cross Configurations

	// All of the Tutor_YellowCross methods are used in Phase 4 of the tutorial.
	// They apply rotations to the Rubik's Cube to achieve particular configurations used as
	// examples during the tutorial.

	public void Tutor_YellowCross1 () {
		Tutor_MiddleLayer8 ();
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (U_ccw ());
	}

	public void Tutor_YellowCross2 () {
		Tutor_YellowCross1 ();
		StartCoroutine (L__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L_ccw ());
	}

	public void Tutor_YellowCross3 () {
		Tutor_MiddleLayer8 ();
		StartCoroutine (U__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());
	}

	public void Tutor_YellowCross4 () {
		Tutor_YellowCross3 ();
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
	}

	public void Tutor_YellowCross5 () {
		Tutor_YellowCross4 ();
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (U_ccw ());
	}

	#endregion

	#region Yellow Corners Configurations

	// All of the Tutor_YellowCorners methods are used in Phase 5 of the tutorial.
	// They apply rotations to the Rubik's Cube to achieve particular configurations used as
	// examples during the tutorial.

	public void Tutor_YellowCorners1 () {
		Tutor_MiddleLayer8 ();
		StartCoroutine (R__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (U_ccw ());
	}

	public void Tutor_YellowCorners2 () {
		Tutor_YellowCorners1 ();
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
	}

	public void Tutor_YellowCorners3 () {
		Tutor_YellowCorners2 ();
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L_ccw ());
	}

	public void Tutor_YellowCorners4 () {
		Tutor_YellowCorners2 ();
		StartCoroutine (U__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());

		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (L_ccw ());

		StartCoroutine (U__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());

		StartCoroutine (U__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());

		StartCoroutine (D__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D_ccw ());

		StartCoroutine (U__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());

		StartCoroutine (U__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());

		StartCoroutine (U__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (U_ccw ());

		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (D_ccw ());

	}

	public void Tutor_YellowCorners5 () {
		Tutor_YellowCorners4 ();
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L_ccw ());
	}

	public void Tutor_YellowCorners6 () {
		Tutor_YellowCorners5 ();
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
	}

	public void Tutor_YellowCorners7 () {
		Tutor_YellowCorners6 ();
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
	}
		
	public void Tutor_YellowCorners8 () {
		Tutor_YellowCorners2 ();
		StartCoroutine (L__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (L_ccw ());

		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (R_ccw ());

		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (R_ccw ());

		StartCoroutine (D__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (B__cw ());
		StartCoroutine (D_ccw ());
	}

	public void Tutor_YellowCorners9 () {
		Tutor_YellowCorners8 ();
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
	}

	public void Tutor_YellowCorners10 () {
		Tutor_YellowCorners9 ();
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (D_ccw ());
	}

	public void Tutor_YellowCorners11 () {
		Tutor_YellowCorners10 ();
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U_ccw ());
	}
	#endregion

	#region Top Layer Configurations

	public void Tutor_TopLayer1 () {
		Tutor_YellowCorners11 ();
		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
	}

	public void Tutor_TopLayer2 () {
		Tutor_YellowCorners11 ();
		StartCoroutine (R_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R__cw ());
	}

	public void Tutor_TopLayer3 () {
		Tutor_TopLayer2 ();
		StartCoroutine (R_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B__cw ());
	} 

	public void Tutor_TopLayer4 () {
		Tutor_TopLayer3 ();
		StartCoroutine (B__cw ());
	}
		
	public void Tutor_TopLayer5 () {
		Tutor_TopLayer2 ();
		StartCoroutine (D_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (L__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (L__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());

		StartCoroutine (B__cw ());

		StartCoroutine (L_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (L__cw ());
		StartCoroutine (B_ccw ());

		StartCoroutine (B_ccw ());
		StartCoroutine (B_ccw ());
	} 

	public void Tutor_TopLayer6 () {
		Tutor_TopLayer5 ();
		StartCoroutine (R__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (D_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R__cw ());
		StartCoroutine (U_ccw ());
		StartCoroutine (D__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (R__cw ());
	}

	public void Tutor_TopLayer7 () {
		Tutor_TopLayer6 ();
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (L__cw ());
		StartCoroutine (R_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
		StartCoroutine (L_ccw ());
		StartCoroutine (R__cw ());
		StartCoroutine (B_ccw ());
		StartCoroutine (U__cw ());
		StartCoroutine (U__cw ());
	}
	#endregion
}
