using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Text;
using System;
using System.Xml.Serialization;

public class PacketExtractor {

	FileStream file;
	String xmlGame;
	string path = Application.persistentDataPath + "/loveLetter/loveLetter.xml";

	//Abrir el XML y leerl
	public void read(){
		try{
			Debug.Log(Application.persistentDataPath);
			if(File.Exists(Application.persistentDataPath + "/loveLetter/loveLetter.xml")){
				Debug.Log ("Hurray archivo encontrado");
				StreamReader sr = new StreamReader(Application.persistentDataPath + "/loveLetter/loveLetter.xml");
				xmlGame = sr.ReadToEnd();
			}
			else{
				Debug.Log ("No encontre el archivo");
			}
		}
		catch(Exception e){	
			Console.WriteLine("The file could not be read:");
			Console.WriteLine(e.Message);
		}

		XmlReader reader = XmlReader.Create(new StringReader(xmlGame));
		reader.ReadToFollowing("Quantity");
		//reader.MoveToFirstAttribute();
		//string xmlValue = reader.Value;
		string xmlValue = reader.ReadElementContentAsString ();

		//if (string.Compare (xmlValue, "Quantity")==0) {
			Debug.Log("Hurray encontre GenericGameElement");
			Debug.Log (xmlValue);
		//}
	}

	public void readSerialized(){
		var serializer = new XmlSerializer(typeof(GenericGameElement));
		var stream = new FileStream(path, FileMode.Open);
		try{
			GenericGameElement gge = serializer.Deserialize(stream) as GenericGameElement;
			gge.printAtt ();
			stream.Close();
		}catch(Exception e){
			Debug.Log("Invalid XML");
			Debug.Log(e);
		}
	}
}
