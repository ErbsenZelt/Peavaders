using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCharacter : MonoBehaviour {
	[HideInInspector]
	public Rigidbody rb;

	[Range(5, 20)]
	public float moveSpeed = 5;
	
	void Start () {
		rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
		rb.isKinematic = true;
	}
	


	public void UpdatePosition(Vector2 axisValue){
		transform.localPosition += axisValue.x * transform.right * Time.deltaTime * moveSpeed;
		transform.localPosition += axisValue.y * transform.forward * Time.deltaTime * moveSpeed;
	}
}
