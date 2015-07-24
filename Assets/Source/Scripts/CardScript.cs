using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {

	public GenericGameElement carta;


	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = carta.Name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
