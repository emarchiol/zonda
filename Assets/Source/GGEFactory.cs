using UnityEngine;
using System.Collections;

public class GGEFactory {

	public IGenericGameElement CreateInstance(string typeGGE)
	{
		IGenericGameElement GGEObject;
		switch (typeGGE)
		{
		case "Card":
			GGEObject = new Card();
		break;

		case "Token":
			GGEObject = new Token();
			break;

		default:
			GGEObject = null;
		break;
		}
	return GGEObject;
	}
}
