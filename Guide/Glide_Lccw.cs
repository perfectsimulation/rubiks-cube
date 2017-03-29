using UnityEngine;
using System.Collections;

/// <summary>
/// This class animates its associated GameObject to show the user a hint to make a counterclockwise
/// turn on the Purple side.
/// </summary>
public class Glide_Lccw : MonoBehaviour {

	/// <summary>
	/// Update this instance by "animating" the GameObject this MonoBehaviour is attached to.
	/// </summary>
	void Update () {
		Vector3 current = this.transform.position;
		Vector3 target1 = new Vector3 (1.5f, -1.5f, current.z);
		Vector3 target2 = new Vector3 (1.5f, 1.5f, current.z);
		Vector3 target3 = new Vector3 (-1.5f, 1.5f, current.z);
		Vector3 target4 = new Vector3 (-1.5f, -1.5f, current.z);

		Quaternion rot1 = Quaternion.Euler (0, 0, 90f);
		Quaternion rot2 = Quaternion.Euler (0, 0, 180f);
		Quaternion rot3 = Quaternion.Euler (0, 0, -90f);
		Quaternion rot4 = Quaternion.Euler (0, 0, 0);

		float speed = 0.02f;

		if (current.y == -1.5f && !(current.x == 1.5f)) {
			transform.position = Vector3.MoveTowards (current, target1, speed);
			transform.rotation = rot1;
		}
		current = this.transform.position;
		if (current.x == 1.5f && !(current.y == 1.5f)) {
			transform.position = Vector3.MoveTowards (current, target2, speed);
			transform.rotation = rot2;
		}
		current = this.transform.position;
		if (current.y == 1.5f && !(current.x == -1.5f)) {
			transform.position = Vector3.MoveTowards (current, target3, speed);
			transform.rotation = rot3;
		}
		current = this.transform.position;
		if (current.x == -1.5f && !(current.y == -1.5f)) {
			transform.position = Vector3.MoveTowards (current, target4, speed);
			transform.rotation = rot4;
		}
	}

}
