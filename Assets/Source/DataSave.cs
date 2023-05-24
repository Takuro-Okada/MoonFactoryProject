using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

[ExecuteInEditMode]
public class DataSave : MonoBehaviour {

	public Text Value_Noc;
	public Text Value_Gal;
	public Text Value_Obe;
	public Text Value_Faily;
	public Text Value_Behimos;
	public Text Value_Dragon;
	public Text Value_AutoMachine;
	public Text Value_Crystal;

	private bool started = false;
	private string key;

	private string FilePath;


	public class SaveData
	{

		public string Stoc_Noc;
		public string Stoc_Gal;
		public string Stoc_Obe;
		public string Buy_Faily;
		public string Buy_Behimos;
		public string Buy_Dragon;
		public string Buy_AutoMachine;
		public string Buy_Crystal;

	}

	void Start()
    {
		FilePath = Application.dataPath + "/" + "SaveData.json";

		if (!File.Exists(FilePath))
		{
			File.Create(FilePath);
			Save();
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

		save.Stoc_Noc = Value_Noc.text;
		save.Stoc_Gal = Value_Gal.text;
		save.Stoc_Obe = Value_Obe.text;

		save.Buy_Faily = Value_Faily.text;
		save.Buy_Behimos = Value_Behimos.text;
		save.Buy_Dragon = Value_Dragon.text;
		save.Buy_AutoMachine = Value_AutoMachine.text;
		save.Buy_Crystal = Value_Crystal.text;


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
		Value_Noc.text = save.Stoc_Noc;
		Value_Gal.text = save.Stoc_Gal;
		Value_Obe.text = save.Stoc_Obe;

		Value_Faily.text = save.Buy_Faily;
		Value_Behimos.text = save.Buy_Behimos;
		Value_Dragon.text = save.Buy_Dragon;
		Value_AutoMachine.text = save.Buy_AutoMachine;
		Value_Crystal.text = save.Buy_Crystal;

		Debug.Log(Value_Noc);
	}
}
