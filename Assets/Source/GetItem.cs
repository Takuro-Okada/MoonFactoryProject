using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetItem : MonoBehaviour {
	public GameObject AutoCreatePrefab;

	public int Price_Noc;
	public int Price_Gal;
	public int Price_Obe;

	public Text PriceText_Noc;
	public Text PriceText_Gal;
	public Text PriceText_Obe;

	public Text Score_Noc;
	public Text Score_Gal;
	public Text Score_Obe;

	public Text Item_Text;

	public int AddMoon;

	private int Value;//買ってる個数

	private bool BuyFlg;//買えるかフラグ
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		if (Price_Noc > int.Parse(Score_Noc.text)) 
		{
			this.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
			BuyFlg = false;
			this.GetComponent<Button>().enabled=false;
			return;

		}
		if (Price_Gal > int.Parse(Score_Gal.text)) 
		{
			this.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
			BuyFlg = false;
			this.GetComponent<Button>().enabled=false;
			return;
		}
		if (Price_Obe > int.Parse(Score_Obe.text))
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
		int ScoreSub = int.Parse (Score_Noc.text);
		ScoreSub -= Price_Noc;
		Score_Noc.text = ScoreSub.ToString();
		Price_Noc *= 2;
		PriceText_Noc.text = Price_Noc.ToString();

		//ガリア―ドを必要分売り、価格を2倍にする
		ScoreSub = int.Parse (Score_Gal.text);
		ScoreSub -= Price_Gal;
		Score_Gal.text = ScoreSub.ToString();
		Price_Gal *= 2;
		PriceText_Gal.text = Price_Gal.ToString();

		//オベレクを必要分売り、価格を2倍にする
		ScoreSub = int.Parse (Score_Obe.text);
		ScoreSub -= Price_Obe;
		Score_Obe.text = ScoreSub.ToString();
		Price_Obe *= 2;
		PriceText_Obe.text = Price_Obe.ToString();

		int TextTmp = int.Parse (Item_Text.text);
		if (Item_Text.text == string.Empty) TextTmp = 0;
		TextTmp += 1;
		Item_Text.text = TextTmp.ToString ();
	}


}
	

