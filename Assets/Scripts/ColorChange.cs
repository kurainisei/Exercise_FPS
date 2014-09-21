using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {
	public Color standardColor;
	public Color activatedColor;
	public float smooth;

	private Color _currentColor;
	// Use this for initialization
	void Start () {
		_currentColor=standardColor;
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.color =  Color.Lerp(renderer.material.color, _currentColor, smooth * Time.deltaTime);
	}

	public void Activate () {

		_currentColor = activatedColor;
		StartCoroutine(StayActive());
	}


	IEnumerator StayActive()
	{
		for (float i=1f; i>0; i-=Time.deltaTime)
		{
			yield return null;
		}

		_currentColor=standardColor;
	}
}
