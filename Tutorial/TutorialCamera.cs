using UnityEngine;
using System.Collections;

/// <summary>
/// This class contains methods to control the camera according to the user inputs. In addition, it
/// changes the camera transform according to the tutorial.
/// </summary>
/// 
/// <remarks>
/// This script is incomplete. The method SetView needs to be updated to control the camera behavior for
/// the later phases of the tutorial.
/// </remarks>
public class TutorialCamera : MonoBehaviour {

	// The GameObject variable |rubiksCube| is the entire Rubik's Cube.
	public GameObject rubiksCube;

	// The GameObject variable |solver| contains the script to solve the Rubik's Cube.
	public GameObject solver;

	// The float variable |speed| is the speed with which the camera view moves upon the user inputs.
	public float speed = 1f;

	// The int variable |faceConfig| represents the current F side according to the camera's transform.
	private int faceConfig;

	// The int variable |tutorialStep| represents which step of the tutorial is currently active.
	private int tutorialStep;

	// The float variable |distance| is how far away the camera is from the |rubiksCube|.
	private float distance;

	// The following float variables |x| and |y| are the x and y coordinates of the camera's transform.
	private float x = 25;
	private float y = 45;

	// The bool variable |stepDone| is true when the user has changed the tutorial step and the associated
	// methods of the new step have been completed one time.
	private bool stepDone;

	/// <summary>
	/// Start this instance by assigning a value to |distance|. The current tutorial step is retrieved
	/// from the Tutorial script attached to |rubiksCube|.
	/// </summary>
	void Start () {
		distance = transform.position.magnitude;
		tutorialStep = rubiksCube.GetComponent<Tutorial> ().GetTutorialStep ();
	}

	/// <summary>
	/// Update this instance by checking if the user has moved to a different step in the tutorial.
	/// Sets the camera transform according to the current step of the tutorial.
	/// </summary>
	void Update () {
		ChangeStep ();
		StartCoroutine (SetView (tutorialStep));
	}

	/// <summary>
	/// Checks if the user has changed the current step. If the step has changed, the |stepDone| is
	/// set to false, otherwise |stepDone| is set to true.
	/// </summary>
	void ChangeStep () {
		int newStep = rubiksCube.GetComponent<Tutorial> ().GetTutorialStep ();
		if (!newStep.Equals (tutorialStep)) {
			tutorialStep = rubiksCube.GetComponent<Tutorial> ().GetTutorialStep ();
			stepDone = false;
		} else {
			stepDone = true;
		}
	}

	/// <summary>
	/// Sets the camera transform according to the user inputs, as well as the current step of the
	/// tutorial.
	/// </summary>
	/// 
	/// <remarks>
	/// This method uses a switch case to determine the behavior of the camera for a given step of
	/// the tutorial. Depending on the step, the F side may change to a different color. This is
	/// necessary to ensure the methods used in the Tutorial script execute correctly.
	/// </remarks>
	/// <param name="tutorialStep">The current tutorial step.</param>
	IEnumerator SetView (int tutorialStep) {
		Quaternion q = Quaternion.Euler (x, y, 0);
		Vector3 direction = q * Vector3.forward;
		switch (tutorialStep) {
		case 0:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 0) {
				yield return null;
			}
			break;
		case 1:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 1) {
				yield return null;
			}
			break;
		case 2:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 2) {
				yield return null;
			}
			break;
		case 3:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 3) {
				yield return null;
			}
			break;
		case 4:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 4) {
				yield return null;
			}
			break;
		case 5:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 5) {
				yield return null;
			}
			break;
		case 6:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 6) {
				yield return null;
			}
			break;
		case 7:
			if (!stepDone) {
				x = 30;
				y = 90;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 7) {
				yield return null;
			}
			break;
		case 8:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 8) {
				yield return null;
			}
			break;
		case 9:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 9) {
				yield return null;
			}
			break;
		case 10:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 10) {
				yield return null;
			}
			break;
		case 11:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 11) {
				yield return null;
			}
			break;
		case 12:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 12) {
				yield return null;
			}
			break;
		case 13:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 13) {
				yield return null;
			}
			break;
		case 14:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 14) {
				yield return null;
			}
			break;
		case 15:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 15) {
				yield return null;
			}
			break;
		case 16:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 16) {
				yield return null;
			}
			break;
		case 17:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 17) {
				yield return null;
			}
			break;
		case 18:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 18) {
				yield return null;
			}
			break;
		case 19:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 19) {
				yield return null;
			}
			break;
		case 20:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 20) {
				yield return null;
			}
			break;

		case 30:
			if (!stepDone) {
				x = 30;
				y = 90;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 30) {
				yield return null;
			}
			break;
		case 31:
			if (!stepDone) {
				x = 30;
				y = 90;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 31) {
				yield return null;
			}
			break;
		case 32:
			if (!stepDone) {
				x = 30;
				y = 90;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 32) {
				yield return null;
			}
			break;
		case 33:
			if (!stepDone) {
				x = 30;
				y = 90;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 33) {
				yield return null;
			}
			break;
		case 34:
			if (!stepDone) {
				x = 30;
				y = 90;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 34) {
				yield return null;
			}
			break;
		case 35:
			if (!stepDone) {
				x = 30;
				y = 90;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 35) {
				yield return null;
			}
			break;


		case 60:
			if (!stepDone) {
				x = 30;
				y = 135;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 60) {
				yield return null;
			}
			break;

		case 68:
			if (!stepDone) {
				x = 30;
				y = 180;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 68) {
				yield return null;
			}
			break;



		default:
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 5) {
				yield return null;
			}
			break;







		}
	}

	// The following lines of code are a template and used in each tutorial step to enable the user
	// to change the view of the Rubik's Cube.
//		q = Quaternion.Euler (x, y, 0);
//		direction = q * Vector3.forward;
//		transform.position = rubiksCube.transform.position - distance * direction;

	/// <summary>
	/// Spins the Rubik's Cube. This method doesn't work as it is.
	/// </summary>
	IEnumerator SpinCube () {
		Vector3 r = new Vector3 (0, 1, 0);
		rubiksCube.transform.RotateAround (rubiksCube.transform.position, r, 30f * Time.deltaTime);
		yield return null;
	}
		


	/// <summary>
	/// Gets the face config associated with the current camera transform.
	/// </summary>
	/// 
	/// <remarks>
	/// When the int return variable is...
	/// 0: F = Blue, U = White
	/// 1: F = Blue, U = Yellow
	/// 2: F = Purple, U = White
	/// 3: F = Red, U = Yellow
	/// 4: F = Green, U = White
	/// 5: F = Green, U = Yellow
	/// 6: F = Red, U = White
	/// 7: F = Purple, U = Yellow
	/// </remarks>
	/// 
	/// <returns>The face config.</returns>
	public int GetFaceConfig () {
		int sunnySideUp = rubiksCube.GetComponent<Tutorial> ().GetUpFace ();
		float y = this.transform.rotation.eulerAngles.y;
		y = (y > 180) ? y - 360 : y;
		if ((y >= 45f) && (y < 135f)) {
			faceConfig = (sunnySideUp > 0) ? 0 : 1;
		} else if ((y >= -135f) && (y < -45f)) {
			faceConfig = (sunnySideUp > 0) ? 4 : 5;
		} else if ((y >= -45f) && (y < 45f)) {
			if (sunnySideUp > 0) {
				faceConfig = 2;
			} else if (sunnySideUp < 0) {
				faceConfig = 3;
			}
		} else {
			if (sunnySideUp > 0) {
				faceConfig = 6;
			} else if (sunnySideUp < 0) {
				faceConfig = 7;
			}
		}
		return faceConfig;
	}


}
