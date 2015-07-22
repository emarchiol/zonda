using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

public class GenericGameElement {

	//Atributos de juego
	public int Type;
	public int RatioW;
	public int RatioH;
	public string Name;
	public string FrontImage;
	public string BackImage;
	public string ExternalValue;
	public string InternalValue;
	public int infoQuantity;
	//Atributos para parseo xml
	[XmlArrayItemAttribute]
	[XmlArray("AttrList")]
	public List<GGEAttr> ggeAttr;
	//Atributos de unity para el manejo de objetos

	//=============================
	//Constructores
	//=============================
	public GenericGameElement(){
	}

	public GenericGameElement(int type, int ratiow, int ratioh, string name,string frontimage,string backimage, string exvalue, string invalue, List<GGEAttr> attributes){
		this.Type = type;
		this.RatioH = ratioh;
		this.RatioW = ratiow;
		this.Name = name;
		this.FrontImage = frontimage;
		this.BackImage = backimage;
		this.ExternalValue = exvalue;
		this.InternalValue = invalue;
		this.ggeAttr = attributes;
	}

	//=============================
	//Metodos
	//=============================
	public void printAtt(){
		Debug.Log (this.Name);
		Debug.Log (this.Type);
		Debug.Log (this.RatioW);
		Debug.Log (this.RatioH);
		Debug.Log (this.FrontImage);
		Debug.Log (this.BackImage);
		Debug.Log (this.ExternalValue);
		Debug.Log (this.InternalValue);
		foreach (var item in ggeAttr) {
			Debug.Log(item.title);
			Debug.Log(item.description);
			Debug.Log(item.value);
		}
	}

	public void SetType(int type){
		this.Type = type;
	}
}
