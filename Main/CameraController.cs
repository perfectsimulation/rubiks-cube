using UnityEngine;
using System.Collections;

/// <summary>
/// This class contains methods to control the camera according to the user inputs.
/// </summary>
public class CameraController : MonoBehaviour {

	// The GameObject variable |rubiksCube| is the entire Rubik's Cube.
	public GameObject rubiksCube;

	// The GameObject variable |solver| contains the script to solve the Rubik's Cube.
	public GameObject solver;

	// The float variable |speed| is the speed with which the camera view moves upon the user inputs.
	public float speed = 1f;

	// The int variable |faceConfig| represents the current F side according to the camera's transform.
	private int faceConfig;

	// The float variable |distance| is how far away the camera is from the |rubiksCube|.
	private float distance;

	// The following float variables |x| and |y| are the x and y coordinates of the camera's transform.
	private float x = 25;
	private float y = 45;

	/// <summary>
	/// Start this instance by assigning a value to |distance|.
	/// </summary>
	void Start () {
		distance = transform.position.magnitude;
	}

	/// <summary>
	/// Update this instance by checking for user inputs to move the view and applying the appropriate
	/// transformations.
	/// </summary>
	void Update () {
		x += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		y += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;

		// Problems arise when |x| is not restricted on the following interval.
		x = Mathf.Clamp (x, -89, 89);

		// Change the camera transform according to the user inputs.
		Quaternion q = Quaternion.Euler (x, y, 0);
		Vector3 direction = q * Vector3.forward;
		transform.position = rubiksCube.transform.position - distance * direction;
		transform.LookAt (rubiksCube.transform.position);
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

	/// <summary>
	/// Prints the current |faceConfig|. Used for debugging.
	/// </summary>
	public void Test () {
		int f = GetFaceConfig ();
		print (f);
	}

}
