using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {


	//Tienen que ser transform para poder representarlos en el canvas
	public Transform card ;
	public Transform clone;
	public Sprite backSprite;
	public WWW www;
	public string url;

	void Awake(){
		//Cargo la textura desde los assets, nota que si no existe la carpeta Resources esto devuelve null
		/*Debug.Log("antes de textureLoad");
		textureLoad ();
		Debug.Log("Despues de textureLoad");*/

	}

	void Start()
	{
		//En algunos casos (depende de que se cree) el objeto aparece fuera del canvas y por ende no se muestra, seteandole el parent "vuelve" al canvas
		//clone.parent = gameObject.transform;



		//Genero una instancia del prefab Card
		clone = Instantiate(card, new Vector3(500,200,0), Quaternion.identity) as Transform;
		textureLoad ();
		Debug.Log("Prefab/Carta creada");
		//Asigno el sprite "back" al prefab (nota que si el obj, no tiene un "SpriteRenderer" esto devuelve null
		clone.GetComponent<SpriteRenderer>().sprite = backSprite;
	}

	void textureLoad(){
		Debug.Log ("antes url");
		//url = Application.persistentDataPath +"/loveLetter/images/back.png" ;
		url = "file:///c://Users/Emiliano/AppData/LocalLow/DefaultCompany/2013_10 _ Sample Assets/loveLetter/images/back.png";	
		Debug.Log ("despues url");
		Debug.Log (url);
		//waitForAsset (url);

		www = new WWW(url);
		Debug.Log (www);
		if(www.isDone)

		Debug.Log ("cargue el Asset");

		SpriteRenderer renderer = clone.GetComponent<SpriteRenderer> ();
		Debug.Log (renderer);
		Debug.Log (www);
		backSprite = Sprite.Create (www.texture, new Rect (0, 0, 200, 304), new Vector2 (0.5f, 0.5f), 100.0f);

		renderer.sprite = backSprite;
	}

	/*public IEnumerator waitForAsset(string url){

			return www;
	}*/
	
	// Update is called once per frame
	void Update () {

	}
}
