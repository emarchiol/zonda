using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

public abstract class IGenericGameElement {
	
	//Atributos de juego
	int Type{ get; set; }
	int RatioW{ get; set; }
	int RatioH{ get; set; }
	string Name{ get; set; }
	string FrontImage{ get; set; }
	string BackImage{ get; set; }
	string ExternalValue{ get; set; }
	string InternalValue{ get; set; }
	int infoQuantity{ get; set; }
	//Atributos para parseo xml
	[XmlArrayItemAttribute]
	[XmlArray("AttrList")]
	List<GGEAttr> ggeAttr;

	//=============================
	//Metodos
	//=============================
	void printAtt (){}
	void SetType (int type){}
}
