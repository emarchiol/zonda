using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System;
using System.Xml.Serialization;

/*
Esta clase carga segun el path entregado por el file browser el singleton de objetos que se usaran posteriormente por GameEnviroment dentro del juego
 */
public class GameObjectGenerator {

 
	FileStream file;
	string xmlCore;
	string ggeName;
	int ggeQuantity;
	string gameName;

	public static List <GenericGameElement> gges = new List<GenericGameElement>();

	//=============================
	//Metodos
	//=============================

	//Como dice, lee objetos serializados gge segun lo que encuentra en core.xml
	public GenericGameElement ReadSerialized(GenericGameElement gge, string path){
		string ggePath = path +"app/"+this.ggeName+".xml";
		XmlSerializer serializer = new XmlSerializer(typeof(GenericGameElement));
		FileStream stream = new FileStream(ggePath, FileMode.Open);
		Debug.Log("Hurray gge XML cargado");
		
		try{
			gge = serializer.Deserialize(stream) as GenericGameElement;
			stream.Close();
		}catch(Exception e){
			Debug.Log("Invalid XML");
			Debug.Log(e);
		}
		return gge;
	}

	//Abrir el XML y leerlo
	public void ReadCoreXML(string path){
		GenericGameElement gge;
		string xmlValue;
		//Ubico el archivo xml principal
		try{
			Debug.Log(path);
			if(File.Exists(path + "core.xml")){
				Debug.Log ("Hurray archivo core.xml encontrado");
				StreamReader sr = new StreamReader(path + "core.xml");
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
		int breaker = 0;
		try{
				reader.ReadToFollowing ("Collection");
				do {
					reader.MoveToFirstAttribute ();
					xmlValue = reader.Value.ToString ();
					Debug.Log ("Atributo:" + reader.Value);

					//El xml me indicara cuantas copias de cada objeto hay (por ejemplo cartas iguales), con ese quantity genero x cantidad de GGE
					if (xmlValue.CompareTo ("GenericGameElement") == 0) {
						reader.MoveToNextAttribute ();
						ggeQuantity = Convert.ToInt16 (reader.Value);
						reader.MoveToNextAttribute ();
						ggeName = reader.Value;
						
						for (int i=0; i<ggeQuantity; i++) {
							gge = new GenericGameElement ();
							gge = ReadSerialized (gge, path);
							gges.Add (gge);
							Debug.Log("recolectando objetos...");
						}
					}
					//Board
					/*else if(xmlValue.CompareTo("Board")==0){
							Debug.Log ("Hurray encontre un board");
					}*/
				breaker++;
				} while(reader.ReadToFollowing("Collection") && !reader.EOF);
		}
		catch (Exception e){
			Debug.Log("Something went wrong:"+e);
		}
	}
}
