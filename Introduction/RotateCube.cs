using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour {

	private Vector3 r;

	void Start () {
		r = new Vector3 (1, 0, 0);
	}

	void Update () {
		this.transform.RotateAround (this.transform.position, r, 30f*Time.deltaTime);
	}
}
