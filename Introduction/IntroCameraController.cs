using UnityEngine;
using System.Collections;

public class IntroCameraController : MonoBehaviour {

	public GameObject rubiksCube;
	public float speed = 1f;
	private float distance;
	private float x = 30;
	private float y = -135;

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

}
