using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
//Atributos adicionales que pueda tener una carta, token u obj de juego

[XmlRoot("GenericGameElement")]
public class GGEAttr {
	public string title;
	public string description;
	public int value;
}
