using UnityEngine;
using System.Collections;

public class TutorialCamera : MonoBehaviour {

	public GameObject solver;
	private int faceConfig;

	public GameObject rubiksCube;
	public float speed = 1f;

	private int tutorialStep;
	private float distance;
	private float x = 25;
	private float y = 45;

	private bool stepDone;

	void Start () {
		distance = transform.position.magnitude;
		tutorialStep = rubiksCube.GetComponent<Tutorial> ().GetTutorialStep ();
	}

	void Update () {
		ChangeStep ();
		StartCoroutine (SetView (tutorialStep));
	}

	void ChangeStep () {
		int newStep = rubiksCube.GetComponent<Tutorial> ().GetTutorialStep ();
		if (!newStep.Equals (tutorialStep)) {
			tutorialStep = rubiksCube.GetComponent<Tutorial> ().GetTutorialStep ();
			stepDone = false;
		} else {
			stepDone = true;
		}
	}

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


//		q = Quaternion.Euler (x, y, 0);
//		direction = q * Vector3.forward;
//		transform.position = rubiksCube.transform.position - distance * direction;


	IEnumerator SpinCube () {
		Vector3 r = new Vector3 (0, 1, 0);
		rubiksCube.transform.RotateAround (rubiksCube.transform.position, r, 30f * Time.deltaTime);
		yield return null;
	}
		



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
