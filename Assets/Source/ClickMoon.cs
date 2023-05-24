using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class ClickMoon : MonoBehaviour {
	public GameObject MoonPrefab;

	public bool ClickFlg=false;

	// Use this for initialization
	void Start () {
	
	}

	public void OnClickFlg()
	{
		ClickFlg = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (ClickFlg == true) {
			if (Input.GetMouseButtonDown (0)) {
				MoonPrefab.GetComponent<SpawnMoon> ().Create ();
			}

			if (Input.GetMouseButtonUp (0)) {
				ClickFlg = false;
			}

		}
	}
		

}