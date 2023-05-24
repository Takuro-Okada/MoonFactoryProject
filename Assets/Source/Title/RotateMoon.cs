using UnityEngine;
using System.Collections;

public class RotateMoon : MonoBehaviour {
	public float RotCnt;
	public float delaytime;
	private float Remaintime = 0;
	public bool EnddelayFlg=false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (EnddelayFlg == true) 
		{
			transform.Rotate (new Vector3 (0, 0,RotCnt));
		}
		if (EnddelayFlg == false) 
		{
			Remaintime += Time.deltaTime;
			if (Remaintime >= delaytime)
			{
				EnddelayFlg = true;
			}
		}

	}
}
