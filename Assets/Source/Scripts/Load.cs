using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	public static string path;

	//Cuando queremos cambiar de scene
	public void Scene(int menu)
	{
		Application.LoadLevel (menu);
	}

	public void Game(string path){
		//Terminamos de cargar los objetos nos vamos a la scene de juego
		//Creo un GameObjectGenerator que se encargara de revisar los XML, crear los objetos necesarios y popular el singleton GameObjectCollection
		GameObjectGenerator gog = new GameObjectGenerator();
		Load.path = path;
		gog.ReadCoreXML (path);

		//Terminamos de cargar los objetos nos vamos a la scene de juego
		this.Scene (2);

	}

	//Esto se ejecuta cuando hacemos click en "Load"
	public void FileBrowser(){
		//Llamo a un fileBrowser que por ahora no existe entonces lo harcodeo y me devuelve un path
		string path = Application.persistentDataPath + "/loveLetter/";
		this.Game (path);
	}

	//Cuando hacemos click en "Exit"
	public void Exit(){
		Application.Quit();
	}
}
