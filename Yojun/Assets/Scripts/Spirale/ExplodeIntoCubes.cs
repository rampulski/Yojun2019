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
	[SerializeField] private float minTimeToDie = 4;
	[SerializeField] private float maxTimeToDie = 4;


	public void Explode()
	{
		for (int x = 0; x < cubesPerAxis; x++)
		{
			for (int y = 0; y < cubesPerAxis; y++)
			{
				for (int z = 0; z < cubesPerAxis /2f; z++)
				{
					CreateCube(new Vector3(x, y, z));
				}
			}
		}
    }

	private void CreateCube(Vector3 coordinates)
	{
		carPart = Instantiate(carPart);
		carPart.GetComponent<CarPart>().Spawn(minTimeToDie, maxTimeToDie);

		carPart.GetComponent<MeshRenderer>().material = GetComponentInChildren<Renderer>().material;

		carPart.transform.localScale = transform.localScale / cubesPerAxis;

		Vector3 firstCube = transform.position - transform.localScale / 2 + carPart.transform.localScale / 2;
		carPart.transform.position = firstCube + Vector3.Scale(coordinates, carPart.transform.localScale);
		carPart.transform.localScale = carPart.transform.localScale / 3;

		carPart.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
	}
}
