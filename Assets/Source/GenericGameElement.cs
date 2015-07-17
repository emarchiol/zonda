using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericGameElement {

	public int Type;
	public int RatioW;
	public int RatioH;
	public string Name;
	public string FrontImage;
	public string BackImage;
	public string ExternalValue;
	public string InternalValue;
	public int infoQuantity;
	/*array de clases de attributos
	struct information{
		private string title;
		private string description;
		private string value;
	}
	List <information> infoValues = new List<information> ();
	*/

	public GenericGameElement(){
	}
	public GenericGameElement(int type, int ratiow, int ratioh, string name,string frontimage,string backimage, string exvalue, string invalue){
		this.Type = type;
		this.RatioH = ratioh;
		this.RatioW = ratiow;
		this.Name = name;
		this.FrontImage = frontimage;
		this.BackImage = backimage;
		this.ExternalValue = exvalue;
		this.InternalValue = invalue;
	}

	public void printAtt(){
		Debug.Log (this.Name);
		Debug.Log (this.Type);
		Debug.Log (this.RatioW);
		Debug.Log (this.RatioH);
		Debug.Log (this.FrontImage);
		Debug.Log (this.BackImage);
		Debug.Log (this.ExternalValue);
		Debug.Log (this.InternalValue);
	}
}
