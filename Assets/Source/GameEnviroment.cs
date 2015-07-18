using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System;
using System.Xml.Serialization;

public class GameEnviroment {

	List <GenericGameElement> gges = new List<GenericGameElement>();
	FileStream file;
	string xmlCore;
	string ggeName;
	int ggeQuantity;
	string path = Application.persistentDataPath;
	string gameName;

	void spawnObjects(){
		
	}

	//Abrir el XML y leerl
	public void read(){

		GenericGameElement gge;
		string xmlValue;
		//Ubico el archivo xml principal
		try{
			Debug.Log(Application.persistentDataPath);
			if(File.Exists(Application.persistentDataPath + "/loveLetter/core.xml")){
				Debug.Log ("Hurray archivo core.xml encontrado");
				StreamReader sr = new StreamReader(Application.persistentDataPath + "/loveLetter/core.xml");
				xmlCore = sr.ReadToEnd();
			}
		}
		catch(Exception e){	
			Console.WriteLine("File not found or corrupt.");
			Console.WriteLine(e.Message);
		}

		//Reading game objects
		XmlReader reader = XmlReader.Create(new StringReader(xmlCore));

		//Game options

		//Collection elements
		reader.ReadToFollowing("Collection");
		do{
			reader.MoveToFirstAttribute();
			xmlValue = reader.Value.ToString();
			Debug.Log("Atributo:"+reader.Value);

			if(xmlValue.CompareTo("GenericGameElement")==0){
				reader.MoveToNextAttribute();
				ggeQuantity = Convert.ToInt16(reader.Value);
				reader.MoveToNextAttribute();
				ggeName = reader.Value;

				for(int i=0; i<ggeQuantity; i++){
					gge = new GenericGameElement();
					gge = readSerialized(gge);
					gges.Add(gge);
				}
			}
			//Board
			/*else if(xmlValue.CompareTo("Board")==0){
					Debug.Log ("Hurray encontre un board");
			}*/

		}while(reader.ReadToNextSibling("Collection"));

		//Spawn somtehing
		spawnObjects();
	}
	
	public GenericGameElement readSerialized(GenericGameElement gge){
		string ggePath = path + "/loveLetter/"+"app/"+this.ggeName+".xml";
		var serializer = new XmlSerializer(typeof(GenericGameElement));
		var stream = new FileStream(ggePath, FileMode.Open);
		Debug.Log("Hurray gge XML cargado");

		try{
			gge = serializer.Deserialize(stream) as GenericGameElement;
			gge.printAtt();
			stream.Close();
		}catch(Exception e){
			Debug.Log("Invalid XML");
			Debug.Log(e);
		}
		return gge;
	}
}
