using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class ClickMoon : MonoBehaviour {
	public GameObject MoonPrefab;

	public bool ClickFlg=false;

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	
	}

	public void OnClickFlg()
	{

		audioSource.Play();
		ClickFlg = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (ClickFlg == true) {
				MoonPrefab.GetComponent<SpawnMoon> ().Create ();
				ClickFlg = false;

		}
	}
		

}