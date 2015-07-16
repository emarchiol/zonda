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
	public struct information{
		private string title;
		private string description;
		private string value;
	}

	List<information> infoValues = new List<information> ();

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
