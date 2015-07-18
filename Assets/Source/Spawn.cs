using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	
	void Start()
	{
		//spawn object
		GameObject objToSpawn = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//Add Components
		objToSpawn.AddComponent<Rigidbody>();
		objToSpawn.transform.position = new Vector3 (300, 120, -460);
		for (int i=0; i<50; i++) {
			Instantiate(objToSpawn);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
