using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetItem : MonoBehaviour {
	const int _nocturne = 0;
	const int _gariard = 1;
	const int _oberec = 2;

	public GameObject AutoCreatePrefab;

	public uint Price_Noc;
	public uint Price_Gal;
	public uint Price_Obe;

	public Text PriceText_Noc;
	public Text PriceText_Gal;
	public Text PriceText_Obe;

	public Text Item_Text;

	public int AddMoon;

	public MoonManager moonManager;

	private int Value;//買ってる個数

	private bool BuyFlg;//買えるかフラグ

	private int itemID;//自分が何番目の配列に入っているか
	// Use this for initialization
	void Start () {
		int count = 0;
		foreach(Text item in moonManager.ItemValueText)
        {
			if(item.Equals(this.GetComponentInChildren<Text>()))
            {
				itemID = count;
				Debug.Log(string.Format("Hit! name={0} value={1}",item.name,count));
				break;
            }
			count++;
        }
	}

	// Update is called once per frame
	void Update () {
		
		if (Price_Noc > moonManager.GetMoon(_nocturne)) 
		{
			this.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
			BuyFlg = false;
			this.GetComponent<Button>().enabled=false;
			return;

		}
		if (Price_Gal > moonManager.GetMoon(_gariard)) 
		{
			this.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
			BuyFlg = false;
			this.GetComponent<Button>().enabled=false;
			return;
		}
		if (Price_Obe > moonManager.GetMoon(_oberec))
		{
			this.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
			this.GetComponent<Button>().enabled=false;
			BuyFlg = false;
			return;
		}

		this.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		this.GetComponent<Button>().enabled=true;
		BuyFlg = true;

	}

	public void onClick()
	{
		AutoCreatePrefab.GetComponent<AutoCreateMoon> ().AddValue (AddMoon);
		//ノクターンを必要分売り、価格を2倍にする
		moonManager.SubMoon(_nocturne, Price_Noc);
		Price_Noc *= 2;

		//ガリア―ドを必要分売り、価格を2倍にする
		moonManager.SubMoon(_gariard, Price_Gal);
		Price_Gal *= 2;

		//オベレクを必要分売り、価格を2倍にする
		moonManager.SubMoon(_oberec, Price_Obe);
		Price_Obe *= 2;

		//所持アイテム数を増加
		moonManager.AddItem(itemID, 1);

		//値段のテキストを更新
		UpdatePriceText();

		//所持ムーンと所持アイテムのテキストを更新
		moonManager.UpdateItemText();
		moonManager.UpdateMoonText();
	}

	public void UpdatePriceText()
    {
		PriceText_Noc.text = Price_Noc.ToString();
		PriceText_Gal.text = Price_Gal.ToString();
		PriceText_Obe.text = Price_Obe.ToString();
	}

}
	

