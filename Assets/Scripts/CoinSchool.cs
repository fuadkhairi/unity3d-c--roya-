using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSchool : MonoBehaviour {
	public GameObject Parent;
	public GameObject Child;

	void Start () {
		Vector3 posXYZ = new Vector3 (Parent.transform.position.x, Parent.transform.position.y, 50);
		Child.transform.position = posXYZ;
	}

}
