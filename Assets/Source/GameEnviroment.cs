using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System;
using System.Xml.Serialization;

public class GameEnviroment {
	//Association
	List <GenericGameElement> gges = new List<GenericGameElement>();

	FileStream file;
	string xmlCore;
	string ggeName;
	int ggeQuantity;
	string path = Application.persistentDataPath;
	string gameName;


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
		/*reader.ReadToFollowing ("GameName");
		gameName = reader.Value;*/

		//Collection elements
		reader.ReadToFollowing("Collection");
		do{
			reader.MoveToFirstAttribute();
			xmlValue = reader.Value.ToString();
			//xmlValue = reader.Value;
			Debug.Log("Atributo:"+reader.Value);

			if(xmlValue.CompareTo("GenericGameElement")==0){
				reader.MoveToNextAttribute();
				ggeQuantity = Convert.ToInt16(reader.Value);
				Debug.Log("Atributo:"+reader.Value);
				reader.MoveToNextAttribute();
				ggeName = reader.Value;
				Debug.Log("Atributo:"+reader.Value);
				for(int i=0; i<ggeQuantity; i++){
					gge = new GenericGameElement();
					gge = readSerialized(gge);
					gges.Add(gge);
				}
			}
			/*else if(xmlValue.CompareTo("Board")==0){
					Debug.Log ("Hurray encontre un board");
			}*/
		}while(reader.ReadToNextSibling("Collection"));
		Debug.Log("Hurray termine de cargar gge");
	}
	
	public GenericGameElement readSerialized(GenericGameElement gge){
		string ggePath = path + "/loveLetter/"+"app/"+this.ggeName+".xml";
		string ggePathW = path + "/loveLetter/"+"app/asd.xml";
		var serializer = new XmlSerializer(typeof(GenericGameElement));
		var stream = new FileStream(ggePath, FileMode.Open);
		Debug.Log("Hurray gge XML cargado");

		GenericGameElement asd = new GenericGameElement (1, 2, 3, "asd", "front.png", "back.png", null, null);
		using (TextWriter writer = new StreamWriter(@ggePathW))
		{
			serializer.Serialize(writer, asd); 
		} 
		var streamW = new FileStream(ggePathW, FileMode.Create);
		serializer.Serialize(streamW, asd);
		streamW.Close();

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
