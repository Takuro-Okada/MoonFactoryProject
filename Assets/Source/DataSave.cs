using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

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

		public string saveTime;
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

		save.saveTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

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
		//セーブデータクラスのインスタンス生成
		SaveData save = new SaveData();

		//セーブデータの読み込み
		StreamReader stream = new StreamReader(FilePath);
		string data = stream.ReadToEnd();
		stream.Close();
		
		//セーブデータクラスに読み込んだ情報を代入
		save = JsonUtility.FromJson<SaveData>(data);

		//セーブデータ内のムーン所持数を反映
		short count = 0;
		foreach(string val in save.saveMoonValue)
        {
			SaveMoonValue[count].text = val;

			count++;
        }

		//セーブデータ内のアイテム購入数を反映
		count = 0;
		foreach(string item in save.saveBuyItem)
        {
			SaveBuyItem[count].GetComponent<Text>().text = item;

			int addValue = SaveBuyItem[count].GetComponentInParent<GetItem>().AddMoon * int.Parse(item);

			autoMoon.AddValue(addValue);

			count++;
        }

		//前回の終了時間から現在時間までのムーン自動生成
		DateTime loadTime = DateTime.Parse(save.saveTime);
		TimeSpan timeSpan = DateTime.Now.Subtract(loadTime);
		ulong totalSeconds = (ulong)timeSpan.TotalSeconds;

		for (ulong i = 0; i < totalSeconds * (uint)autoMoon.Add_Value; i++)
		{
			int RareID = UnityEngine.Random.Range(0, SaveMoonValue.Length);
			ulong moonVal = ulong.Parse(SaveMoonValue[RareID].text);
			moonVal++;
			SaveMoonValue[RareID].text = moonVal.ToString();

		}


	}
}
