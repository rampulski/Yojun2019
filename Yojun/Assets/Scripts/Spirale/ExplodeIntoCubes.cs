using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeIntoCubes : MonoBehaviour
{
	[SerializeField] private GameObject carPart;
	public int cubesPerAxis = 4;
	public float delay = 1f;
	public float force = 10f;
	public float radius = 0.05f;
	public float scale = 0.15f;
	public float height = 0.25f;
	[SerializeField] private float minTimeToDie = 4;
	[SerializeField] private float maxTimeToDie = 4;


	public void Explode()
	{
		for (int x = 0; x < cubesPerAxis; x++)
		{
			for (int y = 0; y < cubesPerAxis; y++)
			{
				for (int z = 0; z < cubesPerAxis; z++)
				{
					CreateCube(new Vector3(x, y, z));
				}
			}
		}
    }

	private void CreateCube(Vector3 coordinates)
	{
		GameObject part = Instantiate(carPart);
		part.GetComponent<CarPart>().Spawn(minTimeToDie, maxTimeToDie);

		part.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", GetComponentInChildren<Renderer>().material.GetColor("_EmissionColor"));

		part.transform.localScale = Vector3.one * scale;

		Vector3 firstCube = transform.position - (transform.forward * height);// - (transform.localScale / 2 + part.transform.localScale / 2);
		part.transform.position = firstCube + Vector3.Scale(coordinates, part.transform.localScale);

		part.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
	}
}
