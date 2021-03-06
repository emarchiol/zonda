﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

public class Card : IGenericGameElement {

	//Atributos de juego
	public int Type{ get; set; }
	public int RatioW{ get; set; }
	public int RatioH{ get; set; }
	public string Name{ get; set; }
	public string FrontImage{ get; set; }
	public string BackImage{ get; set; }
	public string ExternalValue{ get; set; }
	public string InternalValue{ get; set; }
	public int infoQuantity{ get; set; }
	//Atributos para parseo xml
	[XmlArrayItemAttribute]
	[XmlArray("AttrList")]
	public List<GGEAttr> ggeAttr{ get; set;}
	
	//=============================
	//Metodos
	//=============================
	/*Constructores para debug*/
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
	public Card(int type, int ratiow, int ratioh, string name,string frontimage,string backimage, string exvalue, string invalue,int infoQuantity, List<GGEAttr> attributes){
		this.Type = type;
		this.RatioH = ratioh;
		this.RatioW = ratiow;
		this.Name = name;
		this.FrontImage = frontimage;
		this.BackImage = backimage;
		this.ExternalValue = exvalue;
		this.InternalValue = invalue;
		this.infoQuantity = infoQuantity;
		this.ggeAttr = attributes;
	}
	public Card(){}
}
