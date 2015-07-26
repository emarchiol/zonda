using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

public interface IGenericGameElement{
	
	//Atributos de juego
	int Type{ get; set; }
	string Name{ get; set; }
	int infoQuantity{ get; set; }
	//Atributos para parseo xml
	[XmlArrayItemAttribute]
	[XmlArray("AttrList")]
	List<GGEAttr> ggeAttr{ get; set;}

	//=============================
	//Metodos
	//=============================
	void printAtt ();
}
