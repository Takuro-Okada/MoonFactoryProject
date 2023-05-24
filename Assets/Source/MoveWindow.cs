using UnityEngine;
using System.Collections;

public class MoveWindow : MonoBehaviour {
	private bool SlideFlg;
	private Vector2 DefPos;

	public void OnSlide()
	{
		SlideFlg = !SlideFlg;
	}

	// Use this for initialization
	void Start () {
		SlideFlg = false;
		DefPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 vec = transform.position;
		if (SlideFlg == true) 
		{
			if (DefPos.x - transform.position.x < 400.0f) 
			{
				vec.x -= 10;
				transform.position = vec;
			}
		}
		if (SlideFlg == false) 
		{
			if (DefPos.x - transform.position.x > 0) 
			{
				vec.x += 10;
				transform.position = vec;
			}
		}
	}


}
