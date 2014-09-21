using UnityEngine;
using System.Collections;

public class TractorController : MonoBehaviour {

	public float tractorSpeed;

	private Laser _laser;
	private CharacterController _character;
	// Use this for initialization
	void Start () {
		_laser = GetComponentInChildren<Laser>();
		_character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_laser.canTransport) {

			if (Input.GetButtonDown("Fire2")) {
				_laser.ActivateColor(true);
			}

			if (Input.GetButton("Fire2")) {
				Vector3 target = - (transform.position - _laser.hookPoint);
				_character.Move(target*Time.deltaTime*tractorSpeed);
			}

			if (Input.GetButtonUp("Fire2")) {
				_laser.ActivateColor(false);
			}
		}
	}
}
