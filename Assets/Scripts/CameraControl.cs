using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	public GameObject target;
	private Vector3 offset;


	// Use this for initialization
	void Start () {
		if (target == null)
			target = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - target.transform.position;
		//offset.position = target.GetComponent<Transform> ().position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = target.GetComponent<Transform> ().position + offset;
	}
}
