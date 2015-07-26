using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TokenScript : MonoBehaviour {
	
	public Token token;
	
	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = token.Name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
