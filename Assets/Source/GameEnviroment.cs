using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System;
using System.Xml.Serialization;
using UnityEngine.UI;
/*
 * Esta clase genera los objetos de juego (como cartas, tokens y demas) que fueron leidos por GameEnviroment
Se podria cargar desde Load marcando a los objetos como Object.DontDestroyonLoad, pero cree otra clase para 
que el codigo fuese mas limpio y load solo sirva para operaciones menos triviales, como moverse entre scenes
 */
public class GameEnviroment : MonoBehaviour{

	FileStream file;
	string xmlCore;
	string ggeName;
	int ggeQuantity;
	string gameName;
	string generalPath = Load.path;

	//Atributos de spawneo
	//Tienen que ser transform para poder representarlos en el canvas
	//Card es el prefab, clone son los creados desde el prefab, SpriteFF = spriteFromFile (desde una imagen), www se usa para "descargar" la imagen con url.
	public GameObject ggeToSpawn ;
	public GameObject clone;
	public Sprite spriteFF;
	public Text debugT;

	//=============================
	//Metodos
	//=============================
	void Update(){
		//debugT.text = Application.persistentDataPath;
	}
	void Start(){
		SpawnObjects ();
		Debug.Log ("TERMINE");
	}
	
	//Creo los items que necesito en la mesa
	public void SpawnObjects(){
		//En algunos casos (depende de que se cree) el objeto aparece fuera del canvas y por ende no se muestra, seteandole el parent "vuelve" al canvas
		//clone.parent = gameObject.transform;
		int xCoord = -8;
		foreach (GenericGameElement gge in GameObjectGenerator.gges) {

			gge.printAtt();
			//Genero una instancia del prefab Card
			Debug.Log (ggeToSpawn);
			clone = Instantiate(ggeToSpawn, new Vector3(xCoord,0,0), Quaternion.identity) as GameObject;
			xCoord+=1;
			TextureLoad (gge.FrontImage);
			Debug.Log("Prefab/Carta creada");
			//Asigno el sprite "back" al prefab (nota que si el obj, no tiene un "SpriteRenderer" esto devuelve null
			this.clone.GetComponent<SpriteRenderer>().sprite = spriteFF;
		}
	}

	//Carga la textura desde la imagen
	public void TextureLoad(string frontImage){
		WWW www;
		string url;
		//Tomo el path para www y www lo "descarga" desde el disco para convertir la imagen en textura
		url= GetPath(frontImage);
		www = new WWW(url);
		//Termine de descargar ?
		if (www.isDone) {}
		//Puntero al renderer del objeto creado (carta o lo que sea)
		SpriteRenderer renderer = clone.GetComponent<SpriteRenderer> ();
		//Creo el sprite con la imagen especifica
		spriteFF = Sprite.Create (www.texture, new Rect (0, 0, 300, 419), new Vector2 (0.5f, 0.5f), 100.0f);
		//Asigno al SpriteRenderer de clone el nuevo sprite creado
		renderer.sprite = spriteFF;
	}

	//Devuelve el path del archivo independiente del OS, falta testear bien todavia
	string GetPath(string frontImage)
	{
		string path;
		string partialPath = this.generalPath;
		//partialPath = Application.persistentDataPath;
		Debug.Log(this.generalPath);
		
		#if UNITY_EDITOR
		partialPath = partialPath.Replace("c:/","C://");
		partialPath = partialPath.Replace("C:/","C://");
		path = "file:///" + partialPath + "images/"+frontImage;
		Debug.Log(path);
		#elif UNITY_ANDROID
		path = "jar:file://"+ partialPath + "!images/"+frontImage;
		#elif UNITY_IOS
		path = "file:" + partialPath + "images/"+frontImage;
		#else
		//Desktop (Mac OS or Windows)
		partialPath = partialPath.Replace("c:/","C://");
		partialPath = partialPath.Replace("C:/","C://");
		path = "file:///"+ partialPath + "images/"+frontImage;
		#endif
		debugT.text = path;
		return path;
	}
}
