using UnityEngine;
using System.Collections;

public class Glide_Lcw : MonoBehaviour {

	void Update () {
		Vector3 current = this.transform.position;
		Vector3 target1 = new Vector3 (-1.5f, 1.5f, current.z);
		Vector3 target2 = new Vector3 (1.5f, 1.5f, current.z);
		Vector3 target3 = new Vector3 (1.5f, -1.5f, current.z);
		Vector3 target4 = new Vector3 (-1.5f, -1.5f, current.z);

		Quaternion rot1 = Quaternion.Euler (0, 0, 0);
		Quaternion rot2 = Quaternion.Euler (0, 0, -90f);
		Quaternion rot3 = Quaternion.Euler (0, 0, -180f);
		Quaternion rot4 = Quaternion.Euler (0, 0, 90f);

		float speed = 0.02f;

		if (current.x == -1.5f && !(current.y == 1.5f)) {
			transform.position = Vector3.MoveTowards (current, target1, speed);
			transform.rotation = rot1;
		}
		current = this.transform.position;
		if (current.y == 1.5f && !(current.x == 1.5f)) {
			transform.position = Vector3.MoveTowards (current, target2, speed);
			transform.rotation = rot2;
		}
		current = this.transform.position;
		if (current.x == 1.5f && !(current.y == -1.5f)) {
			transform.position = Vector3.MoveTowards (current, target3, speed);
			transform.rotation = rot3;
		}
		current = this.transform.position;
		if (current.y == -1.5f && !(current.x == -1.5f)) {
			transform.position = Vector3.MoveTowards (current, target4, speed);
			transform.rotation = rot4;
		}
	}

}
