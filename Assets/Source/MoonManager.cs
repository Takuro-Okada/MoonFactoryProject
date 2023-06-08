using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonManager : MonoBehaviour {

	public const int useMoonValue = 3;

	public Text[] MoonText = new Text[useMoonValue];

	public const int useItemValue = 6;

	public Text[] ItemValueText = new Text[useItemValue];

	public DataSave dataSave;

	private ulong[] useMoon = new ulong[useMoonValue];


	private int[] useItem = new int[useItemValue];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
    {
		dataSave.Save();
    }



	//==============
	//ムーン関連
	//==============
	public void UpdateMoonText()
	{
		for (int i = 0; i < useMoonValue; i++)
		{
			MoonText[i].text = useMoon[i].ToString();
		}
	}

	public ulong GetMoon(int id)
    {
		return useMoon[id];
    }

	public ulong[] GetMoon()
	{
		return useMoon;
	}

	public void AddMoon(int id,uint add)
    {
		useMoon[id] += add;
    }

	public void AddMoon(int id, ulong add)
	{
		useMoon[id] += add;
	}

	public void SubMoon(int id, uint sub)
	{
		
        if (useMoon[id]-sub< 0)
        {
			useMoon[id] = 0;
        }
        else
        {
			useMoon[id] -= sub;

		}

	}


	//=============
	//アイテム関連
	//=============

	public void UpdateItemText()
    {
		for(int i=0;i<useItemValue;i++)
        {
			ItemValueText[i].text = useItem[i].ToString();
        }
    }

	public void AddItem(int id,int add)
    {
		useItem[id] += add;
    }

	public void SubItem(int id,int sub)
    {
		useItem[id] -= sub;
    }

	public int[] GetItem()
	{
		return useItem;
	}

}
