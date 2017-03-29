using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	#region Properties
	public GameObject solver;
	public Text tutor;
	public Camera cam;
	public GameObject keyboard;
	public Material plastic;
	public Material glow;
	public Material any;

	private Animator keyboardAnimator;
	public Sprite key_none;
	public Sprite key_f;
	public Sprite key_fi;
	public Sprite key_d;
	public Sprite key_di;
	public Sprite key_r;
	public Sprite key_ri;
	public Sprite key_u;
	public Sprite key_ui;
	public Sprite key_l;
	public Sprite key_li;
	public Sprite key_b;
	public Sprite key_bi;

	public GameObject summaryDone;
	public GameObject summary1;
	public GameObject summary2;
	public GameObject summary3;
	public GameObject summary4;

	public Text summaryDoneText;
	public Text summary1Text;
	public Text summary2Text;
	public Text summary3Text;
	public Text summary4Text;

	public GameObject config1of3;
	public GameObject config2of3;
	public GameObject config3of3;

	public Sprite state1_1a;
	public Sprite state1_1b;
	public Sprite state1done;
	public Sprite state2_1a;
	public Sprite state2_1b;
	public Sprite state2_1c;
	public Sprite state2_2;
	public Sprite state2done;
	public Sprite state3_1a;
	public Sprite state3_2a;
	public Sprite state3done;
	public Sprite state4_1a;
	public Sprite state4_2a;
	public Sprite state4_3a;
	public Sprite state4done;
	public Sprite state5_1a;
	public Sprite state5_2a;
	public Sprite state5_3a;
	public Sprite state5done;
	public Sprite state6_1a;
	public Sprite state6_2a;
	public Sprite state6_3a;
	public Sprite state6_3b;
	public Sprite state6done;

	public GameObject f_face;
	public GameObject d_face;
	public GameObject r_face;
	public GameObject u_face;
	public GameObject l_face;
	public GameObject b_face;

	private Bounds f_bounds;
	private Bounds d_bounds;
	private Bounds r_bounds;
	private Bounds u_bounds;
	private Bounds l_bounds;
	private Bounds b_bounds;

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

	private Material[] original00;
	private Material[] original01;
	private Material[] original02;
	private Material[] original03;
	private Material[] original04;
	private Material[] original05;
	private Material[] original06;
	private Material[] original07;
	private Material[] original08;
	private Material[] original09;
	private Material[] original10;
	private Material[] original11;
	private Material[] original12;
	private Material[] original13;
	private Material[] original14;
	private Material[] original15;
	private Material[] original16;
	private Material[] original17;
	private Material[] original18;
	private Material[] original19;
	private Material[] original20;
	private Material[] original21;
	private Material[] original22;
	private Material[] original23;
	private Material[] original24;
	private Material[] original25;
	private Material[] original26;

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

	private int tutorialStep = 0;
	private bool stepDone = false;

	private Quaternion whiteSideUp;
	private bool upSwap;
	private bool doUpSwap = false;
	private int sunnySideUp = 1;
	private int faceConfig = 0;

	private List<GameObject> allFaces = new List<GameObject> ();
	private List<GameObject> sortedFacesBlue = new List<GameObject> ();
	private List<GameObject> sortedFacesOrange = new List<GameObject> ();
	private List<GameObject> sortedFacesGreen = new List<GameObject> ();
	private List<GameObject> sortedFacesRed = new List<GameObject> ();

	private static List<Vector3> refFacePositions = new List<Vector3> ();
	private List<Bounds> allFacesBounds = new List<Bounds> ();
	private List<Bounds> sortedBounds = new List<Bounds> ();

	private List<GameObject> allCubes = new List<GameObject> ();
	private List<GameObject> edgeCubes = new List<GameObject> ();
	private List<GameObject> cornerCubes = new List<GameObject> ();
	private List<GameObject> centerCubes = new List<GameObject> ();

	private List<GameObject> whiteCross = new List<GameObject> ();
	private List<GameObject> whiteCorners = new List<GameObject> ();
	private List<GameObject> middleLayer = new List<GameObject> ();
	private List<GameObject> yellowCross = new List<GameObject> ();
	private List<GameObject> yellowCorners = new List<GameObject> ();
	private List<GameObject> topLayer = new List<GameObject> ();

	#endregion

	void Start () {

		allFaces.Add (f_face);
		allFaces.Add (d_face);
		allFaces.Add (r_face);
		allFaces.Add (u_face);
		allFaces.Add (l_face);
		allFaces.Add (b_face);

		foreach (GameObject face in allFaces) {
			Vector3 pos = face.transform.position;
			refFacePositions.Add (pos);
		}
			
		keyboard.SetActive (false);

		sortedFacesBlue.Add (u_face);
		sortedFacesBlue.Add (b_face);
		sortedFacesBlue.Add (l_face);
		sortedFacesBlue.Add (f_face);
		sortedFacesBlue.Add (r_face);
		sortedFacesBlue.Add (d_face);

		sortedFacesOrange.Add (l_face);
		sortedFacesOrange.Add (b_face);
		sortedFacesOrange.Add (d_face);
		sortedFacesOrange.Add (f_face);
		sortedFacesOrange.Add (u_face);
		sortedFacesOrange.Add (r_face);

		sortedFacesGreen.Add (d_face);
		sortedFacesGreen.Add (b_face);
		sortedFacesGreen.Add (r_face);
		sortedFacesGreen.Add (f_face);
		sortedFacesGreen.Add (l_face);
		sortedFacesGreen.Add (u_face);

		sortedFacesRed.Add (r_face);
		sortedFacesRed.Add (b_face);
		sortedFacesRed.Add (u_face);
		sortedFacesRed.Add (f_face);
		sortedFacesRed.Add (d_face);
		sortedFacesRed.Add (l_face);

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

		sortedBounds = allFacesBounds;
		SortBounds ();

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

		whiteSideUp = cube00.transform.rotation;

		original00 = cube00.GetComponent<Renderer> ().materials;
		original01 = cube01.GetComponent<Renderer> ().materials;
		original02 = cube02.GetComponent<Renderer> ().materials;
		original03 = cube03.GetComponent<Renderer> ().materials;
		original04 = cube04.GetComponent<Renderer> ().materials;
		original05 = cube05.GetComponent<Renderer> ().materials;
		original06 = cube06.GetComponent<Renderer> ().materials;
		original07 = cube07.GetComponent<Renderer> ().materials;
		original08 = cube08.GetComponent<Renderer> ().materials;
		original09 = cube09.GetComponent<Renderer> ().materials;
		original10 = cube10.GetComponent<Renderer> ().materials;
		original11 = cube11.GetComponent<Renderer> ().materials;
		original12 = cube12.GetComponent<Renderer> ().materials;
		original13 = cube13.GetComponent<Renderer> ().materials;
		original14 = cube14.GetComponent<Renderer> ().materials;
		original15 = cube15.GetComponent<Renderer> ().materials;
		original16 = cube16.GetComponent<Renderer> ().materials;
		original17 = cube17.GetComponent<Renderer> ().materials;
		original18 = cube18.GetComponent<Renderer> ().materials;
		original19 = cube19.GetComponent<Renderer> ().materials;
		original20 = cube20.GetComponent<Renderer> ().materials;
		original21 = cube21.GetComponent<Renderer> ().materials;
		original22 = cube22.GetComponent<Renderer> ().materials;
		original23 = cube23.GetComponent<Renderer> ().materials;
		original24 = cube24.GetComponent<Renderer> ().materials;
		original25 = cube25.GetComponent<Renderer> ().materials;
		original26 = cube26.GetComponent<Renderer> ().materials;

		edgeCubes.Add (cube02);
		edgeCubes.Add (cube04);
		edgeCubes.Add (cube06);
		edgeCubes.Add (cube08);
		edgeCubes.Add (cube10);
		edgeCubes.Add (cube12);
		edgeCubes.Add (cube16);
		edgeCubes.Add (cube18);
		edgeCubes.Add (cube20);
		edgeCubes.Add (cube22);
		edgeCubes.Add (cube24);
		edgeCubes.Add (cube26);

		cornerCubes.Add (cube00);
		cornerCubes.Add (cube01);
		cornerCubes.Add (cube03);
		cornerCubes.Add (cube07);
		cornerCubes.Add (cube09);
		cornerCubes.Add (cube19);
		cornerCubes.Add (cube21);
		cornerCubes.Add (cube25);

		centerCubes.Add (cube05);
		centerCubes.Add (cube11);
		centerCubes.Add (cube13);
		centerCubes.Add (cube15);
		centerCubes.Add (cube17);
		centerCubes.Add (cube23);

		whiteCross.Add (cube20);
		whiteCross.Add (cube24);
		whiteCross.Add (cube26);
		whiteCross.Add (cube22);

		whiteCorners.Add (cube21);
		whiteCorners.Add (cube00);
		whiteCorners.Add (cube25);
		whiteCorners.Add (cube19);

		middleLayer.Add (cube12);
		middleLayer.Add (cube18);
		middleLayer.Add (cube16);
		middleLayer.Add (cube10);

		yellowCross.Add (cube04);
		yellowCross.Add (cube08);
		yellowCross.Add (cube02);
		yellowCross.Add (cube06);

		yellowCorners.Add (cube07);
		yellowCorners.Add (cube01);
		yellowCorners.Add (cube09);
		yellowCorners.Add (cube03);

		topLayer.Add (cube04);
		topLayer.Add (cube08);
		topLayer.Add (cube02);
		topLayer.Add (cube06);
		topLayer.Add (cube07);
		topLayer.Add (cube01);
		topLayer.Add (cube09);
		topLayer.Add (cube03);
	}

	public void Previous () {
		if (!solver.GetComponent<TutorialSolver> ().IsSolving ()) {
			if (tutorialStep > 0) {
				tutorialStep -= 1;
			}
			stepDone = false;
		}
	}

	public void Next () {
		if (!solver.GetComponent<TutorialSolver> ().IsSolving ()) {
			tutorialStep += 1;
			stepDone = false;
		}
	}

	void Update () {
		doUpSwap = Input.GetButtonDown ("Jump");
		if (doUpSwap) {
			StartCoroutine (SwapTopView ());
		}
//		float y = cam.transform.rotation.eulerAngles.y;
//		y = (y > 180) ? y - 360 : y;
//		StartCoroutine (FaceSwap (y));
		faceConfig = cam.GetComponent<TutorialCamera> ().GetFaceConfig ();
		StartCoroutine (FaceSwap ());
		ConfigureMoves ();
		Summary ();
		StartCoroutine (Steps ());
	}

	IEnumerator FaceSwap () {
		while (solver.GetComponent<TutorialSolver> ().IsTurning ()) {
			yield return null;
		}
		//UserFace (y);
		yield return null;
	}

	void UserFace (float y) {
		if ((y >= 45f) && (y < 135f)) {
			faceConfig = (sunnySideUp > 0) ? 0 : 1;
			if (!allFaces.Equals (sortedFacesBlue)) {
				allFaces = sortedFacesBlue;
				SortBounds ();
			}
		} else if ((y >= -135f) && (y < -45f)) {
			faceConfig = (sunnySideUp > 0) ? 4 : 5;
			if (!allFaces.Equals (sortedFacesGreen)) {
				allFaces = sortedFacesGreen;
				SortBounds ();
			}
		} else if ((y >= -45f) && (y < 45f)) {
			if (sunnySideUp > 0) {
				faceConfig = 2;
				if (!allFaces.Equals (sortedFacesOrange)) {
					allFaces = sortedFacesOrange;
					SortBounds ();
				}
			} else if (sunnySideUp < 0) {
				faceConfig = 3;
				if (!allFaces.Equals (sortedFacesRed)) {
					allFaces = sortedFacesRed;
					SortBounds ();
				}
			}
		} else {
			if (sunnySideUp > 0) {
				faceConfig = 6;
				if (!allFaces.Equals (sortedFacesRed)) {
					allFaces = sortedFacesRed;
					SortBounds ();
				}
			} else if (sunnySideUp < 0) {
				faceConfig = 7;
				if (!allFaces.Equals (sortedFacesOrange)) {
					allFaces = sortedFacesOrange;
					SortBounds ();
				}
			}
		}
	}

	void SortBounds () {

		sortedBounds.Clear ();
		foreach (GameObject face in allFaces) {
			Bounds faceBound = face.GetComponent<MeshCollider> ().bounds;
			sortedBounds.Add (faceBound);
		}
	}

	void ConfigureMoves () {
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
			d  = 0;
			di = 1;
			r  = 4;
			ri = 5;
			u  = 11;
			ui = 10;
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
			d  = 0;
			di = 1;
			r  = 2;
			ri = 3;
			u  = 11;
			ui = 10;
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
			d  = 0;
			di = 1;
			r  = 8;
			ri = 9;
			u  = 11;
			ui = 10;
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
			d  = 0;
			di = 1;
			r  = 6;
			ri = 7;
			u  = 11;
			ui = 10;
			l  = 2;
			li = 3;
			b  = 4;
			bi = 5;
			break;
		}
	}

	void Summary () {
		switch (tutorialStep) {
		case 54:
			foreach (GameObject cube in allCubes) {
				cube.SetActive (false);
			}
			summaryDone.SetActive (true);
			summaryDoneText.gameObject.SetActive (true);

			summary1.SetActive (true);
			summary1Text.gameObject.SetActive (true);

			summaryDone.GetComponent<SpriteRenderer> ().sprite = state1done;

			summary1.GetComponent<SpriteRenderer> ().sprite = state1_1b;
			summary1Text.text = "[R' U F' U']";
			break;
		case 93:
			foreach (GameObject cube in allCubes) {
				cube.SetActive (false);
			}
			summaryDone.SetActive (true);
			summaryDoneText.gameObject.SetActive (true);

			summary1.SetActive (true);
			summary1Text.gameObject.SetActive (true);

			summary2.SetActive (true);
			summary2Text.gameObject.SetActive (true);

			summary3.SetActive (true);
			summary3Text.gameObject.SetActive (true);

			summary4.SetActive (true);
			summary4Text.gameObject.SetActive (true);

			summaryDone.GetComponent<SpriteRenderer> ().sprite = state2done;

			summary1.GetComponent<SpriteRenderer> ().sprite = state2_1a;
			summary1Text.text = "[R' D' R D]";

			summary2.GetComponent<SpriteRenderer> ().sprite = state2_1b;
			summary2Text.text = "[R' D' R D]";

			summary3.GetComponent<SpriteRenderer> ().sprite = state2_1c;
			summary3Text.text = "[R' D' R D]";

			summary4.GetComponent<SpriteRenderer> ().sprite = state2_2;
			summary4Text.text = "[R' D' R]";

			break;
		case 126:
			foreach (GameObject cube in allCubes) {
				cube.SetActive (false);
			}
			summaryDone.SetActive (true);
			summaryDoneText.gameObject.SetActive (true);

			summary1.SetActive (true);
			summary1Text.gameObject.SetActive (true);

			summary2.SetActive (true);
			summary2Text.gameObject.SetActive (true);

			summaryDone.GetComponent<SpriteRenderer> ().sprite = state3done;

			summary1.GetComponent<SpriteRenderer> ().sprite = state3_1a;
			summary1Text.text = "[U R U' R' U' F' U F]";

			summary2.GetComponent<SpriteRenderer> ().sprite = state3_2a;
			summary2Text.text = "[U' L' U L U F U' F']";
			break;
		default:
			if (!cube00.gameObject.activeInHierarchy) {
				foreach (GameObject cube in allCubes) {
					cube.SetActive (true);
				}
			}
			summaryDone.SetActive (false);
			summaryDoneText.gameObject.SetActive (false);

			summary1.SetActive (false);
			summary1Text.gameObject.SetActive (false);

			summary2.SetActive (false);
			summary2Text.gameObject.SetActive (false);

			summary3.SetActive (false);
			summary3Text.gameObject.SetActive (false);

			summary4.SetActive (false);
			summary4Text.gameObject.SetActive (false);
			break;
		}
	}

	string GetInstruction () {
		switch (tutorialStep) {
		case 0:
			return "Part I: Anatomy of the Rubik's Cube";
		case 1:
			return "Use the arrow keys to change your view of the Rubik's Cube.";
		case 2:
			return "Press the spacebar to flip the Rubik's Cube upside down.";
		case 3:
			return "There are six sides of the Rubik's Cube, which we will assign the names F (Front), B (Back), U (Up), D (Down), R (Right), and L (Left). Each side has a Center piece, which defines the color of that side.";
		case 4:
			return "These are twelve Edge pieces. Edges have two colors.";
		case 5:
			return "These are eight Corner pieces. Corners have three colors.";
		case 6:
			return "Now let's assign the names of each side according to our view of the Rubik's Cube and name each possible move we can make.";
		case 7:
			return "The side directly facing you is assigned the name F. The rest of the sides are assigned names relative to F. Here the Blue side is F, the Green side is B, the White side is U, the Yellow side is D, the Purple side is R, and the Red side is L.";
		case 8:
			return "[F] Front Clockwise";
		case 9:
			return "[F'] Front Counterclockwise";
		case 10:
			return "[B] Back Clockwise";
		case 11:
			return "[B'] Back Counterclockwise";
		case 12:
			return "[U] Up Clockwise";
		case 13:
			return "[U'] Up Counterclockwise";
		case 14:
			return "[D] Down Clockwise";
		case 15:
			return "[D'] Down Counterclockwise";
		case 16:
			return "[R] Right Clockwise";
		case 17:
			return "[R'] Right Counterclockwise";
		case 18:
			return "[L] Left Clockwise";
		case 19:
			return "[L'] Left Counterclockwise";
		case 20:
			return "It's important to stick to one orientation while completing a sequence of turns. After finishing a sequence, take care to mentally reassign names whenever you change your view of the Rubik's Cube.";
		case 21:
			return "Part II: Solving the Rubik's Cube";
		case 22:
			return "An algorithm is given by a series of turns enclosed in brackets.";
		case 23:
			return "For example, this is the algorithm [U U U U]. Any turn done four times in a row will bring you back to the initial configuration.";
		case 24:
			return "The key to learning how to solve a Rubik's Cube is identifying which algorithms to use.";
		case 25:
			return "Now we'll go over which algorithms to use according to the Rubik's Cube's configurations.";
		case 26:
			return "There are six phases to solve a Rubik's Cube.";
		case 27:
			return "Phase 1: White Cross";
		case 28:
			return "There are four Edge pieces that make up the White Cross. We will move each Edge to its correct place one at a time.";
		case 29:
			return "Take note that each of these Edge pieces matches their adjacent Center pieces. Before moving on to the next phase, make sure all the Edges match.";
		case 31:
			return "The first thing we need to do is assign names to the sides. Let's choose the Blue side as F and the White side as U.";
		case 30:
			return "We can choose any Edge to start. Let's go with the Purple-White Edge.";
		case 32:
			return "Now, find the Purple-White Edge and move it so that it is on the D side.";
		case 33:
			return "Next, rotate the D side until the Purple-White Edge is directly under the Purple Center piece.";
		case 34:
			return "Double check to make sure the side name assignment we have still matches our view of the Rubik's Cube. The Purple side is still the R side.";
		case 35:
			return "Perform the algorithm [R R] to get the Purple-White Edge on the U side.";
		case 36:
			return "Your Rubik's Cube should now have either of these configurations. The top configuration has the correct Purple-White Edge position."; 
		case 37:
			return "If we have the bottom configuration, perform the algorithm [R' U F' U'] to obtain the top configuration.";
		case 38:
			return "Now the Purple-White Edge is in its proper place. We must pick the next White Cross Edge with the color that matches the Center piece of the side that is counterclockwise to the Purple side.";
		case 39:
			return "In this case, that will be the Green-White Edge. After that will be Red-White, then Blue-White. We solve the White Cross Edges in a counterclockwise order to avoid accidentally unsolving a previous White Cross Edge.";
		case 40:
			return "Let's find the Green-White Edge and move it to the D side.";
		case 41:
			return "With the Purple side as F, perform the algorithm [R R]. Now the Green-White Edge is in its proper place.";
		case 42:
			return "Next let's find the Red-White Edge.";
		case 43:
			return "Move it down to the D side.";
		case 44:
			return "Rotate the D side until the Red-White Edge is directly under the Red Center piece.";
		case 45:
			return "With the Green side as F, perform the algorithm [R R]. Now we have this configuration again.";
		case 46:
			return "Perform the algorithm [R' U F' U']. Now the Red-White Edge is in its proper place.";
		case 47:
			return "Lastly, let's find the Blue-White Edge.";
		case 48:
			return "It's in the middle row. When we bring it down to the D side, we need to be careful with the White Cross Edges we have already solved.";
		case 49:
			return "Let's assign the Green side as F. We have this configuration.";
		case 50:
			return "Perform the algorithm [R' D D R].";
		case 51:
			return "Now the Blue-White Edge is on the D side, and the other White Cross Edges are still solved.";
		case 52:
			return "Rotate the D side until the Blue-White Edge is directly under the Blue Center piece.";
		case 53:
			return "With the Red side as F, perform the algorithm [R R]. Now the Blue-White Edge is in its proper place. The White Cross is now complete.";
		case 54:
			return "Summary of Phase 1:";
		
		
		case 55:
			return "Phase 2: White Corners";
		case 56:
			return "There are four Corner pieces that make up the White Corners. We will solve each Corner one at a time.";
		case 57:
			return "Take note that each of these Corner pieces matches the colors of all three of its sides.";
		case 58:
			return "We can choose any White Corner to start, but there's a smart way to decide which one is best to save us from doing extra work.";
		case 59:
			return "With the White side as U, look on the bottom row of pieces. Are there any White Corner pieces with their White faces NOT on the Yellow side?";
		case 60:
			return "Yes, one. The Purple-Green-White Corner is on the bottom row, with its White face on the Purple side.";
		case 61:
			return "Look at the other face that is NOT on the Yellow side. It's Green.";
		case 62:
			return "We need to move the Purple-Green-White Corner so that the Green face is on the Green side. Do this by rotating the D side.";
		case 63:
			return "Now the Rubik's Cube matches this configuration.";
		case 64:
			return "Let's assign the Purple side as F. The White side is U.";
		case 65:
			return "Perform the algorithm [D' R' D R].";
		case 66:
			return "Now the Purple-Green-White Corner is in its proper place.";
		case 67:
			return "Look on the bottom row of pieces again. Are there any more White Corner pieces with their White faces NOT on the Yellow side?";
		case 68:
			return "This time, there aren't any. However there are two White Corners on the bottom row with White faces on the Yellow side: the Green-Red-White and Blue-Purple-White Corners.";
		case 69:
			return "We can choose either of these. Let's go with Blue-Purple-White.";
		case 70:
			return "Move the Blue-Purple-White Corner until it is directly below its correct spot.";
		case 71:
			return "Now we have this configuration.";
		case 72:
			return "With the Blue side as F, perform the algorithm [D' R' D D R].";
		case 73:
			return "Now the Blue-Purple-White Corner is on the bottom row, with its White face NOT on the Yellow side. Its Purple face is also NOT on the Yellow side.";
		case 74:
			return "We need to move the Blue-Purple-White Corner by rotating the D side until its Purple face is on the Purple side. In this case, it's already on the Purple side.";
		case 75:
			return "Let's assign the Blue side as F, keeping the White side as U.";
		case 76:
			return "Perform the algorithm [D' R' D R]";
		case 77:
			return "Now the Blue-Purple-White Corner is in its proper place.";
		case 78:
			return "Once more, let's look at the bottom row for any White Corner with its White face NOT on the Yellow side.";
		case 79:
			return "There is one: the Green-Red-White Corner.";
		case 80:
			return "The other face that is not on the Yellow side is its Green face.";
		case 81:
			return "If necessary, rotate the D side so that the Green face is on the Green side. We got lucky again, because it's already there.";
		case 82:
			return "Now we have this configuration.";
		case 83:
			return "Let's assign the Green side as F, keeping the White side as U.";
		case 84:
			return "Perform the algorithm [R' D' R].";
		case 85:
			return "Now the Green-Red-White Corner is in its proper place.";
		case 86:
			return "Let's look on the bottom row for the last White Corner: the Red-Blue-White Corner.";
		case 87:
			return "Its White and Blue faces are NOT on the Yellow side.";
		case 88:
			return "Move the Red-Blue-White Corner by rotating D so that its Blue face is on the Blue side.";
		case 89:
			return "With the Red side as F, perform the algorithm [D' R' D R]";
		case 90:
			return "Now all of our White Corners are in the correct places.";
		case 91:
			return "Sometimes when initially looking for a White Corner to solve, we may find it on the top row rather than the bottom row, with its White face on the wrong side.";
		case 92:
			return "To get it down to the D side, perform the algorithm [R' D' R].";
		case 93:
			return "Summary of Phase 2:";
		
		case 94:
			return "Phase 3: Middle Layer";
		case 95:
			return "There are four Edge pieces that make up the Middle Layer. We will solve each Edge one at a time.";
		case 96:
			return "Take note that each of these Edge pieces matches the colors of both of its adjacent Center pieces.";
		case 97:
			return "We can choose any Edge to start, but there's a smart way to decide which one is best to save us from doing extra work.";
		case 98:
			return "For this phase, let's assign the Yellow side as U.";
		case 99:
			return "Look on the U side. Check out the Edge pieces. Are any of them one of the Middle Layer Edges?";
		case 100:
			return "Here, there are two Middle Layer Edges already on the U side: the Blue-Purple Edge and the Purple-Green Edge.";
		case 101:
			return "Pick any of the Middle Layer Edges already on the U side. Let's go with the Blue-Purple Edge.";
		case 102:
			return "First we need to get Blue-Purple Edge ready. Notice that the Blue color of this piece is on the U side. The Purple color is on the Blue side.";
		case 103:
			return "We need to move the Blue-Purple Edge so that the color of the piece that is NOT on the U side (in this case Purple) aligns with its matching Center piece.";
		case 104:
			return "Notice now there is a vertical stack of three pieces with one matching color (Purple here). This is the condition we must meet before applying our algorithm.";
		case 105:
			return "Reorient the Rubik's Cube so that the Purple side is now F. The Blue side is R and the Green side is L.";
		case 106:
			return "Since the Blue side is R, we need to apply the following algorithm to bring the Blue-Purple Edge to the RIGHT: [U, R, U', R', U', F', U, F]";
		case 107:
			return "Now the Blue-Purple Edge is in the right place. Let's look again on the U side for any other Middle Layer Edges.";
		case 108:
			return "We have two options: the Purple-Green Edge and the Red-Blue Edge.";
		case 109:
			return "Let's go with the Red-Blue Edge.";
		case 110:
			return "Again we align the Red-Blue Edge to make the vertical stack of three matching pieces (Blue here).";
		case 111:
			return "Reorient the Rubik's Cube so that the Blue side is now F. The Red side is R and the Purple side is L.";
		case 112:
			return "The Red side is R. Like last time, this Middle-Layer Edge piece needs to move to the RIGHT. We apply the same algorithm: [U, R, U', R', U', F', U, F]";
		case 113:
			return "Now the Red-Blue side is in the right place. Let's look on the U side for any other Middle Layer Edges.";
		case 114:
			return "This time we only have one option: the Purple-Green Edge.";
		case 115:
			return "Again we align the Purple-Green Edge to make the vertical stack of three matching pieces (Green here).";
		case 116:
			return "Reorient the Rubik's Cube so that the Green side is F. The Purple side is R and the Red side is L.";
		case 117:
			return "The Purple-Green Edge needs to move to the Right, like the two previous Middle Layer Edges. Again we apply the same algoritm: [U, R, U', R', U', F', U, F]";
		case 118:
			return "Now the Purple-Green Edge is in the right place. Let's look on the U side for the last Middle Layer Edge.";
		case 119:
			return "Luckily, the Green-Red Edge is on the U side.";
		case 120:
			return "Let's bring it to the proper starting position to make a vertical stack of three Green pieces.";
		case 121:
			return "Let's set the Green side as F. Unlike the three previous Middle Layer Edges, the Green-Red Edge needs to move to the LEFT. In this case we use a different algorithm: [U', L', U, L, U, F, U', F']";
		case 122:
			return "Now all our Middle Layer Edges are in their correct spots.";
		case 123:
			return "Sometimes, we can get stuck with no Middle Layer Edges left on the U side. In this case, we can apply either of the two algorithms from before, using any side as F.";
		case 124:
			return "Let's choose the Blue side as F and apply the first algorithm we learned in this phase: [U, R, U', R', U', F', U, F]";
		case 125:
			return "Now the Blue-Purple Edge is on the U side.";
		case 126:
			return "Summary of Phase 3:";
		}
		return null;
	}

	//fix algorithm lists
	IEnumerator Steps () {
		List<GameObject> faceCubes;
		string instruction = GetInstruction ();
		tutor.text = instruction;
		switch (tutorialStep) {
		#region Part I
		case 2:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
			}
			break;
		case 3:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				CenterCubes ();
			}
			break;
		case 4:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				EdgeCubes ();
			}
			break;
		case 5:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				CornerCubes ();
			}
			break;
		case 6:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
			}
			break;
		case 7:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				keyboard.SetActive (false);
			}
			break;
		case 8:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				keyboard.SetActive (true);
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_f;
				List<int> moves = new List<int> ();
				moves.Add (f);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (u_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
				break;
		case 9:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_fi;
				List<int> moves = new List<int> ();
				moves.Add (fi);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (u_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 10:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_b;
				List<int> moves = new List<int> ();
				moves.Add (b);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (d_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 11:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_bi;
				List<int> moves = new List<int> ();
				moves.Add (bi);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (d_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 12:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_u;
				List<int> moves = new List<int> ();
				moves.Add (u);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (f_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 13:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_ui;
				List<int> moves = new List<int> ();
				moves.Add (ui);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (f_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 14:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_d;
				List<int> moves = new List<int> ();
				moves.Add (d);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (b_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 15:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_di;
				List<int> moves = new List<int> ();
				moves.Add (di);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (b_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 16:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_r;
				List<int> moves = new List<int> ();
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (l_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 17:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_ri;
				List<int> moves = new List<int> ();
				moves.Add (ri);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (l_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 18:
			if (!stepDone) {
				stepDone = true;
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_l;
				List<int> moves = new List<int> ();
				moves.Add (l);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (r_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}

			break;
		case 19:
			if (!stepDone) {
				stepDone = true;
				keyboard.SetActive (true);
				keyboard.GetComponent<SpriteRenderer> ().sprite = key_li;
				List<int> moves = new List<int> ();
				moves.Add (li);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			AnyColors ();
			faceCubes = GetFaceCubes (r_bounds);
			foreach (GameObject cube in faceCubes) {
				ResetColors (cube);
			}
			break;
		case 20:
			if (!stepDone) {
				stepDone = true;
				ResetColors ();
				keyboard.SetActive (false);
			}
			break;
			#endregion

		#region White Cross
		case 21:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
			}
			break;
		case 23:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				List<int> moves = new List<int> ();
				moves.Add (u);
				moves.Add (u);
				moves.Add (u);
				moves.Add (u);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 27:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCross ();
			}
			break;
		case 28:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCross ();
			}
			break;
		case 29:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCross ();
			}
			break;
		case 30:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross1 ();
			}
			break;
		case 31:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross1 ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
			}
			break;
		case 32:
			//special camera view
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross1 ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				List<int> moves = new List<int> ();
				moves.Add (fi);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 33:
			//special camera view
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross2 ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				List<int> moves = new List<int> ();
				moves.Add (d);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 34:
			//special camera view
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross3 ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
			}
			break;
		case 35:
			//special camera view
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				config1of3.SetActive (false);
				config2of3.SetActive (false);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross3 ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				List<int> moves = new List<int> ();
				moves.Add (r);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 36:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				config1of3.SetActive (true);
				config2of3.SetActive (true);
				config1of3.GetComponent<SpriteRenderer> ().sprite = state1_1a;
				config2of3.GetComponent<SpriteRenderer> ().sprite = state1_1b;
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross4 ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
			}
			break;
		case 37:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				config1of3.SetActive (true);
				config2of3.SetActive (true);
				config1of3.GetComponent<SpriteRenderer> ().sprite = state1_1a;
				config2of3.GetComponent<SpriteRenderer> ().sprite = state1_1b;
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross4 ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				List<int> moves = new List<int> ();
				moves.Add (ri);
				moves.Add (u);
				moves.Add (fi);
				moves.Add (ui);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 38:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				config1of3.SetActive (false);
				config2of3.SetActive (false);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross5 ();
//				List<int> moves = new List<int> ();
//				moves.Add (b);
//				moves.Add (f);
//				moves.Add (f);
//				moves.Add (di);
//				moves.Add (l);
//				moves.Add (l);
//				moves.Add (li);
//				moves.Add (u);
//				moves.Add (bi);
//				moves.Add (ui);
//				moves.Add (li);
//				moves.Add (d);
//				moves.Add (l);
//				moves.Add (f);
//				moves.Add (f);
//				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
//				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
//					yield return null;
//				}
			}
			break;
		case 39:
			//wc6
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				ResetColors (cube22);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross5 ();
			}
			break;
		case 40:
			//wc6
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				ResetColors (cube22);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross5 ();
				List<int> moves = new List<int> ();
				moves.Add (ri);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 41:
			//wc7
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				ResetColors (cube22);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross6 ();
				List<int> moves = new List<int> ();
				moves.Add (r);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 42:
			//wc8
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
//				AnyColors ();
//				CenterCubes ();
//				ResetColors (cube26);
//				ResetColors (cube22);
//				ResetColors (cube20);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross7 ();
			}
			break;
		case 43:
			//wc8
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				ResetColors (cube22);
				ResetColors (cube20);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross7 ();
				List<int> moves = new List<int> ();
				moves.Add (r);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 44:
			//wc9
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				ResetColors (cube22);
				ResetColors (cube20);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross8 ();
				List<int> moves = new List<int> ();
				moves.Add (di);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 45:
			//wc10
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				ResetColors (cube22);
				ResetColors (cube20);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross9 ();
				List<int> moves = new List<int> ();
				moves.Add (r);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 46:
			//wc11
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				CenterCubes ();
				ResetColors (cube26);
				ResetColors (cube22);
				ResetColors (cube20);
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross10 ();
				List<int> moves = new List<int> ();
				moves.Add (ri);
				moves.Add (u);
				moves.Add (fi);
				moves.Add (ui);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 47:
			//wc12
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross11 ();
			}
			break;
		case 48:
			//wc12
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross11 ();
			}
			break;
		case 49:
			//wc12
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross11 ();
			}
			break;
		case 50:
			//wc12
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross11 ();
				List<int> moves = new List<int> ();
				moves.Add (ri);
				moves.Add (d);
				moves.Add (d);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 51:
			//wc13
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross12 ();
			}
			break;
		case 52:
			//wc13
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross12 ();
				List<int> moves = new List<int> ();
				moves.Add (di);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 53:
			//wc14
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCross13 ();
				List<int> moves = new List<int> ();
				moves.Add (r);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;

		
		#endregion

		#region White Corners
		case 55:
			if (!stepDone) {
				stepDone = true;
				config1of3.SetActive (false);
				ResetCube ();
				AnyColors ();
				WhiteCorners ();
			}
			break;
		case 56:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCorners ();
			}
			break;
		case 57:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				WhiteCorners ();
			}
			break;
		case 58:
			//special camera
			//wc1
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners1 ();
			}
			break;
		case 59:
			//special camera
			//wc1
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners1 ();
			}
			break;
		case 60:
			//special camera
			//wc1
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners1 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
			}
			break;
		case 61:
			//special camera
			//wc1
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners1 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
			}
			break;
		case 62:
			//wc1
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners1 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
			}
			break;
		case 63:
			//wc1
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners1 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
			}
			break;
		case 64:
			//wc1
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners1 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
			}
			break;
		case 65:
			//wc1
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners1 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				List<int> moves = new List<int> ();
				moves.Add (di);
				moves.Add (ri);
				moves.Add (d);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 66:
			//wc2
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners2 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
			}
			break;
		case 67:
			//wc2
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners2 ();
				ResetColors ();
			}
			break;
		case 68:
			//wc2
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners2 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
			}
			break;
		case 69:
			//wc2
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners2 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
			}
			break;
		case 70:
			//wc2
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners2 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				List<int> moves = new List<int> ();
				moves.Add (d);
				moves.Add (d);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 71:
			//wc3
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners3 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
			}
			break;
		case 72:
			//wc3
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners3 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				List<int> moves = new List<int> ();
				moves.Add (di);
				moves.Add (ri);
				moves.Add (d);
				moves.Add (d);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 73:
			//wc4
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners4 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
			}
			break;
		case 74:
			//wc4
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners4 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
			}
			break;
		case 75:
			//wc4
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners4 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
			}
			break;
		case 76:
			//wc4
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners4 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				List<int> moves = new List<int> ();
				moves.Add (di);
				moves.Add (ri);
				moves.Add (d);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 77:
			//wc5
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners5 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
			}
			break;
		case 78:
			//wc5
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners5 ();
			}
			break;
		case 79:
			//wc5
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners5 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
			}
			break;
		case 80:
			//wc5
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners5 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
			}
			break;
		case 81:
			//wc5
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners5 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
			}
			break;
		case 82:
			//wc5
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners5 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
			}
			break;
		case 83:
			//wc5
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners5 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
			}
			break;
		case 84:
			//wc5
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners5 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
				List<int> moves = new List<int> ();
				moves.Add (ri);
				moves.Add (di);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 85:
			//wc6
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners6 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
			}
			break;
		case 86:
			//wc6
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners6 ();
			}
			break;
		case 87:
			//wc6
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners6 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
				ResetColors (cube21);
			}
			break;
		case 88:
			//wc6
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners6 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
				ResetColors (cube21);
				List<int> moves = new List<int> ();
				moves.Add (d);
				moves.Add (d);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 89:
			//wc7
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners7 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube25);
				ResetColors (cube00);
				ResetColors (cube19);
				ResetColors (cube21);
				List<int> moves = new List<int> ();
				moves.Add (di);
				moves.Add (ri);
				moves.Add (d);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 90:
			//wc8
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners8 ();
			}
			break;
		case 91:
			//wc9*
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners9 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube00);
			}
			break;
		case 92:
			//wc9*
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners9 ();
				AnyColors ();
				CenterCubes ();
				WhiteCross ();
				ResetColors (cube00);
				List<int> moves = new List<int> ();
				moves.Add (ri);
				moves.Add (di);
				moves.Add (r);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;


		#endregion

		#region Middle Layer
		case 94:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				MiddleLayer ();
			}
			break;
		case 95:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				MiddleLayer ();
			}
			break;
		case 96:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				MiddleLayer ();
			}
			break;
		case 97:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners10 ();
			}
			break;
		case 98:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners10 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 99:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners10 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 100:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners10 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube16);
				ResetColors (cube18);
			}
			break;
		case 101:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners10 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
			}
			break;
		case 102:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners10 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
			}
			break;
		case 103:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_WhiteCorners10 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				List<int> moves = new List<int> ();
				moves.Add (u);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 104:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer1 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
			}
			break;
		case 105:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer1 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
			}
			break;
		case 106:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer1 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				List<int> moves = new List<int> ();
				moves.Add (u);
				moves.Add (r);
				moves.Add (ui);
				moves.Add (ri);
				moves.Add (ui);
				moves.Add (fi);
				moves.Add (u);
				moves.Add (f);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 107:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer2 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 108:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer2 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				ResetColors (cube16);
				ResetColors (cube12);
			}
			break;
		case 109:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer2 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				ResetColors (cube12);
			}
			break;
		case 110:
			//md2
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer2 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				ResetColors (cube12);
				List<int> moves = new List<int> ();
				moves.Add (u);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 111:
			//md3
			//special camera
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer3 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				ResetColors (cube12);
			}
			break;
		case 112:
			//md3
			//moves
			//special camera
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer3 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				ResetColors (cube12);
				List<int> moves = new List<int> ();
				moves.Add (u);
				moves.Add (r);
				moves.Add (ui);
				moves.Add (ri);
				moves.Add (ui);
				moves.Add (fi);
				moves.Add (u);
				moves.Add (f);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 113:
			//md4
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer4 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 114:
			//md4
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer4 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				ResetColors (cube12);
				ResetColors (cube16);
			}
			break;
		case 115:
			//md4
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer4 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				ResetColors (cube12);
				ResetColors (cube16);
				List<int> moves = new List<int> ();
				moves.Add (ui);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 116:
			//md5
			//special camera
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer5 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				ResetColors (cube12);
				ResetColors (cube16);
			}
			break;
		case 117:
			//md5
			//moves
			//special camera
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer5 ();
				StartCoroutine (SwapTopView ());
				WhiteCorners ();
				ResetColors (cube18);
				ResetColors (cube12);
				ResetColors (cube16);
				print (u + " " + r + " " + ui + " " + ri + " " + ui + " " + fi + " " + u + " " + f);
				List<int> moves = new List<int> ();
				moves.Add (u);
				moves.Add (r);
				moves.Add (ui);
				moves.Add (ri);
				moves.Add (ui);
				moves.Add (fi);
				moves.Add (u);
				moves.Add (f);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 118:
			//md6
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer6 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 119:
			//md6
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer6 ();
				StartCoroutine (SwapTopView ());
				MiddleLayer ();
			}
			break;
		case 120:
			//md6
			//moves
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer6 ();
				StartCoroutine (SwapTopView ());
				MiddleLayer ();
				List<int> moves = new List<int> ();
				moves.Add (u);
				moves.Add (u);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 121:
			//md7
			//moves
			//special camera
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer7 ();
				StartCoroutine (SwapTopView ());
				MiddleLayer ();
				List<int> moves = new List<int> ();
				moves.Add (ui);
				moves.Add (li);
				moves.Add (u);
				moves.Add (l);
				moves.Add (u);
				moves.Add (f);
				moves.Add (ui);
				moves.Add (fi);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 122:
			//md8
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer8 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 123:
			//md9
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer9();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 124:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer9 ();
				StartCoroutine (SwapTopView ());
				List<int> moves = new List<int> ();
				moves.Add (u);
				moves.Add (r);
				moves.Add (ui);
				moves.Add (ri);
				moves.Add (ui);
				moves.Add (fi);
				moves.Add (u);
				moves.Add (f);
				StartCoroutine (solver.GetComponent<TutorialSolver> ().Algorithm (moves));
				while (solver.GetComponent<TutorialSolver> ().IsSolving ()) {
					yield return null;
				}
			}
			break;
		case 125:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer10 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		#endregion


		case 127:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCross ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 128:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer8 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 129:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer8 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 130:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCorners ();
				solver.GetComponent<TutorialScrambler> ().Tutor_MiddleLayer8 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 131:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCross1 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 132:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCross2 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 133:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCross3 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 134:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCross4 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 135:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCross ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCross5 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 136:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCorners ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCorners1 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 137:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCorners ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCorners2 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 138:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
//				AnyColors ();
//				YellowCorners ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCorners3 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 139:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCorners ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCorners4 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 140:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				AnyColors ();
				YellowCorners ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCorners5 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		case 141:
			if (!stepDone) {
				stepDone = true;
				ResetCube ();
				ResetColors ();
				solver.GetComponent<TutorialScrambler> ().Tutor_YellowCorners5 ();
				StartCoroutine (SwapTopView ());
			}
			break;
		}
		yield return null;
	}


	#region Groups
	void Front () {
		AnyColors ();
		List<GameObject> faceCubes = GetFaceCubes (sortedBounds [0]);
		foreach (GameObject cube in faceCubes) {
			ResetColors (cube);
		}
	}

	void Down () {
		AnyColors ();
		List<GameObject> faceCubes = GetFaceCubes (sortedBounds [1]);
		foreach (GameObject cube in faceCubes) {
			ResetColors (cube);
		}
	}

	void Right () {
		AnyColors ();
		List<GameObject> faceCubes = GetFaceCubes (sortedBounds [2]);
		foreach (GameObject cube in faceCubes) {
			ResetColors (cube);
		}
	}

	void Up () {
		AnyColors ();
		List<GameObject> faceCubes = GetFaceCubes (sortedBounds [3]);
		foreach (GameObject cube in faceCubes) {
			ResetColors (cube);
		}
	}
		
	void Left () {
		AnyColors ();
		List<GameObject> faceCubes = GetFaceCubes (sortedBounds [4]);
		foreach (GameObject cube in faceCubes) {
			ResetColors (cube);
		}
	}

	void Back () {
		AnyColors ();
		List<GameObject> faceCubes = GetFaceCubes (sortedBounds [5]);
		foreach (GameObject cube in faceCubes) {
			ResetColors (cube);
		}
	}



	void CenterCubes () {
		ResetColors (cube05);
		ResetColors (cube11);
		ResetColors (cube13);
		ResetColors (cube15);
		ResetColors (cube17);
		ResetColors (cube23);
	}
	
	void EdgeCubes () {
		ResetColors (cube02);
		ResetColors (cube04);
		ResetColors (cube06);
		ResetColors (cube08);
		ResetColors (cube10);
		ResetColors (cube12);
		ResetColors (cube16);
		ResetColors (cube18);
		ResetColors (cube20);
		ResetColors (cube22);
		ResetColors (cube24);
		ResetColors (cube26);
	}

	void CornerCubes () {
		ResetColors (cube00);
		ResetColors (cube01);
		ResetColors (cube03);
		ResetColors (cube07);
		ResetColors (cube09);
		ResetColors (cube19);
		ResetColors (cube21);
		ResetColors (cube25);
	}

	void WhiteCross () {
		ResetColors (cube23);
		ResetColors (cube11);
		ResetColors (cube15);
		ResetColors (cube17);
		ResetColors (cube13);
		ResetColors (cube20);
		ResetColors (cube24);
		ResetColors (cube26);
		ResetColors (cube22);
	}

	void WhiteCorners () {
		ResetColors (cube23);
		ResetColors (cube11);
		ResetColors (cube15);
		ResetColors (cube17);
		ResetColors (cube13);
		ResetColors (cube20);
		ResetColors (cube24);
		ResetColors (cube26);
		ResetColors (cube22);
		ResetColors (cube21);
		ResetColors (cube00);
		ResetColors (cube25);
		ResetColors (cube19);
	}

	void MiddleLayer () {
		ResetColors (cube23);
		ResetColors (cube11);
		ResetColors (cube15);
		ResetColors (cube17);
		ResetColors (cube13);
		ResetColors (cube20);
		ResetColors (cube24);
		ResetColors (cube26);
		ResetColors (cube22);
		ResetColors (cube21);
		ResetColors (cube00);
		ResetColors (cube25);
		ResetColors (cube19);
		ResetColors (cube12);
		ResetColors (cube18);
		ResetColors (cube16);
		ResetColors (cube10);
	}

	void YellowCross () {
		MiddleLayer ();
		ResetColors (cube05);
		ResetColors (cube04);
		ResetColors (cube08);
		ResetColors (cube02);
		ResetColors (cube06);
		foreach (GameObject cube in yellowCross) {
			Material[] mats = cube.GetComponent<Renderer> ().materials;
			int i = 0;
			foreach (Material mat in mats) {
				if (mat.name != "Yellow (Instance)") {
					if (mat.name != "Plastic (Instance)") {
						mats [i] = any;
					}
				}
				i++;
			}
			cube.GetComponent<Renderer> ().materials = mats;
		}

	}

	void YellowCorners () {
		YellowCross ();
		ResetColors (cube07);
		ResetColors (cube01);
		ResetColors (cube09);
		ResetColors (cube03);
		foreach (GameObject cube in yellowCorners) {
			Material[] mats = cube.GetComponent<Renderer> ().materials;
			int i = 0;
			foreach (Material mat in mats) {
				if (mat.name != "Yellow (Instance)") {
					if (mat.name != "Plastic (Instance)") {
						mats [i] = any;
					}
				}
				i++;
			}
			cube.GetComponent<Renderer> ().materials = mats;
		}
	}

	void TopLayer () {
		YellowCross ();
		ResetColors (cube07);
		ResetColors (cube01);
		ResetColors (cube09);
		ResetColors (cube03);
	}
	#endregion

	void AnyColors () {
		ResetColors ();
		foreach (GameObject cube in allCubes) {
			Material[] mats = cube.GetComponent<Renderer> ().materials;
			int i = 0;
			foreach (Material mat in mats) {
				if (mat.name != "Plastic (Instance)") {
					mats [i] = any;
				}
				i++;
			}
			cube.GetComponent<Renderer> ().materials = mats;
		}
	}

	void ResetColors () {
		foreach (GameObject cube in allCubes) {
			string cubeNum = cube.name.Substring (5);
			Material[] mats = GetOriginalColors (cubeNum);
			cube.GetComponent<Renderer> ().materials = mats;
		}
	}

	void ResetColors (GameObject cube) {
		string cubeNum = cube.name.Substring (5);
		Material[] mats = GetOriginalColors (cubeNum);
		cube.GetComponent<Renderer> ().materials = mats;
	}

	Material[] GetOriginalColors (string cubeIndex) {
		switch (cubeIndex) {
		case "00":
			return original00;
			
		case "01":
			return original01;
			
		case "02":
			return original02;
			
		case "03":
			return original03;
			
		case "04":
			return original04;
			
		case "05":
			return original05;
			
		case "06":
			return original06;
			
		case "07":
			return original07;
			
		case "08":
			return original08;
			
		case "09":
			return original09;
			
		case "10":
			return original10;
			
		case "11":
			return original11;
			
		case "12":
			return original12;
			
		case "13":
			return original13;
			
		case "14":
			return original14;
			
		case "15":
			return original15;
			
		case "16":
			return original16;
			
		case "17":
			return original17;
			
		case "18":
			return original18;
			
		case "19":
			return original19;
			
		case "20":
			return original20;
			
		case "21":
			return original21;
			
		case "22":
			return original22;
			
		case "23":
			return original23;
			
		case "24":
			return original24;
			
		case "25":
			return original25;
			
		case "26":
			return original26;
			
		}
		return original00;
	}

	void GlowOff () {
		foreach (GameObject cube in allCubes) {
			Material[] mats = cube.GetComponent<Renderer> ().materials;
			int i = 0;
			foreach (Material mat in mats) {
				if (mat.name == "Glow (Instance)") {
					mats [i] = plastic;
				}
				i++;
			}
			cube.GetComponent<Renderer> ().materials = mats;
		}
	}

	void GlowOn (Bounds bound) {
		List<GameObject> faceCubes = GetFaceCubes (bound);
		foreach (GameObject cube in faceCubes) {
			Material[] mats = cube.GetComponent<Renderer> ().materials;
			int i = 0;
			foreach (Material mat in mats) {
				if (mat.name == "Plastic (Instance)") {
					mats [i] = glow;
				}
				i++;
			}
			cube.GetComponent<Renderer> ().materials = mats;
		}
	}

	void GlowOn (GameObject cube) {
		Material[] mats = cube.GetComponent<Renderer> ().materials;
		int i = 0;
		foreach (Material mat in mats) {
			if (mat.name == "Plastic (Instance)") {
				mats [i] = glow;
			}
			i++;
		}
		cube.GetComponent<Renderer> ().materials = mats;
	}

	List<GameObject> GetFaceCubes(Bounds bound) {
		List<GameObject> faceCubes = new List<GameObject> ();
		List<Vector3> allCubesCenters = GetCubesCenters ();
		foreach (Vector3 center in allCubesCenters) {
			if (bound.Contains(center)) {
				int i = allCubesCenters.IndexOf(center);
				faceCubes.Add(allCubes[i]);
			}
		}
		return faceCubes;
	}

	List<Vector3> GetCubesCenters () {
		List<Vector3> allCubesCenters = new List<Vector3> ();
		foreach (GameObject cube in allCubes) {
			Vector3 cubeCenter = cube.GetComponent<BoxCollider> ().bounds.center;
			allCubesCenters.Add (cubeCenter);
		}
		return allCubesCenters;
	}

	void ResetCube () {
		if (sunnySideUp < 1) {
			StartCoroutine (SwapTopView ());
		}
		foreach (GameObject cube in allCubes) {
			cube.transform.rotation = whiteSideUp;
		}
	}

	void SetSideUp () {
		doUpSwap = false;
		sunnySideUp *= -1;
	}

	IEnumerator SwapTopView () {
		while (solver.GetComponent<TutorialSolver> ().IsTurning ()) {
			yield return null;
		}
		doUpSwap = false;
		sunnySideUp *= -1;
		Vector3 sun = new Vector3 (180, 0, 0);
		this.transform.rotation *= Quaternion.Euler (sun);
		faceConfig = cam.GetComponent<TutorialCamera> ().GetFaceConfig ();
		ConfigureMoves ();
		SetFaceTransforms ();
		solver.GetComponent<TutorialSolver> ().SetFaceTransforms ();
		yield return null;
	}

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




		f_bounds = allFacesBounds [5];
		d_bounds = allFacesBounds [1];
		r_bounds = allFacesBounds [4];
		u_bounds = allFacesBounds [3];
		l_bounds = allFacesBounds [2];
		b_bounds = allFacesBounds [0];
	}



	public void Test () {
		print (tutorialStep);
	}

	public void SkipToPhaseII () {
		tutorialStep = 138;
	}

	public int GetFaceConfig () {
		return faceConfig;
	}

	public int GetUpFace () {
		return sunnySideUp;
	}

	public int GetTutorialStep () {
		return tutorialStep;
	}

	public void EndTutorial () {
		SceneManager.LoadScene ("_main");
	}

}
