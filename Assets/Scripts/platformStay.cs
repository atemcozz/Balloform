using UnityEngine;
using System.Collections;

public class platformStay : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D coll)
	{
		coll.transform.parent = transform;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		coll.transform.parent = null;
	}
}
