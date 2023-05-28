using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DataSave : MonoBehaviour {

	public Text[] SaveMoonValue;

	public GameObject[] SaveBuyItem;

	public AutoCreateMoon autoMoon;

	private bool started = false;
	private string key;

	private string FilePath;


	public class SaveData
	{

		public List<string> saveMoonValue;
		public List<string> saveBuyItem;

	}

	void Start()
    {
		FilePath = Application.dataPath + "/" + "SaveData.json";

		if (!File.Exists(FilePath))
		{
			File.Create(FilePath);
			return;
		}

		Load();


	}

	void OnDestroy(){
		
		if (started) {
			Save();
		}
	}

	void Update(){
		started = Application.isPlaying;

	}

	void Save()
    {
		SaveData save = new SaveData();

		save.saveMoonValue = new List<string>();
		foreach (Text val in SaveMoonValue)
        {
			Debug.Log(val.text);
			save.saveMoonValue.Add(val.text);
        }

		save.saveBuyItem = new List<string>();
		foreach (var item in SaveBuyItem)
        {
			save.saveBuyItem.Add(item.GetComponent<Text>().text);
        }

		string json = JsonUtility.ToJson(save);
		StreamWriter stream = new StreamWriter(FilePath);
		stream.Write(json); stream.Flush();
		stream.Close();
	}

	void InitialzeSave()
    {
		SaveData save = new SaveData();

		string json = JsonUtility.ToJson(save);
		StreamWriter stream = new StreamWriter(FilePath);
		stream.Write(json); stream.Flush();
		stream.Close();
	}

	void Load()
    {
		SaveData save = new SaveData();

		StreamReader stream = new StreamReader(FilePath);
		string data = stream.ReadToEnd();
		stream.Close();
		
		save = JsonUtility.FromJson<SaveData>(data);

		short count = 0;
		foreach(string val in save.saveMoonValue)
        {
			SaveMoonValue[count].text = val;

			count++;
        }

		count = 0;

		foreach(string item in save.saveBuyItem)
        {
			SaveBuyItem[count].GetComponent<Text>().text = item;

			int addValue = SaveBuyItem[count].GetComponentInParent<GetItem>().AddMoon * int.Parse(item);
			Debug.Log(addValue);

			autoMoon.AddValue(addValue);

			count++;
        }

	}
}
