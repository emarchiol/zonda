using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

public class Token : IGenericGameElement {
	
	//Atributos de juego
	public int Type{ get; set; }
	public int Shape{ get; set; }

	public string Name{ get; set; }
	public string Image{ get; set; }
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
		Debug.Log (this.ExternalValue);
		Debug.Log (this.InternalValue);
		foreach (var item in ggeAttr) {
			Debug.Log(item.title);
			Debug.Log(item.description);
			Debug.Log(item.value);
		}
	}
}