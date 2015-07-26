using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
//Generic Game Element Attributes, atributos adicionales que pueda tener un obj. de juego


public class GGEAttr {
	public string title;
	public string description;
	public int value;

	public GGEAttr(string titulo, string descripcion, int valor){
		this.title = titulo;
		this.description = descripcion;
		this.value = valor;
	}

	public GGEAttr(){}
}

