using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusCut : MonoBehaviour
{

	public GameObject fruitSlicedPrefab;
	public GameObject bloodPrefab;
	public float startForce = 15f;

	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Blade")
		{
			//Vector3 direction = (col.transform.position - transform.position).normalized;
			//Quaternion rotation_ = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, transform.rotation);
			Destroy(slicedFruit, 3f);
			Destroy(gameObject);

			GameObject blood = Instantiate(bloodPrefab, transform.position, transform.rotation);
			Destroy(blood, 3f);

			FindObjectOfType<OctopusNinja>().forceBlow += 0.05f;
			
		}
	}

}
