using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	public GameObject loadingImage;

	public void LoadScene(int menu)
	{
		Debug.Log ("Ok");
		loadingImage.SetActive (true);
		Application.LoadLevel (menu);
	}

	public void LoadGame(){
		GameEnviroment ge = new GameEnviroment ();
		ge.read();
	}

	public void Exit(){
		Debug.Log ("Chau");
		Application.Quit();
	}
}
