using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public MovableCharacter characterOne, characterTwo;




	private static PlayerController _instance;
	public static PlayerController Instance { get { return _instance; } }


	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		}
		else {
			_instance = this;
		}
	}
	private void Update() {
		// ReadInputManager.ReadAxes();
		if (Input.GetButton("Horizontal1") || Input.GetButton("Vertical1")) {
			characterOne.UpdatePosition(new Vector2(
			Input.GetAxis("Horizontal1"),
			Input.GetAxis("Vertical1")));
		}

		if (Input.GetButton("Horizontal2") || Input.GetButton("Vertical2")) {
			characterTwo.UpdatePosition(new Vector2(
			Input.GetAxis("Horizontal2"),
			Input.GetAxis("Vertical2")));
		}


	}
}
