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
 * Esta clase genera los objetos de juego (como cartas, tokens y demas) que fueron leidos por CollectionGenerator desde algun formato de texto
 * Hereda de MonoBehaviour porque necesita interactuar directamente con unity para instanciar los prefabs, carga primero las texturas con 
 */
public class GameObjectGenerator : MonoBehaviour{

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

	void Start(){
		SpawnObjects ();
	}
	
	//Creo los items que necesito en la mesa
	public void SpawnObjects(){

		float xCoord = -8f;
		foreach (IGenericGameElement gge in GameEnviroment.gges) {
			//Debug
			gge.printAtt();
			Debug.Log (ggeToSpawn);	

			//Genero una instancia del prefab segun su tipo, Resource.Load se fija en la carpeta Resource si hay un elemento del tipo gge.GetType().ToString()
			clone = Instantiate(Resources.Load("Prefab/"+gge.GetType().ToString()), new Vector3(xCoord,0,0), Quaternion.identity) as GameObject;
			clone.transform.Rotate(new Vector3(90,0,0));

			//Movimiento de coordenadas x para que los objetos no aparezcan todos en el mismo lugar, esto se cambiara posteriormente
			xCoord+=1.2f;
			SetObjectScript(gge);
		}
	}

	//Cada prefab tendra asociado un script con su objeto especifico
	public void SetObjectScript(IGenericGameElement gge ){

		switch(gge.GetType().ToString()){
		case "Card":
			Card card = (Card)gge;
			TextureLoad(card.FrontImage);
			//Asigno el sprite "back" al prefab (nota que si el obj, no tiene un "SpriteRenderer" esto devuelve null

			this.clone.GetComponent<SpriteRenderer>().sprite = spriteFF;
			this.clone.GetComponent<CardScript>().card = card;
			break;

		case "Token":
			Token token = (Token)gge;
			//Asigno el sprite "back" al prefab (nota que si el obj, no tiene un "SpriteRenderer" esto devuelve null
			this.clone.GetComponent<TokenScript>().token = token;
			break;

		default:
			break;
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
		return path;
	}
}
