using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using System.Text;
using System.Security.Cryptography;

[ExecuteInEditMode]
public class DataSave : MonoBehaviour
{

    public AutoCreateMoon autoMoon;

    public MoonManager moonmanager;

    private string FilePath;


    public class SaveData
    {

        public List<string> saveMoonValue;
        public List<int> saveBuyItem;

        public string saveTime;
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

    void OnDestroy()
    {

    }

    void Update()
    {

    }

    public void Save()
    {
        SaveData save = new SaveData();

        save.saveMoonValue = new List<string>();
        foreach (ulong val in moonmanager.GetMoon())
        {
            save.saveMoonValue.Add(val.ToString());
        }

        save.saveBuyItem = new List<int>();
        foreach (var item in moonmanager.GetItem())
        {
            save.saveBuyItem.Add(item);
        }

        save.saveTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

        string json = JsonUtility.ToJson(save);

        byte[] bytes = Encoding.UTF8.GetBytes(json);
        byte[] aes = AesEncrypt(bytes);

        FileStream fStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write);

        try
        {
            // ファイルに保存
            fStream.Write(aes, 0, aes.Length);

        }
        finally
        {
            // ファイルを閉じる
            if (fStream != null)
            {
                fStream.Close();
            }
        }


    }

    public void Load()
    {
        //セーブデータクラスのインスタンス生成
        SaveData save = new SaveData();

        if (!File.Exists(FilePath))
        {
            return;
        }
        //ファイルモードをオープンにする
        FileStream fStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
        try
        {
            // ファイル読み込み
            byte[] bytes = File.ReadAllBytes(FilePath);

            // 復号化
            byte[] arrDecrypt = AesDecrypt(bytes);

            // byte配列を文字列に変換
            string decryptStr = Encoding.UTF8.GetString(arrDecrypt);

            // JSON形式の文字列をセーブデータのクラスに変換
            save = JsonUtility.FromJson<SaveData>(decryptStr);

            //セーブデータ内のムーン所持数を反映
            short count = 0;
            foreach (string val in save.saveMoonValue)
            {
                moonmanager.AddMoon(count, ulong.Parse(val));
                count++;
            }

            //セーブデータ内のアイテム購入数を反映
            count = 0;
            foreach (int item in save.saveBuyItem)
            {
                moonmanager.AddItem(count, item);

                int addValue = moonmanager.ItemValueText[count].GetComponentInParent<GetItem>().AddMoon * item;
                autoMoon.AddValue(addValue);

                count++;
            }
            moonmanager.UpdateItemText();


            //前回の終了時間から現在時間までのムーン自動生成
            DateTime loadTime = DateTime.Parse(save.saveTime);
            TimeSpan timeSpan = DateTime.Now.Subtract(loadTime);
            ulong totalSeconds = (ulong)timeSpan.TotalSeconds;

            for (ulong i = 0; i < totalSeconds * (uint)autoMoon.Add_Value; i++)
            {
                int RareID = UnityEngine.Random.Range(0, moonmanager.GetMoon().Length);
                moonmanager.AddMoon(RareID, 1);

            }

        }
        finally
        {
            // ファイルを閉じる
            if (fStream != null)
            {
                fStream.Close();
            }
        }

        moonmanager.UpdateMoonText();

    }

    private AesManaged GetAesManager()
    {
        //暗号キー
        string aesIv = "1234567890123456";
        string aesKey = "1234567890123456";

        AesManaged aes = new AesManaged();
        aes.KeySize = 128;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.IV = Encoding.UTF8.GetBytes(aesIv);
        aes.Key = Encoding.UTF8.GetBytes(aesKey);
        aes.Padding = PaddingMode.PKCS7;
        return aes;
    }

    // AES暗号化
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AESマネージャーの取得
        AesManaged aes = GetAesManager();
        // 暗号化
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

    // AES複合化
    public byte[] AesDecrypt(byte[] byteText)
    {
        // AESマネージャー取得
        AesManaged aes = GetAesManager();
        // 復号化
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

}
