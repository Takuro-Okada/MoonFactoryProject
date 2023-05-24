using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Title_OnClick : MonoBehaviour {
	public GameObject Font_Moon;
	public GameObject Font_Factory;
	public GameObject RotMoon;
	public Text ClickStart;
	public GameObject FadeSprite;
	private bool OneClickFlg=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
			if (ClickStart.GetComponent<FlashingFont> ().UpdateFlg == false) 
			{
				Font_Moon.GetComponent<EmergeFont> ().SetPositionY(3.653492f);
				Font_Moon.GetComponent<EmergeFont> ().UpdateFlg=false;
				Font_Factory.GetComponent<EmergeFont> ().SetPositionY(1.199999f);
				Font_Factory.GetComponent<EmergeFont> ().UpdateFlg=false;
				RotMoon.GetComponent<RotateMoon> ().EnddelayFlg = true;
				ClickStart.GetComponent<FlashingFont> ().UpdateFlg = true;
				OneClickFlg = true;
				return;
			}

			if (ClickStart.GetComponent<FlashingFont> ().UpdateFlg == true) 
			{
				ClickStart.GetComponent<FlashingFont> ().VisibleFlg = true;

				FadeSprite.GetComponent<FadeScript> ().FadeInFlg = true;
			}

		}

		//セーブデータ削除処理
		if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightShift)) 
		{
			PlayerPrefs.DeleteAll ();
		}

	}
}
