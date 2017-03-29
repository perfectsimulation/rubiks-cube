using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject rubiksCube;
	public GameObject solver;
	public float speed = 1f;

	private int faceConfig;

	private float distance;
	private float x = 25;
	private float y = 45;

	void Start () {
		distance = transform.position.magnitude;
	}

	void Update () {
		x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;

		x = Mathf.Clamp (x, -89, 89);

		Quaternion q = Quaternion.Euler (x, y, 0);
		Vector3 direction = q * Vector3.forward;
		transform.position = rubiksCube.transform.position - distance * direction;
		transform.LookAt (rubiksCube.transform.position);
	}

	public int GetFaceConfig () {
		int sunnySideUp = solver.GetComponent<Solver> ().GetUpFace ();
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

	public void Test () {
		int f = GetFaceConfig ();
		print (f);
	}

}
