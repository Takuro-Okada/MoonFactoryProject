using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonManager : MonoBehaviour {

	public const int useValue = 3;

	public Text[] MoonText = new Text[useValue];

	public DataSave dataSave;

	private ulong[] useMoon = new ulong[useValue];


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

	public void SetMoonText()
    {
		for(int i=0;i<useValue;i++)
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
}
