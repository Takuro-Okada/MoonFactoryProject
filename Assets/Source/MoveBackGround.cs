using UnityEngine;
using System.Collections;

public class MoveBackGround : MonoBehaviour {
	public GameObject BackGround_Right;

	public Sprite BackGround_Standard;
	public Sprite BackGround_Orange;
	public Sprite BackGround_Night;

	private SpriteRenderer MainSprite;
	private SpriteRenderer RightSprite;
	// Use this for initialization
	void Start () {
		string HourTime;
		HourTime = System.DateTime.Now.Hour.ToString ();
		MainSprite = gameObject.GetComponent<SpriteRenderer>();
		RightSprite = BackGround_Right.GetComponent<SpriteRenderer> ();
		if (int.Parse(HourTime) >= 6 && int.Parse(HourTime) <= 14) 
		{
			MainSprite.sprite = BackGround_Standard;
			RightSprite.sprite = BackGround_Standard;
		}
		if (int.Parse(HourTime) >= 15 && int.Parse(HourTime) <= 18)
		{
			MainSprite.sprite = BackGround_Orange;
			RightSprite.sprite = BackGround_Orange;
		}
		if ((int.Parse(HourTime) >= 19 && int.Parse(HourTime) <= 23)||(int.Parse(HourTime) >= 0 && int.Parse(HourTime) <= 5))
		{
			MainSprite.sprite = BackGround_Night;
			RightSprite.sprite = BackGround_Night;
		}
	}
	


	void Update ()
	{
		//今映っている前の背景を動かす
		Vector2 vec = transform.position;
		vec.x -= 0.1f;
		transform.position = vec;

		if (transform.position.x <= -2000) 
		{
			vec.x = 946;
			transform.position = vec;
		}

		//左にある後ろの背景を動かす
		vec = BackGround_Right.transform.position;
		vec.x -= 0.1f;
		BackGround_Right.transform.position = vec;

		if (BackGround_Right.transform.position.x <= -2000) 
		{
			vec.x = 946;
			BackGround_Right.transform.position = vec;
		}





	}
}
