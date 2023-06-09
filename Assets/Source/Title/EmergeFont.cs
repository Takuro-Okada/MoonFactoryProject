using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmergeFont : MonoBehaviour {
	public bool UpdateFlg=true;
	private float fadeTime=2.5f;
	private float RemainTime=0.0f;
	public float delayTime;
	private bool EnddelayFlg = false;
	private SpriteRenderer spRenderer;

	// Use this for initialization
	void Start () {
		Vector3 vec = transform.position;
		vec.y -= 1.0f;
		transform.position = vec;
		spRenderer = GetComponent<SpriteRenderer>();
		var color = spRenderer.color;
		color.a = 0.0f;
		spRenderer.color = color;	
	}
	
	// Update is called once per frame
	void Update () {
		if (UpdateFlg == false) 
		{
			EnddelayFlg = true;
			RemainTime = fadeTime + 1.0f;
			var color = spRenderer.color;
			color.a = 1.0f;
			spRenderer.color = color;	
			UpdateFlg = true;
		}


		if (EnddelayFlg == true) 
		{
			if (RemainTime >= fadeTime ) {
				return;
			}

			// 残り時間を更新
			RemainTime += Time.deltaTime;

			// フェードイン
			float alpha = RemainTime / fadeTime;
			var color = spRenderer.color;
			color.a = alpha;
			spRenderer.color = color;
			/*Vector3 vec = transform.position;
			vec.y += 0.01f;
			transform.position = vec;*/

		}
		if (EnddelayFlg == false) 
		{
			// 残り時間を更新
			RemainTime += Time.deltaTime;
			if (RemainTime >= delayTime) 
			{
				EnddelayFlg = true;
				RemainTime = 0.0f;
			}
		}


	}

	public void SetPositionY(float _y)
	{
		Vector3 vec;
		vec = transform.position;
		vec.y = _y;
		transform.position = vec;
	}
}
