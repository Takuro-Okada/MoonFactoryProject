using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class FlashingFont : MonoBehaviour {
	public bool UpdateFlg;
	public float FlashingTime;
	private float RemainTime;
	private Text FlashingText;
	public bool VisibleFlg;

	public float delaytime;
	private float Remaintime = 0;
	public bool EnddelayFlg=false;

	// Use this for initialization
	void Start () {
		UpdateFlg = false;
		RemainTime = 0.0f;
		VisibleFlg = true;
		FlashingText = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (EnddelayFlg == false) 
		{
			Remaintime += Time.deltaTime;
			if (Remaintime >= delaytime)
			{
				EnddelayFlg = true;
				UpdateFlg = true;
			}
		}

		if (UpdateFlg == false)
			return;


		RemainTime += Time.deltaTime;

		if (RemainTime >= FlashingTime) 
		{
			VisibleFlg = !VisibleFlg;
			RemainTime = 0;
		}

		var color = FlashingText.color;
		if (VisibleFlg == true) {
			color.a = 0.0f;
		} else {
			color.a = 1.0f;
		}
		FlashingText.color = color;

	}
}
