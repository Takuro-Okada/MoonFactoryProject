using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class AutoCreateMoon : MonoBehaviour {
	public GameObject CreateMoonPrefab;
	public Text SecondsValue;
	private int Add_Value;
	private float TimeEnable;
	// Use this for initialization
	void Start () {
		TimeEnable = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Add_Value <= 0) 
		{
			return;
		}

		TimeEnable += Time.deltaTime;
		if(TimeEnable>=1.0f)
        {
			for (int i = 0; i < Add_Value; i++)
			{
				CreateMoonPrefab.GetComponent<SpawnMoon>().Create();
			}
			TimeEnable = 0.0f;
		}

		//フレーム間にAdd_Value分処理を行う処理
		//個数が150を超えた辺りでAdd_Valueの分生成されなくなってしまうので封印
		/*
		if (TimeEnable >= 1.0f/Add_Value) 
		{
			CreateMoonPrefab.GetComponent<SpawnMoon> ().Create ();
			TimeEnable = 0.0f;
		}
		*/
	
	}

	public void AddValue(int value)
	{
		Add_Value += value;
		SecondsValue.text = "毎秒 : " + Add_Value.ToString () + "個";
	}

}
