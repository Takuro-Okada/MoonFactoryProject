using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnMoon : MonoBehaviour {
	public GameObject MoonPrefab;
	public Sprite[] MoonSprites;
	public MoonManager moonmanager;

	public void Create()
	{
		Vector2 pos = new Vector2(-938.0f, 110.0f);
		GameObject ball = Instantiate(MoonPrefab, pos, Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;
		ball.transform.localScale *= Random.Range (10.0f, 25.0f);
		ball.layer = 1;
		int RareId = Random.Range(0, 1000);
		ball.name = "Moon" + RareId;
		SpriteRenderer spriteObj = ball.GetComponent<SpriteRenderer>();
		int spriteId = 0;
		if (RareId >= 0 && RareId <= 332) 
		{
			spriteId = 0;
		}
		if (RareId >= 333 && RareId <= 665) 
		{
			spriteId = 1;
		}
		if (RareId >= 666 && RareId <= 998) 
		{
			spriteId = 2;
		}
		if (RareId == 999) 
		{
			spriteId = 3;
		}

		spriteObj.sprite = MoonSprites[spriteId];

		switch(spriteId){
		case 0:
			AddPoint (1,0);
			break;
		case 1:
			AddPoint (1,1);
			break;
		case 2:
			AddPoint (1,2);
			break;
		}

	}


	public void AddPoint (int point,int ID)
	{
		moonmanager.AddMoon(ID, (uint)point);
		moonmanager.SetMoonText();
	}
}
