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
			while (tutorialStep == 8) {
				yield return null;
			}
			break;

		case 9:
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
			while (tutorialStep == 9) {
				yield return null;
			}
			break;

		case 10:
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
			while (tutorialStep == 10) {
				yield return null;
			}
			break;

		case 11:
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
			while (tutorialStep == 11) {
				yield return null;
			}
			break;

		case 12:
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
			while (tutorialStep == 12) {
				yield return null;
			}
			break;

		case 13:
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
			while (tutorialStep == 13) {
				yield return null;
			}
			break;

		case 14:
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
			while (tutorialStep == 14) {
				yield return null;
			}
			break;

		case 15:
			if (!stepDone) {
				x = 30;
				y = 90;
			}
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
			while (tutorialStep == 16) {
				yield return null;
			}
			break;

		case 17:
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
			while (tutorialStep == 17) {
				yield return null;
			}
			break;

		case 18:
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
			while (tutorialStep == 18) {
				yield return null;
			}
			break;

		case 19:
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

		case 21:
			if (!stepDone) {
				x = 25;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 21) {
				yield return null;
			}
			break;

		case 27:
			if (!stepDone) {
				x = 25;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 27) {
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
				y = 60;
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
				y = 60;
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
				y = 60;
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

		case 36:
			if (!stepDone) {
				x = 30;
				y = 60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 36) {
				yield return null;
			}
			break;

		case 37:
			if (!stepDone) {
				x = 30;
				y = 60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 37) {
				yield return null;
			}
			break;

		case 40:
			if (!stepDone) {
				x = 30;
				y = -30;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 40) {
				yield return null;
			}
			break;

		case 41:
			if (!stepDone) {
				x = 30;
				y = -30;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 41) {
				yield return null;
			}
			break;

		case 43:
			if (!stepDone) {
				x = 30;
				y = 150;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 43) {
				yield return null;
			}
			break;

		case 44:
			if (!stepDone) {
				x = 30;
				y = 150;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 44) {
				yield return null;
			}
			break;

		case 45:
			if (!stepDone) {
				x = 30;
				y = -120;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 45) {
				yield return null;
			}
			break;
		case 46:
			if (!stepDone) {
				x = 30;
				y = -120;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 46) {
				yield return null;
			}
			break;

		case 50:
			if (!stepDone) {
				x = 30;
				y = -120;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 50) {
				yield return null;
			}
			break;

		case 53:
			if (!stepDone) {
				x = 30;
				y = 150;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 53) {
				yield return null;
			}
			break;

		case 55:
			if (!stepDone) {
				x = 25;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 55) {
				yield return null;
			}
			break;

		case 60:
			if (!stepDone) {
				x = 30;
				y = -45;
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

		case 65:
			if (!stepDone) {
				x = 30;
				y = -45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 65) {
				yield return null;
			}
			break;


		case 72:
			if (!stepDone) {
				x = 30;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 72) {
				yield return null;
			}
			break;

		case 76:
			if (!stepDone) {
				x = 30;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 76) {
				yield return null;
			}
			break;

		case 85:
			if (!stepDone) {
				x = 30;
				y = -120;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 85) {
				yield return null;
			}
			break;

		case 89:
			if (!stepDone) {
				x = 30;
				y = -210;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 89) {
				yield return null;
			}
			break;

		case 91:
			if (!stepDone) {
				x = 30;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 91) {
				yield return null;
			}
			break;

		case 92:
			if (!stepDone) {
				x = 30;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 92) {
				yield return null;
			}
			break;

		case 94:
			if (!stepDone) {
				x = 25;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 94) {
				yield return null;
			}
			break;

		case 106:
			if (!stepDone) {
				x = 30;
				y = -210;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 106) {
				yield return null;
			}
			break;

		case 112:
			if (!stepDone) {
				x = 30;
				y = 60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 112) {
				yield return null;
			}
			break;

		case 117:
			if (!stepDone) {
				x = 30;
				y = -120;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 117) {
				yield return null;
			}
			break;

		case 121:
			if (!stepDone) {
				x = 30;
				y = -60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 121) {
				yield return null;
			}
			break;

		case 124:
			if (!stepDone) {
				x = 30;
				y = 60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 124) {
				yield return null;
			}
			break;

		case 127:
			if (!stepDone) {
				x = 25;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 127) {
				yield return null;
			}
			break;

		case 135:
			if (!stepDone) {
				x = 30;
				y = 60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 135) {
				yield return null;
			}
			break;

		case 139:
			if (!stepDone) {
				x = 30;
				y = -210;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 139) {
				yield return null;
			}
			break;

		case 146:
			if (!stepDone) {
				x = 30;
				y = 60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 146) {
				yield return null;
			}
			break;

		case 148:
			if (!stepDone) {
				x = 30;
				y = 60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 148) {
				yield return null;
			}
			break;

		case 151:
			if (!stepDone) {
				x = 25;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 151) {
				yield return null;
			}
			break;

		case 160:
			if (!stepDone) {
				x = 30;
				y = 30;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 160) {
				yield return null;
			}
			break;

		case 164:
			if (!stepDone) {
				x = 30;
				y = -60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 164) {
				yield return null;
			}
			break;

		case 173:
			if (!stepDone) {
				x = 30;
				y = -60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 173) {
				yield return null;
			}
			break;

		case 177:
			if (!stepDone) {
				x = 30;
				y = 30;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 177) {
				yield return null;
			}
			break;

		case 180:
			if (!stepDone) {
				x = 30;
				y = 210;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 180) {
				yield return null;
			}
			break;

		case 185:
			if (!stepDone) {
				x = 30;
				y = 30;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 185) {
				yield return null;
			}
			break;

		case 187:
			if (!stepDone) {
				x = 30;
				y = 30;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 187) {
				yield return null;
			}
			break;

		case 189:
			if (!stepDone) {
				x = 30;
				y = 210;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 189) {
				yield return null;
			}
			break;

		case 192:
			if (!stepDone) {
				x = 25;
				y = 45;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 192) {
				yield return null;
			}
			break;

		case 202:
			if (!stepDone) {
				x = 30;
				y = 60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 202) {
				yield return null;
			}
			break;

		case 207:
			if (!stepDone) {
				x = 30;
				y = 60;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 207) {
				yield return null;
			}
			break;

		case 212:
			if (!stepDone) {
				x = 30;
				y = 150;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 212) {
				yield return null;
			}
			break;

		case 221:
			if (!stepDone) {
				x = 30;
				y = -30;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 221) {
				yield return null;
			}
			break;

		case 225:
			if (!stepDone) {
				x = 30;
				y = 120;
			}
			x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			x = Mathf.Clamp (x, -89, 89);
			q = Quaternion.Euler (x, y, 0);
			direction = q * Vector3.forward;
			transform.position = rubiksCube.transform.position - distance * direction;
			transform.LookAt (rubiksCube.transform.position);
			while (tutorialStep == 225) {
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
			int thisStep = rubiksCube.GetComponent<Tutorial> ().GetTutorialStep ();
			while (tutorialStep == thisStep) {
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
