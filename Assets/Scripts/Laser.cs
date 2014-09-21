using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float rayLength;
	public Color inactiveColor1;
	public Color inactiveColor2;
	public Color activeColor1;
	public Color activeColor2;

	public bool canTransport;
	public Vector3 hookPoint;

	
	private LineRenderer _line;
	private Ray _ray;
	private RaycastHit _hit;
	private CharacterController _character;


	// Use this for initialization
	void Start () {
		_line = GetComponent<LineRenderer>();
		_line.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1")) {

			_line.enabled=true;
		}

		if (Input.GetButton("Fire1")){

			_ray = new Ray (transform.position, transform.forward);
			
			if (Physics.Raycast(_ray, out _hit, rayLength )) {

				_line.SetPosition (1, transform.InverseTransformPoint(_hit.point));

				if (_hit.collider.tag=="Hold") {

					_hit.collider.GetComponent<ColorChange>().Activate();
					hookPoint = _hit.point;
					canTransport=true;
				}
			}
			
			else {

				_line.SetPosition (1, Vector3.forward*rayLength);
				canTransport = false;
			}
		
		}

		if (Input.GetButtonUp ("Fire1")) {

			_line.enabled = false;
			canTransport = false;
			ActivateColor(false);
		}

	}

	public void ActivateColor(bool activating) {
		if (activating) {
			_line.SetColors(activeColor1, activeColor2);
		}
		
		else {
			_line.SetColors (inactiveColor1, inactiveColor2);
		}
	}


}
