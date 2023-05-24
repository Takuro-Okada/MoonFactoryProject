using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour {

	private Image FadeImage;
	public Scene ChangeScene;
	public bool FadeInFlg;
	public bool FadeOutFlg;

	void Start(){
		FadeImage = this.GetComponent<Image> ();
	}

	void Update(){
		var col = FadeImage.color;
		if (FadeOutFlg) 
		{
			FadeOut();
		}
		if (FadeInFlg) 
		{
			FadeIn();
		}
	}


	public void FadeIn()
	{

		var col = FadeImage.color;
	
			
		col.a +=0.05f;
			
		if(col.a >= 1.0f) 

		{
			SceneManager.LoadScene ("Scene");
		}
			
		FadeImage.color = col;

	}

	public void FadeOut()
	{
		var col = FadeImage.color;

		col.a -= 0.05f;
		if (col.a <= 0.0f) 
		{
			Destroy (this.gameObject);
		}


		FadeImage.color = col;

	}
}
