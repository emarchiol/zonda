﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {

	public Card card;

	// Use this for initialization
	void Start () {
		this.GetComponent<Text> ().text = card.Name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
