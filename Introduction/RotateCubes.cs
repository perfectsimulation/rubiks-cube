using UnityEngine;
using System.Collections;

public class RotateCubes : MonoBehaviour {

	private Vector3 r;
	private Vector3 backPos = Vector3.zero;
	public GameObject back;

	void Start () {
		r = new Vector3 (1, 1, 1);
		backPos = new Vector3 (.1f, .1f, -100);
	}

	void Update () {
		this.transform.RotateAround (Vector3.zero, r, 10f*Time.deltaTime);
		this.transform.Translate (-backPos * Time.deltaTime * 0.01f);
	}
}
