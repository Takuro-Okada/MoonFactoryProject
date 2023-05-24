using UnityEngine;
using System.Collections;

public class MoveMoon : MonoBehaviour {

	public float addx;
	public float addy;

	// Use this for initialization
	void Start () {
		addx = Random.Range (-10.0f, 10.0f);
		addy= Random.Range(2.0f,10.0f);
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 vec = transform.position;
		vec.x += addx;
		vec.y += addy;
		transform.position = vec;

		addy -= 0.1f;

		if (!GetComponent<Renderer>().isVisible) 
		{
			Destroy (this.gameObject);
		}
	}
}
