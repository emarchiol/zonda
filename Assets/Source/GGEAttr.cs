using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
//Generic Game Element Attributes, atributos adicionales que pueda tener un obj. de juego

[XmlRoot("GenericGameElement")]
public class GGEAttr {
	public string title;
	public string description;
	public int value;
}
