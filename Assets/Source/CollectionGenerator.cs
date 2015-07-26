using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System;
using System.Xml.Serialization;
using System.Reflection;

/*
Esta clase carga segun el path entregado por el file browser los objetos que se usaran posteriormente por GameObjectGenerator para generar los objetos de juego con prefabs
En otra instancia del proyecto esta clase se modificara como patron strategy para que deserializar objetos no se haga unicamente por xml sino tmb otros formatos
 */
public class CollectionGenerator {

	FileStream file;
	string xmlCore,ggeName,gameName;
	int ggeQuantity;

	//Abre y lee el core.xml y por cada elemento intenta deserializar con ReadSerialized()
	public void ReadCoreXML(string path){

		//For Factory pattern
		GGEFactory ggeFactory = new GGEFactory();
		string ggeType;
		IGenericGameElement gge;
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

		//Collection elements
		try{
			reader.ReadToFollowing ("Collection");
			do {
				reader.MoveToFirstAttribute ();
				xmlValue = reader.Value.ToString ();
				Debug.Log ("Atributo:" + reader.Value);
				ggeType = reader.Value;

				//El xml me indicara cuantas copias de cada objeto hay (por ejemplo cartas iguales), con ese quantity genero x cantidad de GGE
				if (xmlValue.CompareTo ("Card") == 0 || xmlValue.CompareTo ("Token") == 0) {
					reader.MoveToNextAttribute ();
					ggeQuantity = Convert.ToInt16 (reader.Value);
					reader.MoveToNextAttribute ();
					ggeName = reader.Value;
					
					for (int i=0; i<ggeQuantity; i++) {
						gge = ggeFactory.CreateInstance(ggeType);
						gge = ReadSerialized(gge, path, ggeType);

						gge.printAtt();
						GameEnviroment.gges.Add (gge);
						Debug.Log("recolectando objetos...");
					}
				}
			} while(reader.ReadToFollowing("Collection") && !reader.EOF);
		}
		catch (Exception e){
			Debug.Log("Something went wrong:"+e);
		}
	}

	//Como dice, lee objetos serializados gge segun lo que encuentra en core.xml
	//IGenericGameElement gge es el objeto en donde se va a guardar el deserializado, ggeType el tipo de objeto (carta, token)
	public IGenericGameElement ReadSerialized(IGenericGameElement gge, string path, string ggeType){
		string ggePath = path +"app/"+this.ggeName+".xml";
		//Reflection
		Type unknowType = Type.GetType (ggeType);
		
		XmlSerializer serializer = new XmlSerializer(unknowType);
		FileStream stream = new FileStream(ggePath, FileMode.Open);
		Debug.Log("Hurray gge XML cargado");
		
		try{
			gge = serializer.Deserialize(stream) as IGenericGameElement;
		}catch(Exception e){
			Debug.Log("Invalid XML");
			Debug.Log(e);
		}
		finally{stream.Close();}
		return gge;
	}
}

/*Testeo de SERIALIZACION con atributos
		GGEAttr atributos = new GGEAttr ("titulo", "asdasdasd", 32);
		List<GGEAttr> atlist = new List<GGEAttr>();
		atlist.Add (atributos);
		Card cartaSerializada = new Card(1,2,3,"cartita","testSerialized.png","dsa.png","4","3",15,atlist);

		var serializer = new XmlSerializer(typeof(Card));
		var stream = new FileStream(path+"testSerialized.xml", FileMode.Open);
		serializer.Serialize(stream, cartaSerializada);
		stream.Close();
 */
